using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class _20_02_functionsandlogic_logic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/logic/finance.create_payment_card.sql --<--<--
IF OBJECT_ID('finance.create_payment_card') IS NOT NULL
DROP PROCEDURE finance.create_payment_card;

GO

CREATE PROCEDURE finance.create_payment_card
(
    @payment_card_code      national character varying(12),
    @payment_card_name      national character varying(100),
    @card_type_id           integer
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS
    (
        SELECT * FROM finance.payment_cards
        WHERE payment_card_code = @payment_card_code
    )
    BEGIN
        INSERT INTO finance.payment_cards(payment_card_code, payment_card_name, card_type_id)
        SELECT @payment_card_code, @payment_card_name, @card_type_id;
    END
    ELSE
    BEGIN
        UPDATE finance.payment_cards
        SET 
            payment_card_code =     @payment_card_code, 
            payment_card_name =     @payment_card_name,
            card_type_id =          @card_type_id
        WHERE
            payment_card_code =     @payment_card_code;
    END;
END;

GO



-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/logic/finance.get_balance_sheet.sql --<--<--
IF OBJECT_ID('finance.get_balance_sheet_assets') IS NOT NULL
DROP FUNCTION finance.get_balance_sheet_assets;

GO

CREATE FUNCTION finance.get_balance_sheet_assets
(
    @previous_period                date,
    @current_period                 date,
    @user_id                        integer,
    @office_id                      integer,
    @factor                         integer
)
RETURNS @result TABLE
(
	account_id						integer,
	account_number					national character varying(200),
	account_name					national character varying(1000),
	account_master_id				integer,
	account_master_name				national character varying(1000),
	previous_period					numeric(30, 6),
	current_period					numeric(30, 6)
)
AS
BEGIN
    IF(COALESCE(@factor, 0) = 0)
	BEGIN
        SET @factor = 1;
    END;

	INSERT INTO @result(account_id)
	SELECT DISTINCT account_id
	FROM finance.verified_transaction_mat_view
    WHERE finance.verified_transaction_mat_view.account_master_id BETWEEN 10100 AND 10999;


    UPDATE @result 
    SET previous_period = trans.previous_period
    FROM @result AS result
    INNER JOIN
    (
        SELECT 
            result.account_id,         
            SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END) AS previous_period
        FROM @result AS result
        INNER JOIN finance.verified_transaction_mat_view
        ON finance.verified_transaction_mat_view.account_id = result.account_id
		WHERE value_date <=@previous_period
		AND office_id IN 
		(
			SELECT * FROM core.get_office_ids(@office_id)
		)
		GROUP BY result.account_id
    ) AS trans
    ON result.account_id = trans.account_id;

    UPDATE @result 
    SET current_period = trans.current_period
    FROM @result AS result
    INNER JOIN
    (
        SELECT 
            result.account_id,         
            SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END) AS current_period
        FROM @result AS result
        INNER JOIN finance.verified_transaction_mat_view
        ON finance.verified_transaction_mat_view.account_id = result.account_id
		WHERE value_date <=@current_period
		AND office_id IN 
		(
			SELECT * FROM core.get_office_ids(@office_id)
		)
		GROUP BY result.account_id
    ) AS trans
    ON result.account_id = trans.account_id;

	UPDATE @result
	SET 
		account_number = finance.accounts.account_number, 
		account_name = finance.accounts.account_name, 
		account_master_id = finance.accounts.account_master_id
	FROM @result AS result 
	INNER JOIN finance.accounts
	ON finance.accounts.account_id = result.account_id;

	UPDATE @result
	SET 
		account_master_name  = finance.account_masters.account_master_name
	FROM @result AS result 
	INNER JOIN finance.account_masters
	ON finance.account_masters.account_master_id = result.account_master_id;

	UPDATE @result
	SET 
		current_period = current_period / @factor,
		previous_period = previous_period / @factor;

	RETURN;
END

GO

--SELECT * FROM finance.get_balance_sheet_assets('3-14-2017', '1-1-2020', 1, 1, 1);

GO

IF OBJECT_ID('finance.get_balance_sheet_liabilities') IS NOT NULL
DROP FUNCTION finance.get_balance_sheet_liabilities;

GO

CREATE FUNCTION finance.get_balance_sheet_liabilities
(
    @previous_period                date,
    @current_period                 date,
    @user_id                        integer,
    @office_id                      integer,
    @factor                         integer
)
RETURNS @result TABLE
(
	account_id						integer,
	account_number					national character varying(200),
	account_name					national character varying(1000),
	account_master_id				integer,
	account_master_name				national character varying(1000),
	previous_period					numeric(30, 6),
	current_period					numeric(30, 6)
)
AS
BEGIN
    IF(COALESCE(@factor, 0) = 0)
	BEGIN
        SET @factor = 1;
    END;

	INSERT INTO @result(account_id)
	SELECT DISTINCT account_id
	FROM finance.verified_transaction_mat_view
    WHERE finance.verified_transaction_mat_view.account_master_id BETWEEN 15000 AND 15999
	AND finance.verified_transaction_mat_view.account_master_id NOT IN(15300, 15400); --EXCLUDE RETAINED EARNINGS


    UPDATE @result 
    SET previous_period = trans.previous_period
    FROM @result AS result
    INNER JOIN
    (
        SELECT 
            result.account_id,         
            SUM(CASE tran_type WHEN 'Cr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END) AS previous_period
        FROM @result AS result
        INNER JOIN finance.verified_transaction_mat_view
        ON finance.verified_transaction_mat_view.account_id = result.account_id
		WHERE value_date <=@previous_period
		AND office_id IN 
		(
			SELECT * FROM core.get_office_ids(@office_id)
		)
		GROUP BY result.account_id
    ) AS trans
    ON result.account_id = trans.account_id;

    UPDATE @result 
    SET current_period = trans.current_period
    FROM @result AS result
    INNER JOIN
    (
        SELECT 
            result.account_id,         
            SUM(CASE tran_type WHEN 'Cr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END) AS current_period
        FROM @result AS result
        INNER JOIN finance.verified_transaction_mat_view
        ON finance.verified_transaction_mat_view.account_id = result.account_id
		WHERE value_date <=@current_period
		AND office_id IN 
		(
			SELECT * FROM core.get_office_ids(@office_id)
		)
		GROUP BY result.account_id
    ) AS trans
    ON result.account_id = trans.account_id;

	UPDATE @result
	SET 
		account_number = finance.accounts.account_number, 
		account_name = finance.accounts.account_name, 
		account_master_id = finance.accounts.account_master_id
	FROM @result AS result 
	INNER JOIN finance.accounts
	ON finance.accounts.account_id = result.account_id;

	UPDATE @result
	SET 
		account_master_name  = finance.account_masters.account_master_name
	FROM @result AS result 
	INNER JOIN finance.account_masters
	ON finance.account_masters.account_master_id = result.account_master_id;

	UPDATE @result
	SET 
		current_period = current_period / @factor,
		previous_period = previous_period / @factor;

	RETURN;
END

GO

--SELECT * FROM finance.get_balance_sheet_liabilities('3-14-2017', '1-1-2020', 1, 1, 1);


GO

IF OBJECT_ID('finance.get_balance_sheet') IS NOT NULL
DROP FUNCTION finance.get_balance_sheet;

GO

CREATE FUNCTION finance.get_balance_sheet
(
    @previous_period                date,
    @current_period                 date,
    @user_id                        integer,
    @office_id                      integer,
    @factor                         integer
)
RETURNS @result TABLE
(
	account_id						integer,
	account_number					national character varying(200),
	account_name					national character varying(1000),
	account_master_id				integer,
	account_master_name				national character varying(1000),
	previous_period					numeric(30, 6),
	current_period					numeric(30, 6)
)
AS
BEGIN
	INSERT INTO @result
	SELECT * FROM finance.get_balance_sheet_assets(@previous_period, @current_period, @user_id, @office_id, @factor);

	INSERT INTO @result
	SELECT * FROM finance.get_balance_sheet_liabilities(@previous_period, @current_period, @user_id, @office_id, @factor);

	INSERT INTO @result(account_id, account_number, account_name, account_master_id, account_master_name, previous_period, current_period)
	SELECT NULL, '15300', account_master_name, 15999, account_master_name, finance.get_retained_earnings(@previous_period, @office_id, @factor), finance.get_retained_earnings(@current_period, @office_id, @factor)
	FROM finance.account_masters
	WHERE finance.account_masters.account_master_id = 15300;

	RETURN;
END;

GO

--SELECT * FROM finance.get_balance_sheet('3-14-2017', '1-1-2020', 1, 1, 1);


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.functions-and-logic/logic/finance.get_cash_flow_statement.sql --<--<--
IF OBJECT_ID('finance.get_cash_flow_statement') IS NOT NULL
DROP PROCEDURE finance.get_cash_flow_statement;

GO


CREATE PROCEDURE finance.get_cash_flow_statement
(
    @date_from                      date,
    @date_to                        date,
    @user_id                        integer,
    @office_id                      integer,
    @factor                         integer
)
AS
BEGIN    
	SET ANSI_WARNINGS OFF;
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @periods TABLE
	(
		id					integer IDENTITY,
		period_name			national character varying(1000),
		date_from			date,
		date_to				date
	);
	
	DECLARE @cursor					CURSOR;
	DECLARE @sql					national character varying(MAX);
	DECLARE @periods_csv			national character varying(MAX);
	DECLARE @period_name			national character varying(1000);
	DECLARE @period_from			date;
	DECLARE @period_to				date;
    DECLARE @balance                numeric(30, 6);
    DECLARE @is_periodic            bit = finance.is_periodic_inventory(@office_id);

    --We cannot divide by zero.
    IF(COALESCE(@factor, 0) = 0)
	BEGIN
        SET @factor = 1;
    END;

    CREATE TABLE #cf_temp
    (
        item_id                     integer PRIMARY KEY,
        item                        text,
        account_master_id           integer,
        parent_item_id              integer REFERENCES #cf_temp(item_id),
        is_summation                bit DEFAULT(0),
        is_debit                    bit DEFAULT(0),
        is_sales                    bit DEFAULT(0),
        is_purchase                 bit DEFAULT(0)
    );

	INSERT INTO @periods(period_name, date_from, date_to)
    SELECT * FROM finance.get_periods(@date_from, @date_to)
	ORDER BY date_from;

    IF NOT EXISTS(SELECT TOP 1 0 FROM @periods)
	BEGIN
        RAISERROR('Invalid period specified.', 13, 1);
		RETURN;
    END;

    /**************************************************************************************************************************************************************************************
        CREATING PERIODS
    **************************************************************************************************************************************************************************************/
	SET @cursor = CURSOR FOR 
	SELECT period_name FROM @periods
	ORDER BY id
	OPEN @cursor
	FETCH NEXT FROM @cursor INTO @period_name
	WHILE @@FETCH_STATUS = 0
	BEGIN
		 EXECUTE('ALTER TABLE #cf_temp ADD [' + @period_name + '] decimal(24, 4) DEFAULT(0);');


         FETCH NEXT FROM @cursor INTO @period_name;
            END
            CLOSE @cursor
            DEALLOCATE @cursor

            /**************************************************************************************************************************************************************************************
                CASHFLOW TABLE STRUCTURE START
            **************************************************************************************************************************************************************************************/
            INSERT INTO #cf_temp(item_id, item, is_summation, is_debit)
    SELECT  10000,  'Cash and cash equivalents, beginning of period',   0,	1   UNION ALL
    SELECT  20000,  'Cash flows from operating activities',             1,  0   UNION ALL
    SELECT  30000,  'Cash flows from investing activities',             1,  0   UNION ALL
    SELECT  40000,  'Cash flows from financing acticities',             1,  0   UNION ALL
    SELECT  50000,  'Net increase in cash and cash equivalents',        0,  0   UNION ALL
    SELECT  60000,  'Cash and cash equivalents, end of period',         0,  1;

            INSERT INTO #cf_temp(item_id, item, parent_item_id, is_debit, is_sales, is_purchase)
    SELECT cash_flow_heading_id, cash_flow_heading_name, 20000,  is_debit,   is_sales,   is_purchase FROM finance.cash_flow_headings WHERE cash_flow_heading_type = 'O' UNION ALL
    SELECT cash_flow_heading_id, cash_flow_heading_name, 30000,  is_debit,   is_sales,   is_purchase FROM finance.cash_flow_headings WHERE cash_flow_heading_type = 'I' UNION ALL
    SELECT cash_flow_heading_id, cash_flow_heading_name, 40000,  is_debit,   is_sales,   is_purchase FROM finance.cash_flow_headings WHERE cash_flow_heading_type = 'F';

            INSERT INTO #cf_temp(item_id, item, parent_item_id, is_debit, account_master_id)
    SELECT finance.account_masters.account_master_id + 50000, finance.account_masters.account_master_name,  finance.cash_flow_setup.cash_flow_heading_id, finance.cash_flow_headings.is_debit, finance.account_masters.account_master_id
    FROM finance.cash_flow_setup
    INNER JOIN finance.account_masters
    ON finance.cash_flow_setup.account_master_id = finance.account_masters.account_master_id
    INNER JOIN finance.cash_flow_headings
    ON finance.cash_flow_setup.cash_flow_heading_id = finance.cash_flow_headings.cash_flow_heading_id;

            /**************************************************************************************************************************************************************************************
                CASHFLOW TABLE STRUCTURE END
            **************************************************************************************************************************************************************************************/


            /**************************************************************************************************************************************************************************************
                ITERATING THROUGH PERIODS TO UPDATE TRANSACTION BALANCES
            **************************************************************************************************************************************************************************************/
            SET @cursor = CURSOR FOR
            SELECT period_name, date_from, date_to FROM @periods
            ORDER BY id

    OPEN @cursor

    FETCH NEXT FROM @cursor INTO @period_name, @period_from, @period_to

    WHILE @@FETCH_STATUS = 0

    BEGIN
        --
        --
        --Opening cash balance.
        --
        --
        SET @sql = 'UPDATE #cf_temp SET [' + @period_name + ']=
            (
                SELECT
                SUM(CASE tran_type WHEN ''Cr'' THEN amount_in_local_currency ELSE 0 END) -
                SUM(CASE tran_type WHEN ''Dr'' THEN amount_in_local_currency ELSE 0 END) AS total_amount
            FROM finance.verified_cash_transaction_mat_view
            WHERE account_master_id IN(10101, 10102)
            AND value_date < ''' + CAST(@period_from AS varchar) +
            ''' AND office_id IN (SELECT * FROM core.get_office_ids(' + CAST(@office_id AS varchar) + '))
            )
        WHERE #cf_temp.item_id = 10000;';

		--PRINT @sql;
            EXECUTE(@sql);

            --
            --
            --Updating debit balances of mapped account master heads.
    
            --
            --
        SET @sql = 'UPDATE #cf_temp SET [' + @period_name + ']=trans.total_amount
        FROM
        (
            SELECT finance.verified_cash_transaction_mat_view.account_master_id,
            SUM(CASE tran_type WHEN ''Dr'' THEN amount_in_local_currency ELSE 0 END) -
            SUM(CASE tran_type WHEN ''Cr'' THEN amount_in_local_currency ELSE 0 END) AS total_amount
        FROM finance.verified_cash_transaction_mat_view
        WHERE finance.verified_cash_transaction_mat_view.book NOT IN(''Sales.Direct'', ''Sales.Receipt'', ''Sales.Delivery'', ''Purchase.Direct'', ''Purchase.Receipt'')
        AND NOT account_master_id IN(10101, 10102)
        AND value_date >= ''' + CAST(@period_from AS varchar) + ''' AND value_date <= ''' + CAST(@period_to AS varchar)+
        ''' AND office_id IN (SELECT * FROM core.get_office_ids(' + CAST(@office_id AS varchar) + '))
        GROUP BY finance.verified_cash_transaction_mat_view.account_master_id
        ) AS trans
        WHERE trans.account_master_id = #cf_temp.account_master_id';

		--PRINT @sql;
            EXECUTE(@sql);

            --
            --
            --Updating cash paid to suppliers.
        --
        --
        SET @sql = 'UPDATE #cf_temp SET [' + @period_name + ']=

        (
            SELECT
            SUM(CASE tran_type WHEN ''Dr'' THEN amount_in_local_currency ELSE 0 END) -
            SUM(CASE tran_type WHEN ''Cr'' THEN amount_in_local_currency ELSE 0 END)
        FROM finance.verified_cash_transaction_mat_view
        WHERE finance.verified_cash_transaction_mat_view.book IN(''Purchase.Direct'', ''Purchase.Receipt'', ''Purchase.Payment'')
        AND NOT account_master_id IN(10101, 10102)
        AND value_date >= ''' + CAST(@period_from AS varchar) + ''' AND value_date <= ''' + CAST(@period_to AS varchar) +
        ''' AND office_id IN (SELECT * FROM core.get_office_ids(' + CAST(@office_id AS varchar) + '))
        )
        WHERE #cf_temp.is_purchase = 1;';

		--PRINT @sql;
            EXECUTE(@sql);

            --
            --
            --Updating cash received from customers.
    
            --
            --
            SET @sql = 'UPDATE #cf_temp SET [' + @period_name + ']=

            (
                SELECT
    
                SUM(CASE tran_type WHEN ''Cr'' THEN amount_in_local_currency ELSE 0 END) -
                SUM(CASE tran_type WHEN ''Dr'' THEN amount_in_local_currency ELSE 0 END)
    
            FROM finance.verified_cash_transaction_mat_view
    
            WHERE finance.verified_cash_transaction_mat_view.book IN(''Sales.Direct'', ''Sales.Receipt'', ''Sales.Delivery'')
    
            AND account_master_id IN(10101, 10102)
    
            AND value_date >= ''' + CAST(@period_from AS varchar) + ''' AND value_date <= ''' + CAST(@period_to AS varchar) +
    
            ''' AND office_id IN (SELECT * FROM core.get_office_ids(' + CAST(@office_id AS varchar) + '))
            )
        WHERE #cf_temp.is_sales = 1;';

		--PRINT @sql;
            EXECUTE(@sql);

            --Closing cash balance.
        SET @sql = 'UPDATE #cf_temp SET [' + @period_name + ']
        =
        (
            SELECT
            SUM(CASE tran_type WHEN ''Cr'' THEN amount_in_local_currency ELSE 0 END) -
            SUM(CASE tran_type WHEN ''Dr'' THEN amount_in_local_currency ELSE 0 END) AS total_amount
        FROM finance.verified_cash_transaction_mat_view
        WHERE account_master_id IN(10101, 10102) 
        AND value_date<''' + CAST(@period_to AS varchar) +
        ''' AND office_id IN (SELECT * FROM core.get_office_ids(' + CAST(@office_id AS varchar) + '))
        ) 
        WHERE #cf_temp.item_id = 60000;';

		--PRINT @sql;
            EXECUTE(@sql);

            --Reversing to debit balance for associated headings.

            SET @sql = 'UPDATE #cf_temp SET [' + @period_name + ']=[' + @period_name + ']*-1 WHERE is_debit=1;';

            --PRINT @sql;
            EXECUTE(@sql);
            FETCH NEXT FROM @cursor INTO @period_name, @period_from, @period_to;
            END
            CLOSE @cursor;
            DEALLOCATE @cursor;



            --Updating periodic balances on parent item by the sum of their respective child balances.
            SET @sql = 'UPDATE #cf_temp SET ';

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']=#cf_temp.[' + period_name + '] + [trans].[' + period_name + ']'   FROM @periods;

            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + ' FROM  (
        SELECT parent_item_id, ';


    SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM([' + period_name + ']) AS [' + period_name + ']'   FROM @periods;

            SET @sql = @sql + @periods_csv;
            SET @sql = @sql + 'FROM #cf_temp
        GROUP BY parent_item_id
    ) 
    AS trans
        WHERE trans.parent_item_id = #cf_temp.item_id
        AND #cf_temp.item_id NOT IN (10000, 60000);';

	--PRINT @sql;
            EXECUTE(@sql);


            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + '] = [trans].[' + period_name + ']' FROM @periods;

            SET @sql = 'UPDATE #cf_temp SET ';
            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + ' FROM 
            (
                SELECT
                    #cf_temp.parent_item_id,';
	
	SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM(CASE is_debit WHEN 1 THEN [' + period_name + '] ELSE [' + period_name + '] *-1 END) AS [' + period_name + ']'  FROM @periods;
            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + '
         FROM #cf_temp
         GROUP BY #cf_temp.parent_item_id
    ) 
    AS trans
    WHERE #cf_temp.item_id = trans.parent_item_id
    AND #cf_temp.parent_item_id IS NULL;';


    --PRINT @sql;
            EXECUTE(@sql);


            --Dividing by the factor.
            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + '] = [' + period_name + '] / ' + CAST(@factor AS varchar) + ''  FROM @periods;

            SET @sql = 'UPDATE #cf_temp SET ';
            SET @sql = @sql + @periods_csv;

            --PRINT @sql;
            EXECUTE(@sql);


            --Converting 0's to NULLS.

    SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + '] = CASE WHEN [' + period_name + '] = 0 THEN NULL ELSE [' + period_name + '] END'   FROM @periods;

            SET @sql = 'UPDATE #cf_temp SET ';
            SET @sql = @sql + @periods_csv;

            --PRINT @sql;
            EXECUTE(@sql);

            SET @sql = 'SELECT item, ';
            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']'   FROM @periods;
            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + ', is_summation FROM #cf_temp
        WHERE account_master_id IS NULL
        ORDER BY item_id; ';

     --PRINT @sql;
            EXECUTE(@sql);

            SET ANSI_WARNINGS ON;
            END

            GO


--EXECUTE finance.get_cash_flow_statement '1-1-2000','1-1-2020', 1, 1, 1;


            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / logic / finance.get_net_profit.sql-- < --< --
                       --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / logic / finance.get_net_profit.sql-- < --< --
                                  IF OBJECT_ID('finance.get_net_profit') IS NOT NULL
                                  DROP FUNCTION finance.get_net_profit;

            GO

            CREATE FUNCTION finance.get_net_profit
            (
                @date_from                      date,
                @date_to                        date,
                @office_id                      integer,
                @factor                         integer,
                @no_provison                    bit
            )
RETURNS numeric(30, 6)
AS
BEGIN
    DECLARE @incomes                numeric(30, 6) = 0;
            DECLARE @expenses               numeric(30, 6) = 0;
            DECLARE @profit_before_tax      numeric(30, 6) = 0;
            DECLARE @tax_paid               numeric(30, 6) = 0;
            DECLARE @tax_provison           numeric(30, 6) = 0;

            SELECT @incomes = SUM(CASE tran_type WHEN 'Cr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END)
    FROM finance.verified_transaction_mat_view
    WHERE value_date >= @date_from AND value_date <= @date_to
    AND office_id IN(SELECT * FROM core.get_office_ids(@office_id))
    AND account_master_id >= 20100
    AND account_master_id <= 20350;

            SELECT @expenses = SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END)
    FROM finance.verified_transaction_mat_view
    WHERE value_date >= @date_from AND value_date <= @date_to
    AND office_id IN(SELECT * FROM core.get_office_ids(@office_id))
    AND account_master_id >= 20400
    AND account_master_id <= 20701;

            SELECT @tax_paid = SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END)
    FROM finance.verified_transaction_mat_view
    WHERE value_date >= @date_from AND value_date <= @date_to
    AND office_id IN(SELECT * FROM core.get_office_ids(@office_id))
    AND account_master_id = 20800;

            SET @profit_before_tax = COALESCE(@incomes, 0) - COALESCE(@expenses, 0);

            IF(@no_provison = 1)
    BEGIN
        RETURN(@profit_before_tax - COALESCE(@tax_paid, 0)) / @factor;
            END;

            SET @tax_provison = finance.get_income_tax_provison_amount(@office_id, @profit_before_tax, COALESCE(@tax_paid, 0));

            RETURN(@profit_before_tax - (COALESCE(@tax_provison, 0) + COALESCE(@tax_paid, 0))) / @factor;
            END;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / logic / finance.get_profit_and_loss_statement.sql-- < --< --
                        IF OBJECT_ID('finance.get_profit_and_loss_statement') IS NOT NULL
                        DROP PROCEDURE finance.get_profit_and_loss_statement;

            GO

            CREATE PROCEDURE finance.get_profit_and_loss_statement
            (
                @date_from                      date,
                @date_to                        date,
                @user_id                        integer,
                @office_id                      integer,
                @factor                         integer,
                @compact                        bit = 0
            )
AS
BEGIN

    SET NOCOUNT ON;
            SET XACT_ABORT ON;

            DECLARE @periods TABLE
            (
                id                  integer IDENTITY,
                period_name         national character varying(1000),
                date_from           date,
                date_to             date
            );

            DECLARE @cursor                 CURSOR;
            DECLARE @sql                    national character varying(MAX);
            DECLARE @periods_csv            national character varying(MAX);
            DECLARE @period_name            national character varying(1000);
            DECLARE @period_from            date;
            DECLARE @period_to              date;
            DECLARE @balance                numeric(30, 6);
            DECLARE @is_periodic            bit = inventory.is_periodic_inventory(@office_id);
            DECLARE @profit                 numeric(30, 6);

            CREATE TABLE #pl_temp
    (
                item_id integer PRIMARY KEY,
                item text,
                account_id integer,
                parent_item_id integer REFERENCES #pl_temp(item_id),
        is_profit                   bit DEFAULT(0),
        is_summation bit DEFAULT(0),
        is_debit bit DEFAULT(0),
        amount                      decimal(24, 4) DEFAULT(0)
    );

            IF(COALESCE(@factor, 0) = 0)

    BEGIN
        SET @factor = 1;
            END;

            INSERT INTO @periods(period_name, date_from, date_to)
    SELECT* FROM finance.get_periods(@date_from, @date_to)

    ORDER BY date_from;

            IF NOT EXISTS(SELECT TOP 1 0 FROM @periods)

    BEGIN
        RAISERROR('Invalid period specified.', 13, 1);
            RETURN;
            END;

            SET @cursor = CURSOR FOR
            SELECT period_name FROM @periods
            ORDER BY id

    OPEN @cursor

    FETCH NEXT FROM @cursor INTO @period_name

    WHILE @@FETCH_STATUS = 0

    BEGIN

         EXECUTE('ALTER TABLE #pl_temp ADD [' + @period_name + '] decimal(24, 4) DEFAULT(0);');

            FETCH NEXT FROM @cursor INTO @period_name;
            END
            CLOSE @cursor;
            DEALLOCATE @cursor;


            --PL structure setup start
            INSERT INTO #pl_temp(item_id, item, is_summation, parent_item_id)
    SELECT 1000,   'Revenue',                      1,   NULL UNION ALL
 SELECT 2000,   'Cost of Sales',                1,   NULL UNION ALL
SELECT 2001,   'Opening Stock',                0,  1000     UNION ALL
    SELECT 3000,   'Purchases',                    0,  1000     UNION ALL
    SELECT 4000,   'Closing Stock',                0,  1000     UNION ALL
    SELECT 5000,   'Direct Costs',                 1,   NULL UNION ALL
 SELECT 6000,   'Gross Profit',                 0,  NULL UNION ALL
SELECT 7000,   'Operating Expenses',           1,   NULL UNION ALL
SELECT 8000,   'Operating Profit',             0,  NULL UNION ALL
SELECT 9000,   'Nonoperating Incomes',         1,   NULL UNION ALL
SELECT 10000,  'Financial Incomes',            1,   NULL UNION ALL
SELECT 11000,  'Financial Expenses',           1,   NULL UNION ALL
SELECT 11100,  'Interest Expenses',            1,   11000   UNION ALL
    SELECT 12000,  'Profit Before Income Taxes',   0,  NULL UNION ALL
SELECT 13000,  'Income Taxes',                 1,   NULL UNION ALL
SELECT 13001,  'Income Tax Provison',          0,  13000    UNION ALL
    SELECT 14000,  'Net Profit',                   1,   NULL;

            UPDATE #pl_temp SET is_debit = 1 WHERE item_id IN(2001, 3000, 4000);
    UPDATE #pl_temp SET is_profit = 1 WHERE item_id IN(6000,8000, 12000, 14000);
    
    INSERT INTO #pl_temp(item_id, account_id, item, parent_item_id, is_debit)
    SELECT id, account_id, account_name, 1000 as parent_item_id, 0 as is_debit FROM finance.get_account_view_by_account_master_id(20100, 1000) UNION ALL--Sales Accounts
    SELECT id, account_id, account_name, 2000 as parent_item_id, 1 as is_debit FROM finance.get_account_view_by_account_master_id(20400, 2001) UNION ALL--COGS Accounts
    SELECT id, account_id, account_name, 5000 as parent_item_id, 1 as is_debit FROM finance.get_account_view_by_account_master_id(20500, 5000) UNION ALL--Direct Cost
    SELECT id, account_id, account_name, 7000 as parent_item_id, 1 as is_debit FROM finance.get_account_view_by_account_master_id(20600, 7000) UNION ALL--Operating Expenses
    SELECT id, account_id, account_name, 9000 as parent_item_id, 0 as is_debit FROM finance.get_account_view_by_account_master_id(20200, 9000) UNION ALL--Nonoperating Incomes
    SELECT id, account_id, account_name, 10000 as parent_item_id, 0 as is_debit FROM finance.get_account_view_by_account_master_id(20300, 10000) UNION ALL--Financial Incomes
    SELECT id, account_id, account_name, 11000 as parent_item_id, 1 as is_debit FROM finance.get_account_view_by_account_master_id(20700, 11000) UNION ALL--Financial Expenses
    SELECT id, account_id, account_name, 11100 as parent_item_id, 1 as is_debit FROM finance.get_account_view_by_account_master_id(20701, 11100) UNION ALL--Interest Expenses
    SELECT id, account_id, account_name, 13000 as parent_item_id, 1 as is_debit FROM finance.get_account_view_by_account_master_id(20800, 13001); --Income Tax Expenses

    IF(@is_periodic = 0)

    BEGIN
        DELETE FROM #pl_temp WHERE item_id IN(2001, 3000, 4000);
    END;
            --PL structure setup end


            SET @cursor = CURSOR FOR
            SELECT period_name, date_from, date_to FROM @periods
            ORDER BY id

    OPEN @cursor

    FETCH NEXT FROM @cursor INTO @period_name, @period_from, @period_to

    WHILE @@FETCH_STATUS = 0

    BEGIN

        EXECUTE
        (
            'UPDATE #pl_temp SET [' + @period_name + ']=[trans].total_amount

            FROM
            (
                SELECT finance.verified_transaction_mat_view.account_id,
                SUM(CASE tran_type WHEN ''Cr'' THEN amount_in_local_currency ELSE 0 END) -
                SUM(CASE tran_type WHEN ''Dr'' THEN amount_in_local_currency ELSE 0 END) AS total_amount

            FROM finance.verified_transaction_mat_view

            WHERE value_date >= ''' + @period_from + ''' AND value_date <= ''' + @period_to +

            ''' AND office_id IN (SELECT * FROM core.get_office_ids(' + @office_id + '))

            GROUP BY finance.verified_transaction_mat_view.account_id
            ) AS trans

            WHERE [trans].account_id = #pl_temp.account_id'
		);

            --Updating credit balances of individual GL accounts.
        EXECUTE
        (
            'UPDATE #pl_temp SET [' + @period_name + ']=[trans].total_amount

            FROM
            (
                SELECT finance.verified_transaction_mat_view.account_id,
                SUM(CASE tran_type WHEN ''Cr'' THEN amount_in_local_currency ELSE 0 END) -
                SUM(CASE tran_type WHEN ''Dr'' THEN amount_in_local_currency ELSE 0 END) AS total_amount

            FROM finance.verified_transaction_mat_view

            WHERE value_date >= ''' + @period_from + ''' AND value_date <= ''' + @period_to +

            ''' AND office_id IN (SELECT * FROM core.get_office_ids(' + @office_id + '))

            GROUP BY finance.verified_transaction_mat_view.account_id
            ) AS trans

            WHERE [trans].account_id = #pl_temp.account_id'
		);

            --Reversing to debit balance for expense headings.

            EXECUTE('UPDATE #pl_temp SET [' + @period_name + ']=[' + @period_name + ']*-1 WHERE is_debit = 1;');

            --Getting purchase and stock balances if this is a periodic inventory system.
        --In perpetual accounting system, one would not need to include these headings
        --because the COGS A / C would be automatically updated on each transaction.
          IF(@is_periodic = 1)

        BEGIN
            SET @sql = 'UPDATE #pl_temp 

                SET [' + @period_name + '] = transactions.get_closing_stock(''' + CAST(DATEADD(DAY, -1, @period_from) AS varchar) +  ''', ' + @office_id + ')

                WHERE item_id = 2001; '


            EXECUTE(@sql);

            EXECUTE
            (
                'UPDATE #pl_temp 

                SET [' + @period_name + '] = transactions.get_purchase(''' + @period_from +  ''', ''' + @period_to + ''', ' + @office_id + ') * -1

                WHERE item_id = 3000; '
			);

            EXECUTE
            (
                'UPDATE #pl_temp 

                SET [' + @period_name + '] = transactions.get_closing_stock(''' + @period_from +  ''', ' + @office_id + ')

                WHERE item_id = 4000; '
			);
            END;

            FETCH NEXT FROM @cursor INTO @period_name, @period_from, @period_to;
            END
            CLOSE @cursor;
            DEALLOCATE @cursor;


            --Updating the column [amount] on each row by the sum of all periods.
            SELECT @periods_csv = COALESCE(@periods_csv + '+', '') + '[' + period_name + ']' FROM @periods;
            EXECUTE('UPDATE #pl_temp SET amount = ' + @periods_csv + ';');

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']= [trans].[' + period_name + ']' FROM @periods;

            --Updating amount and periodic balances on parent item by the sum of their respective child balances.
            SET @sql = 'UPDATE #pl_temp SET amount = [trans].amount, ' + @periods_csv +
            ' FROM 
            (
                SELECT parent_item_id,
                SUM(amount) AS amount, ';
        

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM([' + period_name + ']) AS [' + period_name + ']' FROM @periods;
            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + '
         FROM #pl_temp
        GROUP BY parent_item_id
    ) 
    AS trans
        WHERE [trans].parent_item_id = #pl_temp.item_id;'

	EXECUTE(@sql);

            --Updating Gross Profit.
    --Gross Profit = Revenue - (Cost of Sales +Direct Costs)
	SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']= [trans].[' + period_name + ']' FROM @periods;

            SET @sql = 'UPDATE #pl_temp SET amount = [trans].amount, ' + @periods_csv;
            SET @sql = @sql + ' FROM 
            (
                SELECT
        
                SUM(CASE item_id WHEN 1000 THEN amount ELSE amount * -1 END) AS amount, ';
        

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM(CASE item_id WHEN 1000 THEN [' + period_name + '] ELSE [' + period_name + '] *-1 END) AS [' + period_name + ']' FROM @periods;
            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + '
         FROM #pl_temp
         WHERE item_id IN
         (
             1000,2000,5000
         )
    ) 
    AS trans
    WHERE item_id = 6000; '

    EXECUTE(@sql);


            --Updating Operating Profit.
    --Operating Profit = Gross Profit - Operating Expenses
    SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']= [trans].[' + period_name + ']' FROM @periods;
            SET @sql = 'UPDATE #pl_temp SET amount = [trans].amount, ' + @periods_csv
            + ' FROM 
            (
                SELECT
        
                SUM(CASE item_id WHEN 6000 THEN amount ELSE amount * -1 END) AS amount, ';
        

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM(CASE item_id WHEN 6000 THEN [' + period_name + '] ELSE [' + period_name + '] *-1 END) AS [' + period_name + ']' FROM @periods;

            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + '
         FROM #pl_temp
         WHERE item_id IN
         (
             6000, 7000
         )
    ) 
    AS trans
    WHERE item_id = 8000; '


    EXECUTE(@sql);

            --Updating Profit Before Income Taxes.
    --Profit Before Income Taxes = Operating Profit + Nonoperating Incomes + Financial Incomes - Financial Expenses
    SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']= [trans].[' + period_name + ']' FROM @periods;

            SET @sql = 'UPDATE #pl_temp SET amount = [trans].amount, ' + @periods_csv
            + ' FROM 
            (
                SELECT
        
                SUM(CASE WHEN item_id IN(11000, 11100) THEN amount * -1 ELSE amount END) AS amount, ';
        

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM(CASE WHEN item_id IN(11000, 11100)  THEN [' + period_name + '] *-1 ELSE [' + period_name + '] END) AS [' + period_name + ']' FROM @periods;
            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + '
         FROM #pl_temp
         WHERE item_id IN
         (
             8000, 9000, 10000, 11000, 11100
         )
    ) 
    AS trans
    WHERE item_id = 12000; ';

    EXECUTE(@sql);

            --Updating Income Tax Provison.
        
            --Income Tax Provison = Profit Before Income Taxes* Income Tax Rate -Paid Income Taxes
	/******
		UPDATE pl_temp 
		SET 
			amount = finance.get_income_tax_provison_amount(1,-5300.000000,(SELECT amount FROM pl_temp WHERE item_id = 13000)),
			[Jul-Aug[=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Jul-Aug] FROM pl_temp WHERE item_id = 13000)),
			[Aug-Sep]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Aug-Sep] FROM pl_temp WHERE item_id = 13000)),
			[Sep-Oc]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Sep-Oc] FROM pl_temp WHERE item_id = 13000)),
			[Oct-Nov]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Oct-Nov] FROM pl_temp WHERE item_id = 13000)),
			[Nov-Dec]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Nov-Dec] FROM pl_temp WHERE item_id = 13000)),
			[Dec-Jan]=finance.get_income_tax_provison_amount(1,-5300.000000, (SELECT [Dec-Jan] FROM pl_temp WHERE item_id = 13000)),
			[Jan-Feb]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Jan-Feb] FROM pl_temp WHERE item_id = 13000)),
			[Feb-Mar]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Feb-Mar] FROM pl_temp WHERE item_id = 13000)),
			[Mar-Apr]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Mar-Apr] FROM pl_temp WHERE item_id = 13000)),
			[Apr-May]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Apr-May] FROM pl_temp WHERE item_id = 13000)),
			[May-Jun]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [May-Jun] FROM pl_temp WHERE item_id = 13000)),
			[Jun-Jul]=finance.get_income_tax_provison_amount(1,0.000000, (SELECT [Jun-Jul] FROM pl_temp WHERE item_id = 13000)) 
		WHERE item_id = 13001;
	******/

    SELECT @profit = COALESCE(amount, 0) FROM #pl_temp WHERE item_id = 12000;

    
    SET @sql = 'UPDATE #pl_temp SET amount = finance.get_income_tax_provison_amount(' + CAST(@office_id AS varchar) + ',' + CAST(@profit AS varchar) + ',(SELECT amount FROM #pl_temp WHERE item_id = 13000)), ';
            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + '] = finance.get_income_tax_provison_amount(1, ' + CAST(@profit AS varchar)
                            + ', (SELECT [' + period_name + '] FROM #pl_temp WHERE item_id = 13000))'  FROM @periods;

            SET @sql = @sql + @periods_csv;
            SET @sql = @sql + ' WHERE item_id = 13001;'

    EXECUTE(@sql);

            --Updating amount and periodic balances on parent item by the sum of their respective child balances, once again to add the Income Tax Provison to Income Tax Expenses.

    SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']= [trans].[' + period_name + ']' FROM @periods;
            SET @sql = 'UPDATE #pl_temp SET amount = [trans].amount, ' + @periods_csv
            + ' FROM 
            (
                SELECT parent_item_id,
                SUM(amount) AS amount, ';
        

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM([' + period_name + ']) AS [' + period_name + ']' FROM @periods;
            SET @sql = @sql + @periods_csv;
            SET @sql = @sql + '
         FROM #pl_temp
        GROUP BY parent_item_id
    ) 
    AS trans
        WHERE [trans].parent_item_id = #pl_temp.item_id;';

    EXECUTE(@sql);


            --Updating Net Profit.
    --Net Profit = Profit Before Income Taxes - Income Tax Expenses

    SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']= [trans].[' + period_name + ']' FROM @periods;
            SET @sql = 'UPDATE #pl_temp SET amount = [trans].amount, ' + @periods_csv
            + ' FROM 
            (
                SELECT
        
                SUM(CASE item_id WHEN 13000 THEN amount * -1 ELSE amount END) AS amount, ';
        

            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + 'SUM(CASE item_id WHEN 13000 THEN [' + period_name + '] *-1 ELSE [' + period_name + '] END) AS [' + period_name + ']' FROM @periods;
            SET @sql = @sql + @periods_csv;

            SET @sql = @sql + '
         FROM #pl_temp
         WHERE item_id IN
         (
             12000, 13000
         )
    ) 
    AS trans
    WHERE item_id = 14000; ';

    EXECUTE(@sql);

            --Removing ledgers having zero balances
    DELETE FROM #pl_temp
    WHERE COALESCE(amount, 0) = 0
    AND account_id IS NOT NULL;


            --Dividing by the factor.
            SET @sql = 'UPDATE #pl_temp SET amount = amount /' + CAST(@factor AS varchar) + ','

    SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + '] = [' + period_name + '] / ' + CAST(@factor AS varchar) FROM @periods;
            SET @sql = @sql + @periods_csv + ';';

            EXECUTE(@sql);


            --Converting 0's to NULLS.
    SET @sql = 'UPDATE #pl_temp SET amount = CASE WHEN amount = 0 THEN NULL ELSE amount END,';
            SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + '] = CASE WHEN [' + period_name + '] = 0 THEN NULL ELSE [' + period_name + '] END'  FROM @periods;
            SET @sql = @sql + @periods_csv;

            EXECUTE(@sql);


            IF(@compact = 1)

    BEGIN
        SELECT item, amount, is_profit, is_summation
        FROM #pl_temp
        ORDER BY item_id;
            END
            ELSE

    BEGIN
        SET @periods_csv = NULL;
            SELECT @periods_csv = COALESCE(@periods_csv + ',', '') + '[' + period_name + ']'  FROM @periods;
            SET @sql = 'SELECT item, amount,'
                + @periods_csv +
                ', is_profit, is_summation FROM #pl_temp
            ORDER BY item_id';

        EXECUTE(@sql);
            END;
            END

            GO

--EXECUTE finance.get_profit_and_loss_statement '1-1-2000', '1-1-2020', 1, 1, 1, 0;


            --> --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / logic / finance.get_retained_earnings.sql-- < --< --
                       IF OBJECT_ID('finance.get_retained_earnings') IS NOT NULL
                       DROP FUNCTION finance.get_retained_earnings;

            GO

            CREATE FUNCTION finance.get_retained_earnings
            (
                @date_to                        date,
                @office_id                      integer,
                @factor                         integer
            )
RETURNS numeric(30, 6)
AS
BEGIN
    DECLARE @date_from              date;
            DECLARE @net_profit             numeric(30, 6);
            DECLARE @paid_dividends         numeric(30, 6);

            IF(COALESCE(@factor, 0) = 0)
    BEGIN
        SET @factor = 1;
            END;

            SET @date_from = finance.get_fiscal_year_start_date(@office_id);
            SET @net_profit = finance.get_net_profit(@date_from, @date_to, @office_id, @factor, 1);

            SELECT
                @paid_dividends = COALESCE(SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE amount_in_local_currency * -1 END) / @factor, 0)
    FROM finance.verified_transaction_mat_view
    WHERE value_date <= @date_to
    AND account_master_id BETWEEN 15300 AND 15400
    AND office_id IN(SELECT * FROM core.get_office_ids(@office_id));

            RETURN @net_profit -@paid_dividends;
            END;


            GO

            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 02.functions - and - logic / logic / finance.get_trial_balance.sql-- < --< --
                        IF OBJECT_ID('finance.get_trial_balance') IS NOT NULL
                        DROP FUNCTION finance.get_trial_balance;

            GO

            CREATE FUNCTION finance.get_trial_balance
            (
                @date_from                      date,
                @date_to                        date,
                @user_id                        integer,
                @office_id                      integer,
                @compact                        bit,
                @factor                         numeric(30, 6),
                @change_side_when_negative      bit,
                @include_zero_balance_accounts  bit
            )
RETURNS @result TABLE
(
    id                      integer,
    account_id              integer,
    account_number          national character varying(24),
    account                 national character varying(1000),
    previous_debit          numeric(30, 6),
    previous_credit         numeric(30, 6),
    debit                   numeric(30, 6),
    credit                  numeric(30, 6),
    closing_debit           numeric(30, 6),
    closing_credit          numeric(30, 6)
)
AS

BEGIN
    IF(@date_from IS NULL)
    BEGIN
        SET @date_from = finance.get_fiscal_year_start_date(@office_id);
            --RAISERROR('Invalid date.', 13, 1);
            END;

            IF NOT EXISTS
            (
                SELECT 0 FROM core.offices
        
                WHERE office_id IN
                (
                    SELECT * FROM core.get_office_ids(@office_id)
                )
        
                HAVING count(DISTINCT currency_code) = 1
            )
    BEGIN
        --RAISERROR('Cannot produce trial balance of office(s) having different base currencies.', 13, 1);
            RETURN;
            END;

            DECLARE @trial_balance TABLE
            (
                id                      integer,
                account_id              integer,
                account_number national character varying(24),
                account                 national character varying(1000),
                previous_debit          numeric(30, 6),
                previous_credit         numeric(30, 6),
                debit                   numeric(30, 6),
                credit                  numeric(30, 6),
                closing_debit           numeric(30, 6),
                closing_credit          numeric(30, 6),
                root_account_id         integer,
                normally_debit          bit
            );

            DECLARE @summary_trial_balance TABLE
            (
                id                      integer,
                account_id              integer,
                account_number          national character varying(24),
                account                 national character varying(1000),
                previous_debit          numeric(30, 6),
                previous_credit         numeric(30, 6),
                debit                   numeric(30, 6),
                credit                  numeric(30, 6),
                closing_debit           numeric(30, 6),
                closing_credit          numeric(30, 6),
                root_account_id         integer,
                normally_debit          bit
            );

            INSERT INTO @trial_balance(account_id, previous_debit, previous_credit)
    SELECT
        verified_transaction_mat_view.account_id, 
        SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE 0 END),
        SUM(CASE tran_type WHEN 'Cr' THEN amount_in_local_currency ELSE 0 END)
    FROM finance.verified_transaction_mat_view
    WHERE value_date < @date_from
    AND office_id IN(SELECT * FROM core.get_office_ids(@office_id))
    GROUP BY verified_transaction_mat_view.account_id;

            IF(@date_to IS NULL)
    BEGIN
        INSERT INTO @trial_balance(account_id, debit, credit)
        SELECT
            verified_transaction_mat_view.account_id, 
            SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE 0 END),
            SUM(CASE tran_type WHEN 'Cr' THEN amount_in_local_currency ELSE 0 END)
        FROM finance.verified_transaction_mat_view
        WHERE value_date > @date_from
        AND office_id IN(SELECT * FROM core.get_office_ids(@office_id))
        GROUP BY verified_transaction_mat_view.account_id;
            END
            ELSE
    BEGIN
        INSERT INTO @trial_balance(account_id, debit, credit)
        SELECT
            verified_transaction_mat_view.account_id, 
            SUM(CASE tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE 0 END),
            SUM(CASE tran_type WHEN 'Cr' THEN amount_in_local_currency ELSE 0 END)
        FROM finance.verified_transaction_mat_view
        WHERE value_date >= @date_from AND value_date <= @date_to
        AND office_id IN(SELECT * FROM core.get_office_ids(@office_id))
        GROUP BY verified_transaction_mat_view.account_id;
            END;

            UPDATE @trial_balance SET root_account_id = finance.get_root_account_id(account_id, 0);


            IF(@compact = 1)
    BEGIN
        INSERT INTO @summary_trial_balance(account_id, account_number, account, previous_debit, previous_credit, debit, credit, closing_debit, closing_credit, normally_debit)
        SELECT
            temp_trial_balance.root_account_id AS account_id,
            '' as account_number,
            '' as account,
            SUM(temp_trial_balance.previous_debit) AS previous_debit,
            SUM(temp_trial_balance.previous_credit) AS previous_credit,
            SUM(temp_trial_balance.debit) AS debit,
            SUM(temp_trial_balance.credit) as credit,
            SUM(temp_trial_balance.closing_debit) AS closing_debit,
            SUM(temp_trial_balance.closing_credit) AS closing_credit,
            temp_trial_balance.normally_debit
        FROM @trial_balance AS temp_trial_balance
        GROUP BY
            temp_trial_balance.root_account_id,
            temp_trial_balance.normally_debit
        ORDER BY temp_trial_balance.normally_debit;
            END
            ELSE
    BEGIN
        INSERT INTO @summary_trial_balance(account_id, account_number, account, previous_debit, previous_credit, debit, credit, closing_debit, closing_credit, normally_debit)
        SELECT
            temp_trial_balance.account_id,
            '' as account_number,
            '' as account,
            SUM(temp_trial_balance.previous_debit) AS previous_debit,
            SUM(temp_trial_balance.previous_credit) AS previous_credit,
            SUM(temp_trial_balance.debit) AS debit,
            SUM(temp_trial_balance.credit) as credit,
            SUM(temp_trial_balance.closing_debit) AS closing_debit,
            SUM(temp_trial_balance.closing_credit) AS closing_credit,
            temp_trial_balance.normally_debit
        FROM @trial_balance AS temp_trial_balance
        GROUP BY
            temp_trial_balance.account_id,
            temp_trial_balance.normally_debit
        ORDER BY temp_trial_balance.normally_debit;
            END;

            UPDATE @summary_trial_balance
    SET
        account_number = finance.accounts.account_number,
        account = finance.accounts.account_name,
        normally_debit = finance.account_masters.normally_debit
    FROM @summary_trial_balance AS summary_trial_balance
    INNER JOIN finance.accounts
    INNER JOIN finance.account_masters
    ON finance.accounts.account_master_id = finance.account_masters.account_master_id
    ON summary_trial_balance.account_id = finance.accounts.account_id;

            UPDATE @summary_trial_balance SET
                closing_debit = COALESCE(previous_debit, 0) + COALESCE(debit, 0),
                closing_credit = COALESCE(previous_credit, 0) + COALESCE(credit, 0);



            UPDATE @summary_trial_balance SET previous_debit = COALESCE(previous_debit, 0) - COALESCE(previous_credit, 0), previous_credit = NULL WHERE normally_debit = 1;
            UPDATE @summary_trial_balance SET previous_credit = COALESCE(previous_credit, 0) - COALESCE(previous_debit, 0), previous_debit = NULL WHERE normally_debit = 0;

            UPDATE @summary_trial_balance SET debit = COALESCE(debit, 0) - COALESCE(credit, 0), credit = NULL WHERE normally_debit = 1;
            UPDATE @summary_trial_balance SET credit = COALESCE(credit, 0) - COALESCE(debit, 0), debit = NULL WHERE normally_debit = 0;

            UPDATE @summary_trial_balance SET closing_debit = COALESCE(closing_debit, 0) - COALESCE(closing_credit, 0), closing_credit = NULL WHERE normally_debit = 1;
            UPDATE @summary_trial_balance SET closing_credit = COALESCE(closing_credit, 0) - COALESCE(closing_debit, 0), closing_debit = NULL WHERE normally_debit = 0;


            IF(@include_zero_balance_accounts = 0)
    BEGIN
        DELETE FROM @summary_trial_balance WHERE COALESCE(closing_debit, 0) +COALESCE(closing_credit, 0) = 0;
            END;

            IF(@factor > 0)
    BEGIN
        UPDATE @summary_trial_balance SET previous_debit = previous_debit / @factor;
            UPDATE @summary_trial_balance SET previous_credit = previous_credit / @factor;
            UPDATE @summary_trial_balance SET debit = debit / @factor;
            UPDATE @summary_trial_balance SET credit = credit / @factor;
            UPDATE @summary_trial_balance SET closing_debit = closing_debit / @factor;
            UPDATE @summary_trial_balance SET closing_credit = closing_credit / @factor;
            END;

            --Remove Zeros
            UPDATE @summary_trial_balance SET previous_debit = NULL WHERE previous_debit = 0;
            UPDATE @summary_trial_balance SET previous_credit = NULL WHERE previous_credit = 0;
            UPDATE @summary_trial_balance SET debit = NULL WHERE debit = 0;
            UPDATE @summary_trial_balance SET credit = NULL WHERE credit = 0;
            UPDATE @summary_trial_balance SET closing_debit = NULL WHERE closing_debit = 0;
            UPDATE @summary_trial_balance SET closing_debit = NULL WHERE closing_credit = 0;

            IF(@change_side_when_negative = 1)
    BEGIN
        UPDATE @summary_trial_balance SET previous_debit = previous_credit * -1, previous_credit = NULL WHERE previous_credit< 0;
            UPDATE @summary_trial_balance SET previous_credit = previous_debit * -1, previous_debit = NULL WHERE previous_debit< 0;

            UPDATE @summary_trial_balance SET debit = credit * -1, credit = NULL WHERE credit< 0;
            UPDATE @summary_trial_balance SET credit = debit * -1, debit = NULL WHERE debit< 0;

            UPDATE @summary_trial_balance SET closing_debit = closing_credit * -1, closing_credit = NULL WHERE closing_credit< 0;
            UPDATE @summary_trial_balance SET closing_credit = closing_debit * -1, closing_debit = NULL WHERE closing_debit< 0;
            END;

            INSERT INTO @result
            SELECT
        row_number() OVER(ORDER BY normally_debit DESC, account_id) AS id,
        account_id,
        account_number,
        account,
        previous_debit,
        previous_credit,
        debit,
        credit,
        closing_debit,
        closing_credit
    FROM @summary_trial_balance;

            RETURN;
            END



            GO

--SELECT * FROM finance.get_trial_balance('1-1-2000', '1-1-2020', 1, 1, 1, 1, 1, 1) ORDER BY id;


            ";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
