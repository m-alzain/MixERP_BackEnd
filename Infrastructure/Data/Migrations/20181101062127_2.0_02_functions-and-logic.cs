using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class _20_02_functionsandlogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"

-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/finance.auto_verify.sql --<--<--
IF OBJECT_ID('finance.auto_verify') IS NOT NULL
DROP PROCEDURE finance.auto_verify;

GO


CREATE PROCEDURE finance.auto_verify
(
    @tran_id        bigint,
    @office_id      integer
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @transaction_master_id          bigint= @tran_id;
    DECLARE @transaction_posted_by          integer;
    DECLARE @verifier                       integer;
    DECLARE @status                         integer = 1;
    DECLARE @reason                         national character varying(128) = 'Automatically verified';
    DECLARE @rejected                       smallint=-3;
    DECLARE @closed                         smallint=-2;
    DECLARE @withdrawn                      smallint=-1;
    DECLARE @unapproved                     smallint = 0;
    DECLARE @auto_approved                  smallint = 1;
    DECLARE @approved                       smallint=2;
    DECLARE @book                           national character varying(50);
    DECLARE @verification_limit             numeric(30, 6);
    DECLARE @posted_amount                  numeric(30, 6);
    DECLARE @has_policy                     bit= 0;
    DECLARE @voucher_date                   date;

    SELECT
        @book = finance.transaction_master.book,
        @voucher_date = finance.transaction_master.value_date,
        @transaction_posted_by = finance.transaction_master.user_id          
    FROM finance.transaction_master
    WHERE finance.transaction_master.transaction_master_id = @transaction_master_id
    AND finance.transaction_master.deleted = 0;
    
    SELECT
        @posted_amount = SUM(amount_in_local_currency)        
    FROM
        finance.transaction_details
    WHERE finance.transaction_details.transaction_master_id = @transaction_master_id
    AND finance.transaction_details.tran_type='Cr';


    SELECT
        @has_policy = 1,
        @verification_limit = verification_limit
    FROM finance.auto_verification_policy
    WHERE finance.auto_verification_policy.user_id = @transaction_posted_by
    AND finance.auto_verification_policy.office_id = @office_id
    AND finance.auto_verification_policy.is_active= 1
    AND GETUTCDATE() >= effective_from
    AND GETUTCDATE() <= ends_on
    AND finance.auto_verification_policy.deleted = 0;

    IF(@has_policy= 1)
    BEGIN
        UPDATE finance.transaction_master
        SET 
            last_verified_on = GETUTCDATE(),
            verified_by_user_id=@verifier,
            verification_status_id=@status,
            verification_reason=@reason
        WHERE
            finance.transaction_master.transaction_master_id=@transaction_master_id
        OR
            finance.transaction_master.cascading_tran_id=@transaction_master_id
        OR
        finance.transaction_master.transaction_master_id = 
        (
            SELECT cascading_tran_id
            FROM finance.transaction_master
            WHERE finance.transaction_master.transaction_master_id=@transaction_master_id 
        );
    END
    ELSE
    BEGIN
		--RAISERROR('No auto verification policy found for this user.', 13, 1);
		PRINT 'No auto verification policy found for this user.';
    END;
    RETURN;
END;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/finance.can_post_transaction.sql --<--<--
IF OBJECT_ID('finance.can_post_transaction') IS NOT NULL
DROP FUNCTION finance.can_post_transaction;

GO

CREATE FUNCTION finance.can_post_transaction(@login_id bigint, @user_id integer, @office_id integer, @transaction_book national character varying(50), @value_date date)
RETURNS @result TABLE
(
	can_post_transaction						bit,
	error_message								national character varying(1000)
)
AS
BEGIN
	INSERT INTO @result
	SELECT 0, '';

    DECLARE @eod_required                       bit		= finance.eod_required(@office_id);
    DECLARE @fiscal_year_start_date             date    = finance.get_fiscal_year_start_date(@office_id);
    DECLARE @fiscal_year_end_date               date    = finance.get_fiscal_year_end_date(@office_id);

    IF(account.is_valid_login_id(@login_id) = 0)
    BEGIN
		UPDATE @result
		SET error_message =  'Invalid LoginId.';
		RETURN;
    END; 

    IF(core.is_valid_office_id(@office_id) = 0)
    BEGIN
        UPDATE @result
		SET error_message =  'Invalid OfficeId.';
		RETURN;
    END;

    IF(finance.is_transaction_restricted(@office_id) = 1)
    BEGIN
        UPDATE @result
		SET error_message = 'This establishment does not allow transaction posting.';
		RETURN;
    END;
    
    IF(@eod_required = 1)
    BEGIN
        IF(finance.is_restricted_mode() = 1)
        BEGIN
            UPDATE @result
			SET error_message = 'Cannot post transaction during restricted transaction mode.';
			RETURN;
        END;

        IF(@value_date < finance.get_value_date(@office_id))
        BEGIN
            UPDATE @result
			SET error_message = 'Past dated transactions are not allowed.';
			RETURN;
        END;
    END;

    IF(@value_date < @fiscal_year_start_date)
    BEGIN
        UPDATE @result
		SET error_message = 'You cannot post transactions before the current fiscal year start date.';
		RETURN;
    END;

    IF(@value_date > @fiscal_year_end_date)
    BEGIN
        UPDATE @result
		SET error_message = 'You cannot post transactions after the current fiscal year end date.';

		RETURN;
    END;
    
    IF NOT EXISTS 
    (
        SELECT *
        FROM account.users
        INNER JOIN account.roles
        ON account.users.role_id = account.roles.role_id
        AND user_id = @user_id
    )
    BEGIN
        UPDATE @result
		SET error_message = 'Access is denied. You are not authorized to post this transaction.';
    END;
	
	UPDATE @result SET error_message = '', can_post_transaction = 1;

    RETURN;
END;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/finance.convert_exchange_rate.sql --<--<--
IF OBJECT_ID('finance.convert_exchange_rate') IS NOT NULL
DROP FUNCTION finance.convert_exchange_rate;

GO

CREATE FUNCTION finance.convert_exchange_rate(@office_id integer, @source_currency_code national character varying(12), @destination_currency_code national character varying(12))
RETURNS numeric(30, 6)
AS
BEGIN
    DECLARE @unit                           integer = 0;
    DECLARE @exchange_rate                  numeric(30, 6) = 0;
    DECLARE @from_source_currency           numeric(30, 6) = finance.get_exchange_rate(@office_id, @source_currency_code);
    DECLARE @from_destination_currency      numeric(30, 6) = finance.get_exchange_rate(@office_id, @destination_currency_code);

    IF(@source_currency_code = @destination_currency_code)
    BEGIN
        RETURN 1;
    END;
        
	IF(@from_destination_currency = 0)
	BEGIN
		RETURN NULL;
	END;

    RETURN @from_source_currency / @from_destination_currency; 
END;

GO

--SELECT  finance.convert_exchange_rate(1, 'USD', 'NPR')


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/finance.create_card_type.sql --<--<--
IF OBJECT_ID('finance.create_card_type') IS NOT NULL
DROP PROCEDURE finance.create_card_type;

GO

CREATE PROCEDURE finance.create_card_type
(
    @card_type_id       integer, 
    @card_type_code     national character varying(12),
    @card_type_name     national character varying(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

    IF NOT EXISTS
    (
        SELECT * FROM finance.card_types
        WHERE card_type_id = @card_type_id
    )
	BEGIN
        INSERT INTO finance.card_types(card_type_id, card_type_code, card_type_name)
        SELECT @card_type_id, @card_type_code, @card_type_name;
		
		RETURN;
	END

    UPDATE finance.card_types
    SET 
        card_type_id =      @card_type_id, 
        card_type_code =    @card_type_code, 
        card_type_name =    @card_type_name
    WHERE card_type_id =      @card_type_id;
END

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/finance.create_routine.sql --<--<--
IF OBJECT_ID('finance.create_routine') IS NOT NULL
DROP PROCEDURE finance.create_routine;

GO

CREATE PROCEDURE finance.create_routine(@routine_code national character varying(12), @routine national character varying(128), @order integer)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS(SELECT * FROM finance.routines WHERE routine_code=@routine_code)
    BEGIN
        INSERT INTO finance.routines(routine_code, routine_name, [order])
        SELECT @routine_code, @routine, @order
        RETURN;
            END;

            UPDATE finance.routines
            SET
        routine_name = @routine,
        [order] = @order
    WHERE routine_code = @routine_code;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.date_functions.sql-- < --< --
                        IF OBJECT_ID('finance.get_date') IS NOT NULL
                        DROP FUNCTION finance.get_date;
            GO

            CREATE FUNCTION finance.get_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN finance.get_value_date(@office_id);
            END;


            GO

            IF OBJECT_ID('finance.get_month_end_date') IS NOT NULL
            DROP FUNCTION finance.get_month_end_date;

            GO

            CREATE FUNCTION finance.get_month_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.deleted = 0
    );
            END;




            GO

            IF OBJECT_ID('finance.get_month_start_date') IS NOT NULL
            DROP FUNCTION finance.get_month_start_date;

            GO

            CREATE FUNCTION finance.get_month_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE value_date <
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.deleted = 0
    )
    AND finance.frequency_setups.deleted = 0;

            IF(@date IS NULL)
    BEGIN
        SELECT @date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.deleted = 0;
            END;

            RETURN @date;
            END;



            GO

            IF OBJECT_ID('finance.get_quarter_end_date') IS NOT NULL
            DROP FUNCTION finance.get_quarter_end_date;

            GO

            CREATE FUNCTION finance.get_quarter_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND frequency_id > 2
        AND finance.frequency_setups.deleted = 0
    );
            END;




            GO

            IF OBJECT_ID('finance.get_quarter_start_date') IS NOT NULL
            DROP FUNCTION finance.get_quarter_start_date;

            GO

            CREATE FUNCTION finance.get_quarter_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE value_date <
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.deleted = 0
    )
    AND frequency_id > 2
    AND finance.frequency_setups.deleted = 0;

            IF(@date IS NULL)
    BEGIN
        SELECT @date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.deleted = 0;
            END;

            RETURN @date;
            END;



            GO

            IF OBJECT_ID('finance.get_fiscal_half_end_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_half_end_date;

            GO

            CREATE FUNCTION finance.get_fiscal_half_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND frequency_id > 3
        AND finance.frequency_setups.deleted = 0
    );
            END;




            GO

            IF OBJECT_ID('finance.get_fiscal_half_start_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_half_start_date;

            GO

            CREATE FUNCTION finance.get_fiscal_half_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE value_date <
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.deleted = 0
    )
    AND frequency_id > 3
    AND finance.frequency_setups.deleted = 0;

            IF(@date IS NULL)
    BEGIN
        SELECT @date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.deleted = 0;
            END;

            RETURN @date;
            END;



            GO

            IF OBJECT_ID('finance.get_fiscal_year_end_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_year_end_date;

            GO

            CREATE FUNCTION finance.get_fiscal_year_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND frequency_id > 4
        AND finance.frequency_setups.deleted = 0
    );
            END;



            GO

            IF OBJECT_ID('finance.get_fiscal_year_start_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_year_start_date;

            GO

            CREATE FUNCTION finance.get_fiscal_year_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = starts_from
    FROM finance.fiscal_year
    WHERE finance.fiscal_year.deleted = 0;

            RETURN @date;
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.eod_required.sql-- < --< --
                        IF OBJECT_ID('finance.eod_required') IS NOT NULL
                        DROP FUNCTION finance.eod_required;

            GO

            CREATE FUNCTION finance.eod_required(@office_id integer)
RETURNS bit
AS
BEGIN

    DECLARE @value_date date = finance.get_value_date(@office_id);

            RETURN
            (
                SELECT finance.fiscal_year.eod_required
        
                FROM finance.fiscal_year
        
                WHERE finance.fiscal_year.office_id = @office_id
        
                AND finance.fiscal_year.deleted = 0
        
                AND finance.fiscal_year.starts_from >= @value_date
        
                AND finance.fiscal_year.ends_on <= @value_date
            );
            END;

            GO

            --SELECT finance.eod_required(1);


            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_id_by_account_name.sql-- < --< --
                       IF OBJECT_ID('finance.get_account_id_by_account_name') IS NOT NULL
                       DROP FUNCTION finance.get_account_id_by_account_name;

            GO

            CREATE FUNCTION finance.get_account_id_by_account_name(@account_name national character varying(500))
RETURNS integer
AS
BEGIN
    RETURN
    (
        SELECT

            account_id

        FROM finance.accounts

        WHERE finance.accounts.account_name = @account_name

        AND finance.accounts.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_id_by_account_number.sql-- < --< --
                        IF OBJECT_ID('finance.get_account_id_by_account_number') IS NOT NULL
                        DROP FUNCTION finance.get_account_id_by_account_number;

            GO

            CREATE FUNCTION finance.get_account_id_by_account_number(@account_number national character varying(500))
RETURNS integer
AS
BEGIN
    RETURN
    (
        SELECT

            account_id

        FROM finance.accounts

        WHERE finance.accounts.account_number = @account_number

        AND finance.accounts.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_id_by_bank_account_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_account_id_by_bank_account_id') IS NOT NULL
                        DROP FUNCTION finance.get_account_id_by_bank_account_id;

            GO

            CREATE FUNCTION finance.get_account_id_by_bank_account_id(@bank_account_id integer)
RETURNS integer
AS
BEGIN

    RETURN
    (
        SELECT account_id

        FROM finance.bank_accounts

        WHERE bank_account_id = @bank_account_id

        AND deleted = 0
    );
            END;

            GO

            --SELECT finance.get_account_id_by_bank_account_id(1);



            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_ids.sql-- < --< --
                       IF OBJECT_ID('finance.get_account_ids') IS NOT NULL
                       DROP FUNCTION finance.get_account_ids;

            GO

            CREATE FUNCTION finance.get_account_ids(@root_account_id integer)
RETURNS @result TABLE
(
    account_id              integer
)
AS
BEGIN
    WITH account_cte(account_id, path) AS
    (
        SELECT
            tn.account_id, CAST(tn.account_id AS varchar(2000)) AS path
        FROM finance.accounts AS tn
        WHERE tn.account_id = @root_account_id
        AND tn.deleted = 0

        UNION ALL

        SELECT
            c.account_id, CAST((p.path + '->' + CAST(c.account_id AS varchar(50))) AS varchar(2000))
        FROM account_cte AS p, finance.accounts AS c WHERE parent_account_id = p.account_id
    )

    INSERT INTO @result
    SELECT account_id FROM account_cte
    RETURN;
            END;
            GO

            --SELECT* FROM finance.get_account_ids(1);



            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_master_id_by_account_id.sql-- < --< --
                       IF OBJECT_ID('finance.get_account_master_id_by_account_id') IS NOT NULL
                       DROP FUNCTION finance.get_account_master_id_by_account_id;

            GO

            CREATE FUNCTION finance.get_account_master_id_by_account_id(@account_id integer)
RETURNS integer
AS
BEGIN
    RETURN
    (
        SELECT finance.accounts.account_master_id

        FROM finance.accounts

        WHERE finance.accounts.account_id = @account_id

        AND finance.accounts.deleted = 0
    );
            END;

            GO

            ALTER TABLE finance.bank_accounts
            ADD CONSTRAINT bank_accounts_account_id_chk
CHECK
(
    finance.get_account_master_id_by_account_id(account_id) = '10102'
);

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_master_id_by_account_master_code.sql-- < --< --
                        IF OBJECT_ID('finance.get_account_master_id_by_account_master_code') IS NOT NULL
                        DROP FUNCTION finance.get_account_master_id_by_account_master_code;

            GO

            CREATE FUNCTION finance.get_account_master_id_by_account_master_code(@account_master_code national character varying(24))
RETURNS integer
AS
BEGIN
    RETURN
    (
        SELECT finance.account_masters.account_master_id

        FROM finance.account_masters

        WHERE finance.account_masters.account_master_code = @account_master_code

        AND finance.account_masters.deleted = 0
    );
            END;





            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_master_ids.sql-- < --< --
                        IF OBJECT_ID('finance.get_account_master_ids') IS NOT NULL
                        DROP FUNCTION finance.get_account_master_ids;

            GO

            CREATE FUNCTION finance.get_account_master_ids(@root_account_master_id integer)
RETURNS @result TABLE
(
    account_master_id              integer
)
AS
BEGIN
    WITH account_cte(account_master_id, path) AS
    (
        SELECT
            tn.account_master_id, CAST(tn.account_master_id AS varchar(2000)) AS path
        FROM finance.account_masters AS tn
        WHERE tn.account_master_id = @root_account_master_id
        AND tn.deleted = 0

        UNION ALL

        SELECT
            c.account_master_id, CAST((p.path + '->' + CAST(c.account_master_id AS varchar(50))) AS varchar(2000))
        FROM account_cte AS p, finance.account_masters AS c WHERE parent_account_master_id = p.account_master_id
    )

    INSERT INTO @result
    SELECT account_master_id FROM account_cte
    RETURN;
            END;
            GO

            --SELECT* FROM finance.get_account_master_ids(1);



            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_name.sql-- < --< --
                       IF OBJECT_ID('finance.get_account_name_by_account_id') IS NOT NULL
                       DROP FUNCTION finance.get_account_name_by_account_id;

            GO

            CREATE FUNCTION finance.get_account_name_by_account_id(@account_id integer)
RETURNS national character varying(500)
AS
BEGIN
    RETURN
    (
        SELECT account_name

        FROM finance.accounts

        WHERE finance.accounts.account_id = @account_id

        AND finance.accounts.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_statement.sql-- < --< --
                        IF OBJECT_ID('finance.get_account_statement') IS NOT NULL
                        DROP FUNCTION finance.get_account_statement;

            GO

            CREATE FUNCTION finance.get_account_statement
            (
                @value_date_from        date,
                @value_date_to          date,
                @user_id                integer,
                @account_id             integer,
                @office_id              integer
            )
RETURNS @result TABLE
(
    id                      integer IDENTITY,
    transaction_id          bigint,
    transaction_detail_id   bigint,
    value_date              date,
    book_date               date,
    tran_code               national character varying(50),
    reference_number        national character varying(24),
    statement_reference     national character varying(2000),
    reconciliation_memo     national character varying(2000),
    debit                   numeric(30, 6),
    credit                  numeric(30, 6),
    balance                 numeric(30, 6),
    office                  national character varying(1000),
    book                    national character varying(50),
    account_id              integer,
    account_number          national character varying(24),
    account                 national character varying(1000),
    posted_on               DATETIMEOFFSET,
    posted_by               national character varying(1000),
    approved_by             national character varying(1000),
    verification_status     integer
)
AS
BEGIN
    DECLARE @normally_debit bit = finance.is_normally_debit(@account_id);

            INSERT INTO @result(value_date, book_date, tran_code, reference_number, statement_reference, debit, credit, office, book, account_id, posted_on, posted_by, approved_by, verification_status)
    SELECT
        @value_date_from,
        @value_date_from,
        NULL,
        NULL,
        'Opening Balance',
        NULL,
        SUM
        (
            CASE finance.transaction_details.tran_type
            WHEN 'Cr' THEN amount_in_local_currency
            ELSE amount_in_local_currency * -1
            END
        ) as credit,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL
    FROM finance.transaction_master
    INNER JOIN finance.transaction_details
    ON finance.transaction_master.transaction_master_id = finance.transaction_details.transaction_master_id
    WHERE finance.transaction_master.verification_status_id > 0
    AND finance.transaction_master.value_date < @value_date_from
    AND finance.transaction_master.office_id IN(SELECT* FROM core.get_office_ids(@office_id))
    AND finance.transaction_details.account_id IN(SELECT* FROM finance.get_account_ids(@account_id))
    AND finance.transaction_master.deleted = 0;

            DELETE FROM @result
            WHERE COALESCE(debit, 0) = 0
    AND COALESCE(credit, 0) = 0;


            UPDATE @result SET
            debit = credit * -1,
            credit = 0
    WHERE credit< 0;


            INSERT INTO @result(transaction_id, transaction_detail_id, value_date, book_date, tran_code, reference_number, statement_reference, reconciliation_memo, debit, credit, office, book, account_id, posted_on, posted_by, approved_by, verification_status)
    SELECT

        finance.transaction_details.transaction_master_id,
		finance.transaction_details.transaction_detail_id,
        finance.transaction_master.value_date,
        finance.transaction_master.book_date,
        finance.transaction_master.transaction_code,
        finance.transaction_master.reference_number,
        finance.transaction_details.statement_reference,
		finance.transaction_details.reconciliation_memo,
        CASE finance.transaction_details.tran_type
        WHEN 'Dr' THEN amount_in_local_currency
        ELSE NULL END,
        CASE finance.transaction_details.tran_type
        WHEN 'Cr' THEN amount_in_local_currency
        ELSE NULL END,
        core.get_office_name_by_office_id(finance.transaction_master.office_id),
        finance.transaction_master.book,
        finance.transaction_details.account_id,
        finance.transaction_master.transaction_ts,
        account.get_name_by_user_id(finance.transaction_master.user_id),
        account.get_name_by_user_id(finance.transaction_master.verified_by_user_id),
        finance.transaction_master.verification_status_id
    FROM finance.transaction_master
    INNER JOIN finance.transaction_details
    ON finance.transaction_master.transaction_master_id = finance.transaction_details.transaction_master_id
    WHERE finance.transaction_master.verification_status_id > 0
    AND finance.transaction_master.value_date >= @value_date_from
    AND finance.transaction_master.value_date <= @value_date_to
    AND finance.transaction_master.office_id IN(SELECT* FROM core.get_office_ids(@office_id))
    AND finance.transaction_details.account_id IN(SELECT* FROM finance.get_account_ids(@account_id))
    AND finance.transaction_master.deleted = 0
    ORDER BY
        finance.transaction_master.value_date,
        finance.transaction_master.transaction_ts,
        finance.transaction_master.book_date,
        finance.transaction_master.last_verified_on;



            UPDATE result
    SET balance = c.balance
    FROM @result AS result
    INNER JOIN
    (
        SELECT
            temp_account_statement.id,
            SUM(COALESCE(c.credit, 0)) 
            -
            SUM(COALESCE(c.debit, 0)) As balance
        FROM @result AS temp_account_statement
        LEFT JOIN @result AS c
            ON(c.id <= temp_account_statement.id)
        GROUP BY temp_account_statement.id
    ) AS c
    ON result.id = c.id;


            UPDATE result SET
                account_number = finance.accounts.account_number,
                account = finance.accounts.account_name
    FROM @result AS result
    INNER JOIN finance.accounts
    ON result.account_id = finance.accounts.account_id;



            IF(@normally_debit = 1)
    BEGIN
        UPDATE @result SET balance = balance * -1;
            END;

            RETURN;
            END;





            GO

            --SELECT* FROM finance.get_account_statement('1-1-2010', '1-1-2020', 1, 1, 1);


            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_account_view_by_account_master_id.sql-- < --< --
                       IF OBJECT_ID('finance.get_account_view_by_account_master_id') IS NOT NULL
                       DROP FUNCTION finance.get_account_view_by_account_master_id;

            GO

            CREATE FUNCTION finance.get_account_view_by_account_master_id
            (
                @account_master_id      integer,
                @row_number             integer
            )
RETURNS @results table
(
    id                      bigint,
    account_id              integer,
    account_name            text
)
AS
BEGIN
    INSERT INTO @results
    SELECT ROW_NUMBER() OVER(ORDER BY accounts.account_id) + @row_number AS id, *FROM
   (
       SELECT

           finance.accounts.account_id,
           finance.get_account_name_by_account_id(finance.accounts.account_id) AS account_name

       FROM finance.accounts

       WHERE finance.accounts.account_master_id = @account_master_id
   ) AS accounts;

            RETURN;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_cash_flow_heading_id_by_cash_flow_heading_code.sql-- < --< --
                        IF OBJECT_ID('finance.get_cash_flow_heading_id_by_cash_flow_heading_code') IS NOT NULL
                        DROP FUNCTION finance.get_cash_flow_heading_id_by_cash_flow_heading_code;

            GO

            CREATE FUNCTION finance.get_cash_flow_heading_id_by_cash_flow_heading_code(@cash_flow_heading_code national character varying(12))
RETURNS integer
AS
BEGIN
    RETURN
    (
        SELECT

            cash_flow_heading_id

        FROM finance.cash_flow_headings

        WHERE finance.cash_flow_headings.cash_flow_heading_code = @cash_flow_heading_code

        AND finance.cash_flow_headings.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_cash_repository_balance.sql-- < --< --

                        --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_cash_repository_balance.sql-- < --< --
                                   IF OBJECT_ID('finance.get_cash_repository_balance') IS NOT NULL
                                   DROP FUNCTION finance.get_cash_repository_balance;

            GO

            CREATE FUNCTION finance.get_cash_repository_balance(@cash_repository_id integer, @currency_code national character varying(12))
RETURNS numeric(30, 6)
AS
BEGIN
    DECLARE @debit numeric(30, 6);
            DECLARE @credit numeric(30, 6);

            SELECT @debit = COALESCE(SUM(amount_in_currency), 0)
    FROM finance.verified_transaction_view
    WHERE cash_repository_id = @cash_repository_id
    AND currency_code = @currency_code
    AND tran_type = 'Dr';

            SELECT @credit = COALESCE(SUM(amount_in_currency), 0)
    FROM finance.verified_transaction_view
    WHERE cash_repository_id = @cash_repository_id
    AND currency_code = @currency_code
    AND tran_type = 'Cr';

            RETURN @debit -@credit;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_cash_repository_id_by_cash_repository_code.sql-- < --< --
                        IF OBJECT_ID('finance.get_cash_repository_id_by_cash_repository_code') IS NOT NULL
                        DROP FUNCTION finance.get_cash_repository_id_by_cash_repository_code;

            GO


            CREATE FUNCTION finance.get_cash_repository_id_by_cash_repository_code(@cash_repository_code national character varying(24))
RETURNS integer
AS

BEGIN
    RETURN
    (
        SELECT cash_repository_id
        FROM finance.cash_repositories
        WHERE finance.cash_repositories.cash_repository_code = @cash_repository_code
        AND finance.cash_repositories.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_cash_repository_id_by_cash_repository_name.sql-- < --< --
                        IF OBJECT_ID('finance.get_cash_repository_id_by_cash_repository_name') IS NOT NULL
                        DROP FUNCTION finance.get_cash_repository_id_by_cash_repository_name;

            GO

            CREATE FUNCTION finance.get_cash_repository_id_by_cash_repository_name(@cash_repository_name national character varying(500))
RETURNS integer
AS

BEGIN
    RETURN
    (
        SELECT cash_repository_id
        FROM finance.cash_repositories
        WHERE finance.cash_repositories.cash_repository_name = @cash_repository_name
        AND finance.cash_repositories.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_cost_center_id_by_cost_center_code.sql-- < --< --
                        IF OBJECT_ID('finance.get_cost_center_id_by_cost_center_code') IS NOT NULL
                        DROP FUNCTION finance.get_cost_center_id_by_cost_center_code;

            GO

            CREATE FUNCTION finance.get_cost_center_id_by_cost_center_code(@cost_center_code national character varying(24))
RETURNS integer
AS
BEGIN
    RETURN
    (
        SELECT cost_center_id

        FROM finance.cost_centers

        WHERE finance.cost_centers.cost_center_code = @cost_center_code

        AND finance.cost_centers.deleted = 0
    );
            END;


            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_default_currency_code.sql-- < --< --
                        IF OBJECT_ID('finance.get_default_currency_code') IS NOT NULL
                        DROP FUNCTION finance.get_default_currency_code;

            GO

            CREATE FUNCTION finance.get_default_currency_code(@cash_repository_id integer)
RETURNS national character varying(12)
AS

BEGIN
    RETURN
    (
        SELECT core.offices.currency_code
        FROM finance.cash_repositories
        INNER JOIN core.offices
        ON core.offices.office_id = finance.cash_repositories.office_id
        WHERE finance.cash_repositories.cash_repository_id = @cash_repository_id
        AND finance.cash_repositories.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_default_currency_code_by_office_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_default_currency_code_by_office_id') IS NOT NULL
                        DROP FUNCTION finance.get_default_currency_code_by_office_id;

            GO

            CREATE FUNCTION finance.get_default_currency_code_by_office_id(@office_id integer)
RETURNS national character varying(12)
AS

BEGIN
    RETURN
    (
        SELECT core.offices.currency_code
        FROM core.offices
        WHERE core.offices.office_id = @office_id
        AND core.offices.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_exchange_rate.sql-- < --< --
                        IF OBJECT_ID('finance.get_exchange_rate') IS NOT NULL
                        DROP FUNCTION finance.get_exchange_rate;

            GO

            CREATE FUNCTION finance.get_exchange_rate(@office_id integer, @currency_code national character varying(12))
RETURNS numeric(30, 6)
AS
BEGIN
    DECLARE @local_currency_code        national character varying(12) = '';
            DECLARE @unit                       integer = 0;
            DECLARE @exchange_rate              numeric(30, 6) = 0;

            SELECT @local_currency_code = core.offices.currency_code
    FROM core.offices
    WHERE core.offices.office_id = @office_id
    AND core.offices.deleted = 0;

            IF(@local_currency_code = @currency_code)
    BEGIN
        RETURN 1;
            END;

            SELECT
                @unit = unit,
                @exchange_rate = exchange_rate
    FROM finance.exchange_rate_details
    INNER JOIN finance.exchange_rates
    ON finance.exchange_rate_details.exchange_rate_id = finance.exchange_rates.exchange_rate_id
    WHERE finance.exchange_rates.office_id = @office_id
    AND foreign_currency_code = @currency_code;

            IF(@unit = 0)
    BEGIN
        RETURN 0;
            END;

            RETURN @exchange_rate/ @unit;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_frequencies.sql-- < --< --
                        IF OBJECT_ID('finance.get_frequencies') IS NOT NULL
                        DROP FUNCTION finance.get_frequencies;

            GO

            CREATE FUNCTION finance.get_frequencies(@frequency_id integer)
RETURNS @t TABLE
(
    frequency_id    integer
)
AS
BEGIN
    IF(@frequency_id = 2)
    BEGIN
        --End of month
        --End of quarter is also end of third/ ninth month
         --End of half is also end of sixth month
         --End of year is also end of twelfth month
         INSERT INTO @t
        SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5;
            END
            ELSE IF(@frequency_id = 3)
    BEGIN

        --End of quarter
        --End of half is the second end of quarter
        --End of year is the fourth / last end of quarter
          INSERT INTO @t
        SELECT 3 UNION SELECT 4 UNION SELECT 5;
            END
            ELSE IF(@frequency_id = 4)
    BEGIN
        --End of half
        --End of year is the second end of half
        INSERT INTO @t
        SELECT 4 UNION SELECT 5;
            END
            ELSE IF(@frequency_id = 5)
    BEGIN
        --End of year
        INSERT INTO @t
        SELECT 5;
            END;

            RETURN;
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_frequency_end_date.sql-- < --< --
                        IF OBJECT_ID('finance.get_frequency_end_date') IS NOT NULL
                        DROP FUNCTION finance.get_frequency_end_date;

            GO

            CREATE FUNCTION finance.get_frequency_end_date(@frequency_id integer, @value_date date)
RETURNS date
AS
BEGIN
    DECLARE @end_date date;

            SELECT @end_date = MIN(value_date)
    FROM finance.frequency_setups
    WHERE value_date > @value_date
    AND frequency_id IN(SELECT finance.get_frequencies(@frequency_id));

            RETURN @end_date;
            END;



            --SELECT * FROM finance.get_frequency_end_date(1, '1-1-2000');

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_frequency_setup_code_by_frequency_setup_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_frequency_setup_code_by_frequency_setup_id') IS NOT NULL
                        DROP FUNCTION finance.get_frequency_setup_code_by_frequency_setup_id;

            GO

            CREATE FUNCTION finance.get_frequency_setup_code_by_frequency_setup_id(@frequency_setup_id integer)
RETURNS national character varying(24)
AS
BEGIN
    RETURN
    (
        SELECT frequency_setup_code

        FROM finance.frequency_setups

        WHERE finance.frequency_setups.frequency_setup_id = @frequency_setup_id

        AND finance.frequency_setups.deleted = 0
    );
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_frequency_setup_end_date_by_frequency_setup_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_frequency_setup_end_date_by_frequency_setup_id') IS NOT NULL
                        DROP FUNCTION finance.get_frequency_setup_end_date_by_frequency_setup_id;

            GO

            CREATE FUNCTION finance.get_frequency_setup_end_date_by_frequency_setup_id(@frequency_setup_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT value_date

        FROM finance.frequency_setups

        WHERE finance.frequency_setups.frequency_setup_id = @frequency_setup_id

        AND finance.frequency_setups.deleted = 0
    );
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_frequency_setup_start_date_by_frequency_setup_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_frequency_setup_start_date_by_frequency_setup_id') IS NOT NULL
                        DROP FUNCTION finance.get_frequency_setup_start_date_by_frequency_setup_id;

            GO

            CREATE FUNCTION finance.get_frequency_setup_start_date_by_frequency_setup_id(@frequency_setup_id integer)
RETURNS date
AS
BEGIN
    DECLARE @start_date date;

            SELECT @start_date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE finance.frequency_setups.value_date <
    (
        SELECT value_date
        FROM finance.frequency_setups
        WHERE finance.frequency_setups.frequency_setup_id = @frequency_setup_id
        AND finance.frequency_setups.deleted = 0
    )
    AND finance.frequency_setups.deleted = 0;

            IF(@start_date IS NULL)
    BEGIN
        SELECT @start_date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.deleted = 0;
            END;

            RETURN @start_date;
            END;

            GO



            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_frequency_setup_start_date_frequency_setup_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_frequency_setup_start_date_frequency_setup_id') IS NOT NULL
                        DROP FUNCTION finance.get_frequency_setup_start_date_frequency_setup_id;

            GO

            CREATE FUNCTION finance.get_frequency_setup_start_date_frequency_setup_id(@frequency_setup_id integer)
RETURNS date
AS
BEGIN
    DECLARE @start_date date;

            SELECT @start_date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE finance.frequency_setups.value_date <
    (
        SELECT value_date
        FROM finance.frequency_setups
        WHERE finance.frequency_setups.frequency_setup_id = @frequency_setup_id
        AND finance.frequency_setups.deleted = 0
    )
    AND finance.frequency_setups.deleted = 0;

            IF(@start_date IS NULL)
    BEGIN
        SELECT @start_date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.deleted = 0;
            END;

            RETURN @start_date;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_income_tax_provison_amount.sql-- < --< --
                        IF OBJECT_ID('finance.get_income_tax_provison_amount') IS NOT NULL
                        DROP FUNCTION finance.get_income_tax_provison_amount;

            GO

            CREATE FUNCTION finance.get_income_tax_provison_amount(@office_id integer, @profit numeric(30, 6), @balance numeric(30, 6))
RETURNS numeric(30, 6)
AS
BEGIN
    DECLARE @rate real = finance.get_income_tax_rate(@office_id);

            IF(@profit <= 0)
    BEGIN
        RETURN 0;
            END;

            RETURN
            (
                (@profit * @rate / 100) - @balance
            );
            END;

            GO

            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_income_tax_rate.sql-- < --< --
                        IF OBJECT_ID('finance.get_income_tax_rate') IS NOT NULL
                        DROP FUNCTION finance.get_income_tax_rate;

            GO

            CREATE FUNCTION finance.get_income_tax_rate(@office_id integer)
RETURNS numeric(30, 6)
AS

BEGIN
    RETURN
    (
        SELECT income_tax_rate

        FROM finance.tax_setups

        WHERE finance.tax_setups.office_id = @office_id

        AND finance.tax_setups.deleted = 0
    );
            END;



            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_journal_view.sql-- < --< --
                        IF OBJECT_ID('finance.get_journal_view') IS NOT NULL
                        DROP FUNCTION finance.get_journal_view;

            GO

            CREATE FUNCTION finance.get_journal_view
            (
                @user_id                        integer,
                @office_id                      integer,
                @from                           date,
                @to                             date,
                @tran_id                        bigint,
                @tran_code                      national character varying(50),
                @book                           national character varying(50),
                @reference_number               national character varying(50),
                @statement_reference            national character varying(2000),
                @posted_by                      national character varying(50),
                @office                         national character varying(50),
                @status                         national character varying(12),
                @verified_by                    national character varying(50),
                @reason                         national character varying(128)
            )
RETURNS @result TABLE
(
    transaction_master_id           bigint,
    transaction_code                national character varying(50),
    book                            national character varying(50),
    value_date                      date,
    book_date                          date,
    reference_number                national character varying(24),
    statement_reference             national character varying(2000),
    posted_by                       national character varying(1000),
    office national character varying(1000),
    status                          national character varying(1000),
    verified_by                     national character varying(1000),
    verified_on                     DATETIMEOFFSET,
    reason                          national character varying(128),
    transaction_ts                  DATETIMEOFFSET
)
AS

BEGIN
    WITH office_cte(office_id) AS
    (
        SELECT @office_id
        UNION ALL
        SELECT
            c.office_id
        FROM
        office_cte AS p,
        core.offices AS c
        WHERE
        parent_office_id = p.office_id
    )

    INSERT INTO @result
    SELECT
        finance.transaction_master.transaction_master_id, 
        finance.transaction_master.transaction_code,
        finance.transaction_master.book,
        finance.transaction_master.value_date,
        finance.transaction_master.book_date,
        finance.transaction_master.reference_number,
        finance.transaction_master.statement_reference,
        account.get_name_by_user_id(finance.transaction_master.user_id) as posted_by,
        core.get_office_name_by_office_id(finance.transaction_master.office_id) as office,
        finance.get_verification_status_name_by_verification_status_id(finance.transaction_master.verification_status_id) as status,
        account.get_name_by_user_id(finance.transaction_master.verified_by_user_id) as verified_by,
        finance.transaction_master.last_verified_on AS verified_on,
        finance.transaction_master.verification_reason AS reason,    
        finance.transaction_master.transaction_ts
    FROM finance.transaction_master
    WHERE 1 = 1
    AND finance.transaction_master.value_date BETWEEN @from AND @to
    AND office_id IN(SELECT office_id FROM office_cte)
    AND(@tran_id = 0 OR @tran_id = finance.transaction_master.transaction_master_id)
    AND LOWER(finance.transaction_master.transaction_code) LIKE '%' + LOWER(@tran_code) + '%'
    AND LOWER(finance.transaction_master.book) LIKE '%' + LOWER(@book) + '%'
    AND COALESCE(LOWER(finance.transaction_master.reference_number), '') LIKE '%' + LOWER(@reference_number) + '%'
    AND COALESCE(LOWER(finance.transaction_master.statement_reference), '') LIKE '%' + LOWER(@statement_reference) + '%'
    AND COALESCE(LOWER(finance.transaction_master.verification_reason), '') LIKE '%' + LOWER(@reason) + '%'
    AND LOWER(account.get_name_by_user_id(finance.transaction_master.user_id)) LIKE '%' + LOWER(@posted_by) + '%'
    AND LOWER(core.get_office_name_by_office_id(finance.transaction_master.office_id)) LIKE '%' + LOWER(@office) + '%'
    AND COALESCE(LOWER(finance.get_verification_status_name_by_verification_status_id(finance.transaction_master.verification_status_id)), '') LIKE '%' + LOWER(@status) + '%'
    AND COALESCE(LOWER(account.get_name_by_user_id(finance.transaction_master.verified_by_user_id)), '') LIKE '%' + LOWER(@verified_by) + '%'
    AND finance.transaction_master.deleted = 0
    ORDER BY value_date ASC, verification_status_id DESC;

            RETURN;
            END;




            --SELECT * FROM finance.get_journal_view(2, 1, '1-1-2000', '1-1-2020', 0, '', 'Inventory Transfer', '', '', '', '', '', '', '');



            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_new_transaction_counter.sql-- < --< --
                        IF OBJECT_ID('finance.get_new_transaction_counter') IS NOT NULL
                        DROP FUNCTION finance.get_new_transaction_counter;

            GO

            CREATE FUNCTION finance.get_new_transaction_counter(@value_date date)
RETURNS integer
AS
BEGIN
    DECLARE @ret_val integer;

            SELECT @ret_val = COALESCE(MAX(transaction_counter), 0)
    FROM finance.transaction_master
    WHERE finance.transaction_master.value_date = @value_date
    AND finance.transaction_master.deleted = 0;

            IF @ret_val IS NULL
    BEGIN
        SET @ret_val = 1;
            END
            ELSE
    BEGIN
        SET @ret_val = @ret_val + 1;
            END;

            RETURN @ret_val;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_office_id_by_cash_repository_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_office_id_by_cash_repository_id') IS NOT NULL
                        DROP FUNCTION finance.get_office_id_by_cash_repository_id;

            GO

            CREATE FUNCTION finance.get_office_id_by_cash_repository_id(@cash_repository_id integer)
RETURNS integer
AS

BEGIN
    RETURN
    (
        SELECT office_id

        FROM finance.cash_repositories

        WHERE finance.cash_repositories.cash_repository_id = @cash_repository_id

        AND finance.cash_repositories.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_periods.sql-- < --< --
                        IF OBJECT_ID('finance.get_periods') IS NOT NULL
                        DROP FUNCTION finance.get_periods;

            GO

            CREATE FUNCTION finance.get_periods
            (
                @date_from                      date,
                @date_to                        date
            )
RETURNS @period
TABLE
(
    period_name                             national character varying(500),
    date_from                               date,
    date_to                                 date
)
AS
BEGIN
    DECLARE @frequency_setups_temp TABLE
    (
        frequency_setup_id      int,
        value_date              date
    );

            INSERT INTO @frequency_setups_temp
            SELECT frequency_setup_id, value_date
            FROM finance.frequency_setups
            WHERE finance.frequency_setups.value_date BETWEEN @date_from AND @date_to
            AND finance.frequency_setups.deleted = 0
    ORDER BY value_date;

            INSERT INTO @period
            SELECT
        finance.get_frequency_setup_code_by_frequency_setup_id(frequency_setup_id),
        finance.get_frequency_setup_start_date_by_frequency_setup_id(frequency_setup_id),
        finance.get_frequency_setup_end_date_by_frequency_setup_id(frequency_setup_id)
    FROM @frequency_setups_temp;

            RETURN;
            END;



            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_retained_earnings_statement.sql-- < --< --
                        IF OBJECT_ID('finance.get_retained_earnings_statement') IS NOT NULL
                        DROP FUNCTION finance.get_retained_earnings_statement;

            GO

            CREATE FUNCTION finance.get_retained_earnings_statement
            (
                @date_to                        date,
                @office_id                      integer,
                @factor                         integer
            )
RETURNS @result TABLE
(
    id                              integer,
    value_date                      date,
    tran_code                       national character varying(50),
    statement_reference             national character varying(2000),
    debit                           numeric(30, 6),
    credit                          numeric(30, 6),
    balance                         numeric(30, 6),
    office                          national character varying(1000),
    book                            national character varying(50),
    account_id                      integer,
    account_number                  national character varying(24),
    account                         national character varying(1000),
    posted_on                       DATETIMEOFFSET,
    posted_by                       national character varying(1000),
    approved_by                     national character varying(1000),
    verification_status             integer
)
AS
BEGIN
    DECLARE @accounts TABLE
    (
        account_id                  integer
    );

            DECLARE @date_from              date;
            DECLARE @net_profit             numeric(30, 6) = 0;
            DECLARE @income_tax_rate        real = 0;
            DECLARE @itp                    numeric(30, 6) = 0;

            SET @date_from = finance.get_fiscal_year_start_date(@office_id);
            SET @net_profit = finance.get_net_profit(@date_from, @date_to, @office_id, @factor, 0);
            SET @income_tax_rate = finance.get_income_tax_rate(@office_id);

            IF(COALESCE(@factor, 0) = 0)
    BEGIN
        SET @factor = 1;
            END;

            IF(@income_tax_rate != 0)
    BEGIN
        SET @itp = (@net_profit * @income_tax_rate) / (100 - @income_tax_rate);
            END;

            DECLARE @retained_earnings TABLE
            (
                id                          integer IDENTITY,
                value_date                  date,
                tran_code                   national character varying(50),
                statement_reference         national character varying(2000),
                debit                       numeric(30, 6),
                credit                      numeric(30, 6),
                balance                     numeric(30, 6),
                office                      national character varying(1000),
                book                        national character varying(50),
                account_id                  integer,
                account_number              national character varying(24),
                account                     national character varying(1000),
                posted_on                   DATETIMEOFFSET,
                posted_by                   national character varying(1000),
                approved_by                 national character varying(1000),
                verification_status         integer
            );

            INSERT INTO @accounts
            SELECT finance.accounts.account_id
            FROM finance.accounts
            WHERE finance.accounts.account_master_id BETWEEN 15300 AND 15400;

            INSERT INTO @retained_earnings(value_date, tran_code, statement_reference, debit, credit, office, book, account_id, posted_on, posted_by, approved_by, verification_status)
    SELECT
        @date_from,
        NULL,
        'Beginning balance on this fiscal year.',
        NULL,
        SUM
        (
            CASE finance.transaction_details.tran_type
            WHEN 'Cr' THEN amount_in_local_currency
            ELSE amount_in_local_currency * -1
            END
        ) as credit,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        NULL
    FROM finance.transaction_master
    INNER JOIN finance.transaction_details
    ON finance.transaction_master.transaction_master_id = finance.transaction_details.transaction_master_id
    WHERE
        finance.transaction_master.verification_status_id > 0
    AND
        finance.transaction_master.value_date < @date_from
    AND
       finance.transaction_master.office_id IN(SELECT* FROM core.get_office_ids(@office_id))
    AND
       finance.transaction_details.account_id IN(SELECT* FROM @accounts);

            INSERT INTO @retained_earnings(value_date, tran_code, statement_reference, debit, credit)
    SELECT @date_to, '', 'Add: Net Profit as on ' + CAST(@date_to AS varchar(24)), 0, @net_profit;

            INSERT INTO @retained_earnings(value_date, tran_code, statement_reference, debit, credit)
    SELECT @date_to, '', 'Add: Income Tax provison.', 0, @itp;

            --DELETE FROM @retained_earnings
--WHERE COALESCE(@retained_earnings.debit, 0) = 0
--     AND COALESCE(@retained_earnings.credit, 0) = 0;


            UPDATE @retained_earnings SET
            debit = credit * -1,
            credit = 0
    WHERE credit< 0;


            INSERT INTO @retained_earnings(value_date, tran_code, statement_reference, debit, credit, office, book, account_id, posted_on, posted_by, approved_by, verification_status)
    SELECT
        finance.transaction_master.value_date,
        finance.transaction_master.transaction_code,
        finance.transaction_details.statement_reference,
        CASE finance.transaction_details.tran_type
        WHEN 'Dr' THEN amount_in_local_currency / @factor
        ELSE NULL END,
        CASE finance.transaction_details.tran_type
        WHEN 'Cr' THEN amount_in_local_currency / @factor
        ELSE NULL END,
        core.get_office_name_by_office_id(finance.transaction_master.office_id),
        finance.transaction_master.book,
        finance.transaction_details.account_id,
        finance.transaction_master.transaction_ts,
        account.get_name_by_user_id(finance.transaction_master.user_id),
        account.get_name_by_user_id(finance.transaction_master.verified_by_user_id),
        finance.transaction_master.verification_status_id
    FROM finance.transaction_master
    INNER JOIN finance.transaction_details
    ON finance.transaction_master.transaction_master_id = finance.transaction_details.transaction_master_id
    WHERE
        finance.transaction_master.verification_status_id > 0
    AND
        finance.transaction_master.value_date >= @date_from
    AND
        finance.transaction_master.value_date <= @date_to
    AND
       finance.transaction_master.office_id IN(SELECT* FROM core.get_office_ids(@office_id))
    AND
       finance.transaction_details.account_id IN(SELECT* FROM @accounts)
    ORDER BY
        finance.transaction_master.value_date,
        finance.transaction_master.last_verified_on;


            UPDATE @retained_earnings
    SET balance = c.balance
    FROM @retained_earnings AS retained_earnings
    INNER JOIN
    (
        SELECT
            retained_earnings.id,
            SUM(COALESCE(c.credit, 0)) 
            -
            SUM(COALESCE(c.debit, 0)) As balance
        FROM @retained_earnings AS retained_earnings
        LEFT JOIN @retained_earnings AS c
            ON(c.id <= retained_earnings.id)
        GROUP BY retained_earnings.id
    ) AS c
    ON retained_earnings.id = c.id;

            UPDATE @retained_earnings
    SET
        account_number = finance.accounts.account_number,
        account = finance.accounts.account_name
    FROM @retained_earnings AS retained_earnings
    INNER JOIN finance.accounts
    ON retained_earnings.account_id = finance.accounts.account_id;


            UPDATE @retained_earnings SET debit = NULL WHERE debit = 0;
            UPDATE @retained_earnings SET credit = NULL WHERE credit = 0;

            INSERT INTO @result
    SELECT* FROM @retained_earnings
   ORDER BY id;

            RETURN;
            END;






            GO


            --SELECT* FROM finance.get_retained_earnings_statement('7/16/2015', 2, 1000);

            --SELECT * FROM finance.get_retained_earnings('7/16/2015', 2, 100);


            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_root_account_id.sql-- < --< --
                       --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_root_account_id.sql-- < --< --
                                  IF OBJECT_ID('finance.get_root_account_id') IS NOT NULL
                                  DROP FUNCTION finance.get_root_account_id;

            GO

            CREATE FUNCTION finance.get_root_account_id(@account_id integer, @parent bigint)
RETURNS integer
AS
BEGIN
    DECLARE @parent_account_id integer;
            DECLARE @root_account_id integer;

            SELECT @parent_account_id = parent_account_id
    FROM finance.accounts
    WHERE finance.accounts.account_id = @account_id
    AND finance.accounts.deleted = 0;



            IF(@parent_account_id IS NULL)
    BEGIN
        SET @root_account_id = @account_id;
            END
            ELSE
    BEGIN
        SET @root_account_id = finance.get_root_account_id(@parent_account_id, @account_id);
            END;

            RETURN @root_account_id;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_sales_tax_account_id_by_office_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_sales_tax_account_id_by_office_id') IS NOT NULL
                        DROP FUNCTION finance.get_sales_tax_account_id_by_office_id;

            GO

            CREATE FUNCTION finance.get_sales_tax_account_id_by_office_id(@office_id integer)
RETURNS integer
AS

BEGIN
    RETURN
    (
        SELECT finance.tax_setups.sales_tax_account_id

        FROM finance.tax_setups

        WHERE finance.tax_setups.deleted = 0

        AND finance.tax_setups.office_id = @office_id
    );
            END



            GO


--> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_sales_tax_rate.sql-- < --< --
           IF OBJECT_ID('finance.get_sales_tax_rate') IS NOT NULL
           DROP FUNCTION finance.get_sales_tax_rate;

            GO

            CREATE FUNCTION finance.get_sales_tax_rate(@office_id integer)
RETURNS numeric(30, 6)
AS
BEGIN

    RETURN
    (
        SELECT

            finance.tax_setups.sales_tax_rate

        FROM finance.tax_setups

        WHERE finance.tax_setups.office_id = @office_id
    );
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_second_root_account_id.sql-- < --< --
                        --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_second_root_account_id.sql-- < --< --
                                   IF OBJECT_ID('finance.get_second_root_account_id') IS NOT NULL
                                   DROP FUNCTION finance.get_second_root_account_id;

            GO

            CREATE FUNCTION finance.get_second_root_account_id(@account_id integer, @parent bigint)
RETURNS integer
AS
BEGIN
    DECLARE @parent_account_id integer;
            DECLARE @root_account_id integer;

            SELECT @parent_account_id = parent_account_id
    FROM finance.accounts
    WHERE account_id = @account_id;

            IF(@parent_account_id IS NULL)
    BEGIN
        SET @root_account_id = @parent;
            END
            ELSE
    BEGIN
        SET @root_account_id = finance.get_second_root_account_id(@parent_account_id, @account_id);
            END;

            RETURN @root_account_id;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_transaction_code.sql-- < --< --
                        IF OBJECT_ID('finance.get_transaction_code') IS NOT NULL
                        DROP FUNCTION finance.get_transaction_code;

            GO
            CREATE FUNCTION finance.get_transaction_code(@value_date date, @office_id integer, @user_id integer, @login_id bigint)
RETURNS national character varying(24)
AS
BEGIN
    DECLARE @ret_val national character varying(1000);

            SET @ret_val = CAST(finance.get_new_transaction_counter(@value_date) AS varchar(24)) + '-' +
                            CONVERT(varchar(10), @value_date, 120) + '-' +
                            CAST(@office_id AS varchar(100)) + '-' +
                            CAST(@user_id AS varchar(100)) + '-' +
                            CAST(@login_id AS varchar(100)) + '-' +
                            CONVERT(VARCHAR(10), GETUTCDATE(), 108);

            RETURN @ret_val;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_value_date.sql-- < --< --
                        IF OBJECT_ID('finance.get_value_date') IS NOT NULL
                        DROP FUNCTION finance.get_value_date;

            GO

            CREATE FUNCTION finance.get_value_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @day_id                         bigint;
            DECLARE @completed                      bit;
            DECLARE @value_date                     date;
            DECLARE @day_operation_value_date       date;

            SELECT
                @day_id = finance.day_operation.day_id,
                @completed = finance.day_operation.completed,
                @day_operation_value_date = finance.day_operation.value_date
    FROM finance.day_operation
    WHERE office_id = @office_id
    AND value_date =
    (
        SELECT MAX(value_date)
        FROM finance.day_operation
        WHERE office_id = @office_id
    );

            IF(@day_id IS NOT NULL)
    BEGIN
        IF(@completed = 1)
        BEGIN
            SET @value_date = DATEADD(day, 1, @day_operation_value_date);
            END
            ELSE
        BEGIN
            SET @value_date = @day_operation_value_date;
            END;
            END;

            IF(@value_date IS NULL)
    BEGIN
        --SET @value_date = GETUTCDATE() AT time zone config.get_server_timezone();
            --Todo: validate the date and time produced by the following function
        SET @value_date = CAST(SYSDATETIMEOFFSET() AS date);
            END;

            RETURN @value_date;
            END;

            GO

            IF OBJECT_ID('finance.get_month_end_date') IS NOT NULL
            DROP FUNCTION finance.get_month_end_date;

            GO

            IF OBJECT_ID('finance.get_month_end_date') IS NOT NULL
            DROP FUNCTION finance.get_month_end_date;

            GO

            CREATE FUNCTION finance.get_month_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.office_id = @office_id
    );
            END;

            GO

            IF OBJECT_ID('finance.get_month_start_date') IS NOT NULL
            DROP FUNCTION finance.get_month_start_date;

            GO

            CREATE FUNCTION finance.get_month_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE value_date <
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.office_id = @office_id
    );

            IF(@date IS NULL)
    BEGIN
        SELECT @date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.office_id = @office_id;
            END;

            RETURN @date;
            END;


            GO

            IF OBJECT_ID('finance.get_quarter_end_date') IS NOT NULL
            DROP FUNCTION finance.get_quarter_end_date;

            GO

            CREATE FUNCTION finance.get_quarter_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND frequency_id > 2
        AND finance.frequency_setups.office_id = @office_id
    );
            END;


            GO


            IF OBJECT_ID('finance.get_quarter_start_date') IS NOT NULL
            DROP FUNCTION finance.get_quarter_start_date;

            GO

            CREATE FUNCTION finance.get_quarter_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE value_date <
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.office_id = @office_id
    )
    AND frequency_id > 2;

            IF(@date IS NULL)
    BEGIN
        SELECT @date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.office_id = @office_id;
            END;

            RETURN @date;
            END;

            GO

            IF OBJECT_ID('finance.get_fiscal_half_end_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_half_end_date;

            GO

            CREATE FUNCTION finance.get_fiscal_half_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND frequency_id > 3
        AND finance.frequency_setups.office_id = @office_id
    );
            END;


            GO


            IF OBJECT_ID('finance.get_fiscal_half_start_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_half_start_date;

            GO

            CREATE FUNCTION finance.get_fiscal_half_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = DATEADD(day, 1, MAX(value_date))
    FROM finance.frequency_setups
    WHERE value_date <
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND finance.frequency_setups.office_id = @office_id
    )
    AND frequency_id > 3;

            IF(@date IS NULL)
    BEGIN
        SELECT @date = starts_from
        FROM finance.fiscal_year
        WHERE finance.fiscal_year.office_id = @office_id;
            END;

            RETURN @date;
            END;


            GO

            IF OBJECT_ID('finance.get_fiscal_year_end_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_year_end_date;

            GO

            CREATE FUNCTION finance.get_fiscal_year_end_date(@office_id integer)
RETURNS date
AS

BEGIN
    RETURN
    (
        SELECT MIN(value_date)
        FROM finance.frequency_setups
        WHERE value_date >= finance.get_value_date(@office_id)
        AND frequency_id > 4
        AND finance.frequency_setups.office_id = @office_id
    );
            END;


            GO


            IF OBJECT_ID('finance.get_fiscal_year_start_date') IS NOT NULL
            DROP FUNCTION finance.get_fiscal_year_start_date;

            GO

            CREATE FUNCTION finance.get_fiscal_year_start_date(@office_id integer)
RETURNS date
AS
BEGIN
    DECLARE @date               date;

            SELECT @date = starts_from
    FROM finance.fiscal_year
    WHERE finance.fiscal_year.office_id = @office_id;

            RETURN @date;
            END;




            --SELECT 1 AS office_id, finance.get_value_date(1) AS today, finance.get_month_start_date(1) AS month_start_date, finance.get_month_end_date(1) AS month_end_date, finance.get_quarter_start_date(1) AS quarter_start_date, finance.get_quarter_end_date(1) AS quarter_end_date, finance.get_fiscal_half_start_date(1) AS fiscal_half_start_date, finance.get_fiscal_half_end_date(1) AS fiscal_half_end_date, finance.get_fiscal_year_start_date(1) AS fiscal_year_start_date, finance.get_fiscal_year_end_date(1) AS fiscal_year_end_date;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.get_verification_status_name_by_verification_status_id.sql-- < --< --
                        IF OBJECT_ID('finance.get_verification_status_name_by_verification_status_id') IS NOT NULL
                        DROP FUNCTION finance.get_verification_status_name_by_verification_status_id;

            GO

            CREATE FUNCTION finance.get_verification_status_name_by_verification_status_id(@verification_status_id integer)
RETURNS national character varying(500)
AS

BEGIN
    RETURN
    (
        SELECT

            verification_status_name

        FROM core.verification_statuses

        WHERE core.verification_statuses.verification_status_id = @verification_status_id

        AND core.verification_statuses.deleted = 0
    );
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.has_child_accounts.sql-- < --< --
                        IF OBJECT_ID('finance.has_child_accounts') IS NOT NULL
                        DROP FUNCTION finance.has_child_accounts;

            GO

            CREATE FUNCTION finance.has_child_accounts(@account_id integer)
RETURNS bit
AS
BEGIN

    DECLARE @has_child bit = 0;

            IF EXISTS(SELECT TOP 1 0 FROM finance.accounts WHERE parent_account_id = @account_id)
    BEGIN
        SET @has_child = 1;
            END;

            RETURN @has_child;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.initialize_eod_operation.sql-- < --< --
                        IF OBJECT_ID('finance.initialize_eod_operation') IS NOT NULL
                        DROP PROCEDURE finance.initialize_eod_operation;

            GO

            CREATE PROCEDURE finance.initialize_eod_operation(@user_id integer, @office_id integer, @value_date date)
AS
BEGIN
    SET NOCOUNT ON;
            SET XACT_ABORT ON;

            IF(@value_date IS NULL)
    BEGIN
        RAISERROR('Invalid date.', 13, 1);
            END;

            IF(account.is_admin(@user_id) = 0)
    BEGIN
        RAISERROR('Access is denied.', 13, 1);
            END;

            IF(@value_date != finance.get_value_date(@office_id))
    BEGIN
        RAISERROR('Invalid value date.', 13, 1);
            END;


            IF NOT EXISTS
            (
                SELECT * FROM finance.day_operation
        
                WHERE value_date = @value_date
        
                AND office_id = @office_id
            )
    BEGIN
        INSERT INTO finance.day_operation(office_id, value_date, started_on, started_by)
        SELECT @office_id, @value_date, GETUTCDATE(), @user_id;
            END
            ELSE
    BEGIN
        RAISERROR('EOD operation was already initialized.', 13, 1);
            END;

            RETURN;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.is_cash_account_id.sql-- < --< --
                        IF OBJECT_ID('finance.is_cash_account_id') IS NOT NULL
                        DROP FUNCTION finance.is_cash_account_id;

            GO

            CREATE FUNCTION finance.is_cash_account_id(@account_id integer)
RETURNS bit
AS

BEGIN
    IF EXISTS
    (
        SELECT 1 FROM finance.accounts
        WHERE account_master_id IN(10101)
        AND account_id = @account_id
    )
    BEGIN
        RETURN 1;
            END;
            RETURN 0;
            END;

            GO



            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.is_eod_initialized.sql-- < --< --
                        IF OBJECT_ID('finance.is_eod_initialized') IS NOT NULL
                        DROP FUNCTION finance.is_eod_initialized;

            GO

            CREATE FUNCTION finance.is_eod_initialized(@office_id integer, @value_date date)
RETURNS bit
AS

BEGIN
    IF EXISTS
    (
        SELECT* FROM finance.day_operation
        WHERE office_id = @office_id
        AND value_date = @value_date
        AND completed = 0
    )
    BEGIN
        RETURN 1;
            END;

            RETURN 0;
            END;




            --SELECT * FROM finance.is_eod_initialized(1, '1-1-2000');

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.is_new_day_started.sql-- < --< --
                        IF OBJECT_ID('finance.is_new_day_started') IS NOT NULL
                        DROP FUNCTION finance.is_new_day_started;

            GO

            CREATE FUNCTION finance.is_new_day_started(@office_id integer)
RETURNS bit
AS

BEGIN
    IF EXISTS
    (
        SELECT TOP 1 0 FROM finance.day_operation
        WHERE finance.day_operation.office_id = @office_id
        AND finance.day_operation.completed = 0
    )
    BEGIN
        RETURN 1;
            END;

            RETURN 0;
            END;

            --SELECT * FROM finance.is_new_day_started(1);

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.is_normally_debit.sql-- < --< --
                        IF OBJECT_ID('finance.is_normally_debit') IS NOT NULL
                        DROP FUNCTION finance.is_normally_debit;

            GO

            CREATE FUNCTION finance.is_normally_debit(@account_id integer)
RETURNS bit
AS

BEGIN
    RETURN
    (
        SELECT

            finance.account_masters.normally_debit

        FROM  finance.accounts

        INNER JOIN finance.account_masters

        ON finance.accounts.account_master_id = finance.account_masters.account_master_id

        WHERE finance.accounts.account_id = @account_id

        AND finance.accounts.deleted = 0
    );
            END



            GO


--> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.is_periodic_inventory.sql-- < --< --
           IF OBJECT_ID('finance.is_periodic_inventory') IS NOT NULL
           DROP FUNCTION finance.is_periodic_inventory;

            GO

            CREATE FUNCTION finance.is_periodic_inventory(@office_id integer)
RETURNS bit
AS
BEGIN

    --This is overriden by inventory module
    RETURN 0;
            END;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.is_restricted_mode.sql-- < --< --
                        IF OBJECT_ID('finance.is_restricted_mode') IS NOT NULL
                        DROP FUNCTION finance.is_restricted_mode;

            GO

            CREATE FUNCTION finance.is_restricted_mode()
RETURNS bit
AS

BEGIN
    IF EXISTS
    (
        SELECT TOP 1 0 FROM finance.day_operation
        WHERE completed = 0
    )
    BEGIN
        RETURN 1;
            END;

            RETURN 0;
            END;



            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.is_transaction_restricted.sql-- < --< --
                        IF OBJECT_ID('finance.is_transaction_restricted') IS NOT NULL
                        DROP FUNCTION finance.is_transaction_restricted;

            GO

            CREATE FUNCTION finance.is_transaction_restricted
            (
                @office_id      integer
            )
RETURNS bit
AS
BEGIN
    RETURN
    (
        SELECT ~allow_transaction_posting

        FROM core.offices

        WHERE office_id = @office_id
    );
            END;




            --SELECT * FROM finance.is_transaction_restricted(1);

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.perform_eod_operation.sql-- < --< --
                        IF OBJECT_ID('finance.perform_eod_operation') IS NOT NULL
                        DROP PROCEDURE finance.perform_eod_operation;

            GO

            CREATE PROCEDURE finance.perform_eod_operation(@user_id integer, @login_id bigint, @office_id integer, @value_date date)
AS
BEGIN
    SET NOCOUNT ON;
            SET XACT_ABORT ON;

            DECLARE @routine            national character varying(128);
            DECLARE @routine_id         integer;
            DECLARE @sql                national character varying(1000);
            DECLARE @is_error           bit = 0;
            DECLARE @notice             national character varying(1000);
            DECLARE @office_code        national character varying(50);
            DECLARE @completed          bit;
            DECLARE @completed_on       DATETIMEOFFSET;
            DECLARE @counter            integer = 0;
            DECLARE @total_rows         integer = 0;

            DECLARE @this               TABLE
            (
                routine_id              integer,
                routine_name            national character varying(128)
            );

            BEGIN TRY
        DECLARE @tran_count int = @@TRANCOUNT;

            IF(@tran_count = 0)
        BEGIN
            BEGIN TRANSACTION
        END;

            IF(@value_date IS NULL)
        BEGIN
            RAISERROR('Invalid date.', 13, 1);
            END;

            IF(account.is_admin(@user_id) = 0)
        BEGIN
            RAISERROR('Access is denied.', 13, 1);
            END;

            IF(@value_date != finance.get_value_date(@office_id))
        BEGIN
            RAISERROR('Invalid value date.', 13, 1);
            END;

            SELECT
                @completed = finance.day_operation.completed,
                @completed_on = finance.day_operation.completed_on
        FROM finance.day_operation
        WHERE value_date = @value_date
        AND office_id = @office_id;

            IF(@completed IS NULL)
        BEGIN
            RAISERROR('Invalid value date.', 13, 1);
            END
            ELSE
        BEGIN
            IF(@completed = 1 OR @completed_on IS NOT NULL)
            BEGIN
                RAISERROR('End of day operation was already performed.', 13, 1);
            SET @is_error = 1;
            END;
            END;

            IF EXISTS
            (
                SELECT* FROM finance.transaction_master
                WHERE value_date<@value_date
    
                AND verification_status_id = 0
            )
        BEGIN
            RAISERROR('Past dated transactions in verification queue.', 13, 1);
            SET @is_error = 1;
            END;

            IF EXISTS
            (
                SELECT* FROM finance.transaction_master
                WHERE value_date = @value_date
    
                AND verification_status_id = 0
            )
        BEGIN
            RAISERROR('Please verify transactions before performing end of day operation.', 13, 1);
            SET @is_error = 1;
            END;

            IF(@is_error = 0)
        BEGIN
            INSERT INTO @this
            SELECT routine_id, routine_name
            FROM finance.routines
            WHERE status = 1
            ORDER BY [order] ASC;

            SET @office_code = core.get_office_code_by_office_id(@office_id);
            SET @notice = 'EOD started.';
            PRINT @notice;

            SELECT @total_rows = MAX(routine_id) FROM @this;

            WHILE @counter <= @total_rows
            BEGIN
                SELECT TOP 1
                    @routine_id = routine_id,
                    @routine = LTRIM(RTRIM(routine_name))
                FROM @this
                WHERE routine_id >= @counter
                ORDER BY routine_id;

            IF(@routine_id IS NOT NULL)
                BEGIN
                    SET @counter = @routine_id + 1;
            END
            ELSE
                BEGIN
                    BREAK;
            END;

            SET @sql = FORMATMESSAGE('EXECUTE %s @user_id, @login_id, @office_id, @value_date;', @routine);
            PRINT @sql;
            SET @notice = 'Performing ' + @routine + '.';
            PRINT @notice;

            EXECUTE @routine @user_id, @login_id, @office_id, @value_date;

            SET @notice = 'Completed  ' + @routine + '.';
            PRINT @notice;

            WAITFOR DELAY '00:00:02';
            END;




            UPDATE finance.day_operation SET
                completed_on = GETUTCDATE(), 
                completed_by = @user_id,
                completed = 1
            WHERE value_date = @value_date
            AND office_id = @office_id;

            SET @notice = 'EOD of ' + @office_code + ' for ' + CAST(@value_date AS varchar(24)) + ' completed without errors.';
            PRINT @notice;

            SET @notice = 'OK';
            PRINT @notice;

            SELECT 1;
            END;

            IF(@tran_count = 0)
        BEGIN
            COMMIT TRANSACTION;
            END;
            END TRY
    BEGIN CATCH
        IF(XACT_STATE() <> 0 AND @tran_count = 0)
        BEGIN
            ROLLBACK TRANSACTION;
            END;

            DECLARE @ErrorMessage national character varying(4000) = ERROR_MESSAGE();
            DECLARE @ErrorSeverity int                              = ERROR_SEVERITY();
            DECLARE @ErrorState int                                 = ERROR_STATE();
            RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
            END CATCH;
            END;

            GO


            --UPDATE finance.day_operation
            --SET completed = 0, completed_by = NULL, completed_on = NULL;

            --EXECUTE finance.perform_eod_operation 1, 1, 1, '1/2/2017';

            --ROLLBACK TRANSACTION


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.reconcile_account.sql-- < --< --
                        IF OBJECT_ID('finance.reconcile_account') IS NOT NULL
                        DROP PROCEDURE finance.reconcile_account;

            GO

            CREATE PROCEDURE finance.reconcile_account
            (
                @transaction_detail_id              bigint,
                @user_id                            integer,
                @new_book_date                      date,
                @reconciliation_memo                text
            )
AS
BEGIN

    SET NOCOUNT ON;
            SET XACT_ABORT ON;

            DECLARE @transaction_master_id      bigint;

            BEGIN TRY

        DECLARE @tran_count int = @@TRANCOUNT;

            IF(@tran_count = 0)

        BEGIN
            BEGIN TRANSACTION
        END;

            SELECT @transaction_master_id = finance.transaction_details.transaction_master_id

        FROM finance.transaction_details
        WHERE finance.transaction_details.transaction_detail_id = @transaction_detail_id;

            UPDATE finance.transaction_master
            SET

            book_date = @new_book_date,
			audit_user_id = @user_id,
			audit_ts = GETUTCDATE()

        WHERE finance.transaction_master.transaction_master_id = @transaction_master_id;


            UPDATE finance.transaction_details
            SET

            book_date = @new_book_date,
			reconciliation_memo = @reconciliation_memo,
			audit_user_id = @user_id,
			audit_ts = GETUTCDATE()

        WHERE finance.transaction_details.transaction_master_id = @transaction_master_id;
            IF(@tran_count = 0)

        BEGIN
            COMMIT TRANSACTION;
            END;
            END TRY

    BEGIN CATCH

        IF(XACT_STATE() <> 0 AND @tran_count = 0)

        BEGIN
            ROLLBACK TRANSACTION;
            END;

            DECLARE @ErrorMessage national character varying(4000) = ERROR_MESSAGE();
            DECLARE @ErrorSeverity int                              = ERROR_SEVERITY();
            DECLARE @ErrorState int                                 = ERROR_STATE();
            RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
            END CATCH;
            END

            GO

--EXECUTE finance.reconcile_account 1, 1, '1-1-2000', 'test';


            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / finance.verify_transaction.sql-- < --< --
                       IF OBJECT_ID('finance.verify_transaction') IS NOT NULL
                       DROP PROCEDURE finance.verify_transaction;

            GO

            CREATE PROCEDURE finance.verify_transaction
            (
                @transaction_master_id                  bigint,
                @office_id                              integer,
                @user_id                                integer,
                @login_id                               bigint,
                @verification_status_id                 smallint,
                @reason                                 national character varying(100)
            )
AS
BEGIN
    SET NOCOUNT ON;
            SET XACT_ABORT ON;

            DECLARE @transaction_posted_by          integer;
            DECLARE @book                           national character varying(50);
            DECLARE @can_verify                     bit;
            DECLARE @verification_limit             numeric(30, 6);
            DECLARE @can_self_verify                bit;
            DECLARE @self_verification_limit        numeric(30, 6);
            DECLARE @posted_amount                  numeric(30, 6);
            DECLARE @has_policy                     bit = 0;
            DECLARE @journal_date                   date;
            DECLARE @journal_office_id              integer;
            DECLARE @cascading_tran_id              bigint;

            SELECT
                @book = finance.transaction_master.book,
                @journal_date = finance.transaction_master.value_date,
                @journal_office_id = finance.transaction_master.office_id,
                @transaction_posted_by = finance.transaction_master.user_id
    FROM
    finance.transaction_master
    WHERE finance.transaction_master.transaction_master_id = @transaction_master_id
    AND finance.transaction_master.deleted = 0;


            IF(@journal_office_id <> @office_id)
    BEGIN
        RAISERROR('Access is denied. You cannot verify a transaction of another office.', 13, 1);
            END;

            SELECT @posted_amount = SUM(amount_in_local_currency)
    FROM finance.transaction_details
    WHERE finance.transaction_details.transaction_master_id = @transaction_master_id
    AND finance.transaction_details.tran_type = 'Cr';


            SELECT
                @has_policy = 1,
                @can_verify = can_verify,
                @verification_limit = verification_limit,
                @can_self_verify = can_self_verify,
                @self_verification_limit = self_verification_limit
    FROM finance.journal_verification_policy
    WHERE finance.journal_verification_policy.user_id = @user_id
    AND finance.journal_verification_policy.office_id = @office_id
    AND finance.journal_verification_policy.is_active = 1
    AND GETUTCDATE() >= effective_from
    AND GETUTCDATE() <= ends_on
    AND finance.journal_verification_policy.deleted = 0;

            IF(@can_self_verify = 0 AND @user_id = @transaction_posted_by)
    BEGIN
        SET @can_verify = 0;
            END;

            IF(@has_policy = 1)
    BEGIN
        IF(@can_verify = 1)
        BEGIN

            SELECT @cascading_tran_id = cascading_tran_id
            FROM finance.transaction_master
            WHERE finance.transaction_master.transaction_master_id = @transaction_master_id
            AND finance.transaction_master.deleted = 0;

            UPDATE finance.transaction_master
            SET
                last_verified_on = GETUTCDATE(),
                verified_by_user_id = @user_id,
                verification_status_id = @verification_status_id,
                verification_reason = @reason
            WHERE
                finance.transaction_master.transaction_master_id = @transaction_master_id
            OR
                finance.transaction_master.cascading_tran_id = @transaction_master_id
            OR
            finance.transaction_master.transaction_master_id = @cascading_tran_id;


            IF(COALESCE(@cascading_tran_id, 0) = 0)
            BEGIN
                SELECT @cascading_tran_id = transaction_master_id
                FROM finance.transaction_master
                WHERE finance.transaction_master.cascading_tran_id = @transaction_master_id
                AND finance.transaction_master.deleted = 0;
            END;

            SELECT COALESCE(@cascading_tran_id, 0);
            RETURN;
            END
            ELSE
        BEGIN
            RAISERROR('Please ask someone else to verify your transaction.', 13, 1);
            END;
            END
            ELSE
    BEGIN
        RAISERROR('No verification policy found for this user.', 13, 1);
            END;

            SELECT 0;
            RETURN;
            END;

            GO
";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
