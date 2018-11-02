using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class _20_02triggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.triggers/finance.check_parent_id_trigger.sql --<--<--


IF OBJECT_ID('finance.check_parent_id_trigger') IS NOT NULL
DROP TRIGGER finance.check_parent_id_trigger;

GO

CREATE TRIGGER finance.check_parent_id_trigger
ON finance.accounts 
AFTER UPDATE
AS
BEGIN
	DECLARE @account_id					bigint
	DECLARE @parent_account_id			bigint

	SELECT 
		@account_id						= account_id,
		@parent_account_id				= parent_account_id
	FROM INSERTED;

	IF (@account_id = @parent_account_id)
		RAISERROR('Account id and parent account id cannot be same', 16, 1)
	RETURN;
END;

GO



-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/02.triggers/finance.update_transaction_meta.sql --<--<--
IF OBJECT_ID('finance.update_transaction_meta_trigger') IS NOT NULL
DROP TRIGGER finance.update_transaction_meta_trigger;

GO

CREATE TRIGGER finance.update_transaction_meta_trigger
ON finance.transaction_master
AFTER INSERT
AS
BEGIN
    DECLARE @transaction_master_id          bigint;
    DECLARE @current_transaction_counter    integer;
    DECLARE @current_transaction_code       national character varying(50);
    DECLARE @value_date                     date;
    DECLARE @office_id                      integer;
    DECLARE @user_id                        integer;
    DECLARE @login_id                       bigint;


    SELECT
        @transaction_master_id                  = transaction_master_id,
        @current_transaction_counter            = transaction_counter,
        @current_transaction_code               = transaction_code,
        @value_date                             = value_date,
        @office_id                              = office_id,
        @user_id                                = [user_id],
        @login_id = login_id
    FROM INSERTED;

            IF(COALESCE(@current_transaction_code, '') = '')
    BEGIN
        UPDATE finance.transaction_master
        SET transaction_code = finance.get_transaction_code(@value_date, @office_id, @user_id, @login_id)
        WHERE transaction_master_id = @transaction_master_id;
            END;

            IF(COALESCE(@current_transaction_counter, 0) = 0)
    BEGIN
        UPDATE finance.transaction_master
        SET transaction_counter = finance.get_new_transaction_counter(@value_date)
        WHERE transaction_master_id = @transaction_master_id;
            END;

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
