using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class finance_20_03menus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
IF OBJECT_ID('core.create_menu2') IS NOT NULL
DROP PROCEDURE core.create_menu2;
GO

CREATE PROCEDURE core.create_menu2
(
    @sort                                       integer,
    @app_name                                   national character varying(100),
	@i18n_key									national character varying(200),
    @menu_name                                  national character varying(100),
    @url                                        national character varying(100),
    @icon                                       national character varying(100),
    @parent_menu_id                             integer
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @menu_id                            integer;
    
    IF EXISTS
    (
       SELECT 1
       FROM core.menus
       WHERE app_name = @app_name
       AND menu_name = @menu_name
    )
    BEGIN
        UPDATE core.menus
        SET
			i18n_key = @i18n_key,
            sort = @sort,
            url = @url,
            icon = @icon,
            parent_menu_id = @parent_menu_id
       WHERE app_name = @app_name
       AND menu_name = @menu_name;
       
		SELECT
			@menu_id = menu_id
		FROM core.menus
		WHERE app_name = @app_name
		AND menu_name = @menu_name;
    END
    ELSE
    BEGIN
        INSERT INTO core.menus(sort, app_name, i18n_key, menu_name, url, icon, parent_menu_id)
        SELECT @sort, @app_name, @i18n_key, @menu_name, @url, @icon, @parent_menu_id;
        
		SET @menu_id = SCOPE_IDENTITY();
    END;

    SELECT @menu_id;
END;
GO

IF OBJECT_ID('core.create_menu') IS NOT NULL
DROP PROCEDURE core.create_menu;
GO

CREATE PROCEDURE core.create_menu
(
    @app_name                                   national character varying(100),
	@i18n_key									national character varying(200),
    @menu_name                                  national character varying(100),
    @url                                        national character varying(100),
    @icon                                       national character varying(100),
    @parent_menu_name                           national character varying(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @parent_menu_id                     integer;

    SELECT @parent_menu_id = menu_id
    FROM core.menus
    WHERE menu_name = @parent_menu_name
    AND app_name = @app_name;
	
	PRINT @parent_menu_id;
	
    EXECUTE core.create_menu2 0, @app_name, @i18n_key, @menu_name, @url, @icon, @parent_menu_id;
END;
GO


DELETE FROM auth.menu_access_policy
WHERE menu_id IN
(
    SELECT menu_id FROM core.menus
    WHERE app_name = 'MixERP.Finance'
);

DELETE FROM auth.group_menu_access_policy
WHERE menu_id IN
(
    SELECT menu_id FROM core.menus
    WHERE app_name = 'MixERP.Finance'
);

DELETE FROM core.menus
WHERE app_name = 'MixERP.Finance';
GO

IF OBJECT_ID('core.create_app') IS NOT NULL
DROP PROCEDURE core.create_app;
GO

CREATE PROCEDURE core.create_app
(
    @app_name                                   national character varying(100),
	@i18n_key									national character varying(200),
    @name                                       national character varying(100),
    @version_number                             national character varying(100),
    @publisher                                  national character varying(100),
    @published_on                               date,
    @icon                                       national character varying(MAX),
    @landing_url                                national character varying(100),
    @dependencies                               national character varying(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF EXISTS
    (
        SELECT 1
        FROM core.apps
        WHERE LOWER(core.apps.app_name) = LOWER(@app_name)
    )
    BEGIN
        UPDATE core.apps
        SET
			i18n_key = @i18n_key,
            name = @name,
            version_number = @version_number,
            publisher = @publisher,
            published_on = @published_on,
            icon = @icon,
            landing_url = @landing_url
        WHERE
            app_name = @app_name;
    END
    ELSE
    BEGIN
        INSERT INTO core.apps(app_name, i18n_key, name, version_number, publisher, published_on, icon, landing_url)
        SELECT @app_name, @i18n_key, @name, @version_number, @publisher, @published_on, @icon, @landing_url;
    END;

    DELETE FROM core.app_dependencies
    WHERE app_name = @app_name;

	IF(ltrim(rtrim(COALESCE(@dependencies, ''))) != '')
	BEGIN
		INSERT INTO core.app_dependencies(app_name, depends_on)
		SELECT @app_name, member
		FROM core.array_split(@dependencies);
	END;
END;

GO

EXECUTE core.create_app 'MixERP.Finance', 'Finance', 'Finance', '1.0', 'MixERP Inc.', 'December 1, 2015', 'book red', '/dashboard/finance/tasks/journal/entry', NULL;

EXECUTE core.create_menu 'MixERP.Finance', 'Tasks', 'Tasks', '', 'lightning', '';
EXECUTE core.create_menu 'MixERP.Finance', 'JournalEntry', 'Journal Entry', '/dashboard/finance/tasks/journal/entry', 'add square', 'Tasks';
EXECUTE core.create_menu 'MixERP.Finance', 'ExchangeRates', 'Exchange Rates', '/dashboard/finance/tasks/exchange-rates', 'exchange', 'Tasks';
EXECUTE core.create_menu 'MixERP.Finance', 'JournalVerification', 'Journal Verification', '/dashboard/finance/tasks/journal/verification', 'checkmark', 'Tasks';
EXECUTE core.create_menu 'MixERP.Finance', 'VerificationPolicy', 'Verification Policy', '/dashboard/finance/tasks/verification-policy', 'checkmark box', 'Tasks';
EXECUTE core.create_menu 'MixERP.Finance', 'AutoVerificationPolicy', 'Auto Verification Policy', '/dashboard/finance/tasks/verification-policy/auto', 'check circle', 'Tasks';
EXECUTE core.create_menu 'MixERP.Finance', 'AccountReconciliation', 'Account Reconciliation', '/dashboard/finance/tasks/account-reconciliation', 'book', 'Tasks';
EXECUTE core.create_menu 'MixERP.Finance', 'EODProcessing', 'EOD Processing', '/dashboard/finance/tasks/eod-processing', 'spinner', 'Tasks';
EXECUTE core.create_menu 'MixERP.Finance', 'ImportTransactions', 'Import Transactions', '/dashboard/finance/tasks/import-transactions', 'upload', 'Tasks';

EXECUTE core.create_menu 'MixERP.Finance', 'Setup', 'Setup', 'square outline', 'configure', '';
EXECUTE core.create_menu 'MixERP.Finance', 'ChartOfAccounts', 'Chart of Accounts', '/dashboard/finance/setup/chart-of-accounts', 'sitemap', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'Currencies', 'Currencies', '/dashboard/finance/setup/currencies', 'dollar', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'BankAccounts', 'Bank Accounts', '/dashboard/finance/setup/bank-accounts', 'university', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'CashFlowHeadings', 'Cash Flow Headings', '/dashboard/finance/setup/cash-flow/headings', 'book', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'CashFlowSetup', 'Cash Flow Setup', '/dashboard/finance/setup/cash-flow/setup', 'edit', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'CostCenters', 'Cost Centers', '/dashboard/finance/setup/cost-centers', 'closed captioning', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'CashRepositories', 'Cash Repositories', '/dashboard/finance/setup/cash-repositories', 'bookmark', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'FiscalYears', 'Fiscal Years', '/dashboard/finance/setup/fiscal-years', 'sitemap', 'Setup';
EXECUTE core.create_menu 'MixERP.Finance', 'FrequencySetups', 'Frequency Setups', '/dashboard/finance/setup/frequency-setups', 'sitemap', 'Setup';

EXECUTE core.create_menu 'MixERP.Finance', 'Reports', 'Reports', '', 'block layout', '';
EXECUTE core.create_menu 'MixERP.Finance', 'AccountStatement', 'Account Statement', '/dashboard/reports/view/Areas/MixERP.Finance/Reports/AccountStatement.xml', 'file national character varying(1000) outline', 'Reports';
EXECUTE core.create_menu 'MixERP.Finance', 'TrialBalance', 'Trial Balance', '/dashboard/reports/view/Areas/MixERP.Finance/Reports/TrialBalance.xml', 'signal', 'Reports';
EXECUTE core.create_menu 'MixERP.Finance', 'TransactionSummary', 'Transaction Summary', '/dashboard/reports/view/Areas/MixERP.Finance/Reports/TransactionSummary.xml', 'signal', 'Reports';
EXECUTE core.create_menu 'MixERP.Finance', 'ProfitAndLossAccount', 'Profit & Loss Account', '/dashboard/finance/reports/pl-account', 'line chart', 'Reports';
EXECUTE core.create_menu 'MixERP.Finance', 'RetainedEarningsStatement', 'Retained Earnings Statement', '/dashboard/reports/view/Areas/MixERP.Finance/Reports/RetainedEarnings.xml', 'arrow circle down', 'Reports';
EXECUTE core.create_menu 'MixERP.Finance', 'BalanceSheet', 'Balance Sheet', '/dashboard/reports/view/Areas/MixERP.Finance/Reports/BalanceSheet.xml', 'calculator', 'Reports';
EXECUTE core.create_menu 'MixERP.Finance', 'CashFlow', 'Cash Flow', '/dashboard/finance/reports/cash-flow', 'crosshairs', 'Reports';
EXECUTE core.create_menu 'MixERP.Finance', 'ExchangeRateReport', 'Exchange Rate Report', '/dashboard/reports/view/Areas/MixERP.Finance/Reports/ExchangeRates.xml', 'options', 'Reports';

IF OBJECT_ID('core.get_office_id_by_office_name') IS NOT NULL
DROP FUNCTION core.get_office_id_by_office_name;
GO

CREATE FUNCTION core.get_office_id_by_office_name
(
	@office_name national character varying(100)
)
RETURNS integer
AS
BEGIN
    RETURN
    (
		SELECT core.offices.office_id
		FROM core.offices
		WHERE core.offices.office_name = @office_name
		AND core.offices.deleted = 0
    );
END;

GO

IF OBJECT_ID('core.split') IS NOT NULL
DROP FUNCTION core.split;
GO

CREATE FUNCTION [core].[split]
(
	@members national character varying(MAX)
)
RETURNS 
@split TABLE 
(
	member			national character varying(4000)
)
AS
BEGIN
	DECLARE @xml xml;
	
	SET @xml = N'<ss><s>' + replace(@members,',','</s><s>') + '</s></ss>'

	INSERT INTO @split
	SELECT r.value('.','national character varying(4000)')
	FROM @xml.nodes('//ss/s') as records(r)

	RETURN
END
GO

IF OBJECT_ID('auth.save_group_menu_policy') IS NOT NULL
DROP PROCEDURE auth.save_group_menu_policy;
GO

CREATE PROCEDURE auth.save_group_menu_policy
(
    @role_id        integer,
    @office_id      integer,
    @menu_ids       national character varying(MAX),
    @app_name       national character varying(500)
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

	DECLARE @menus	TABLE(menu_id integer);

    BEGIN TRY
        DECLARE @tran_count int = @@TRANCOUNT;
        
        IF(@tran_count= 0)
        BEGIN
            BEGIN TRANSACTION
        END;

    	INSERT INTO @menus
        SELECT CONVERT(integer, LTRIM(RTRIM(member)))
        FROM core.split(@menu_ids);    	
    	
        IF(@role_id IS NULL OR @office_id IS NULL)
        BEGIN
            RETURN;
        END;
        
        DELETE FROM auth.group_menu_access_policy
        WHERE auth.group_menu_access_policy.menu_id NOT IN(SELECT * from @menus)
        AND role_id = @role_id
        AND office_id = @office_id
        AND menu_id IN
        (
            SELECT menu_id
            FROM core.menus
            WHERE @app_name = ''
            OR app_name = @app_name
        );
        
        INSERT INTO auth.group_menu_access_policy(role_id, office_id, menu_id)
        SELECT @role_id, @office_id, menu_id
        FROM @menus
        WHERE menu_id NOT IN
        (
            SELECT menu_id
            FROM auth.group_menu_access_policy
            WHERE auth.group_menu_access_policy.role_id = @role_id
            AND auth.group_menu_access_policy.office_id = @office_id
        );

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

        DECLARE @ErrorMessage national character varying(4000)  = ERROR_MESSAGE();
        DECLARE @ErrorSeverity int                              = ERROR_SEVERITY();
        DECLARE @ErrorState int                                 = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;
GO

IF OBJECT_ID('auth.create_app_menu_policy') IS NOT NULL
DROP PROCEDURE auth.create_app_menu_policy;
GO

CREATE PROCEDURE auth.create_app_menu_policy
(
    @role_name                      national character varying(500),
    @office_id                      integer,
    @app_name                       national character varying(500),
    @menu_names                     national character varying(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @role_id                integer;
    DECLARE @menus					TABLE(menu_name national character varying(100));
    DECLARE @menu_ids               national character varying(MAX);

    BEGIN TRY
        DECLARE @tran_count int = @@TRANCOUNT;
        
        IF(@tran_count= 0)
        BEGIN
            BEGIN TRANSACTION
        END;

    	INSERT INTO @menus
        SELECT member
        FROM core.split(@menu_names);

        SELECT
            @role_id = role_id        
        FROM account.roles
        WHERE role_name = @role_name;

        IF(@menu_names = '{*}')
        BEGIN
            SELECT @menu_ids = COALESCE(@menu_ids + ',', '') + CONVERT(national character varying(500), menu_id)
            FROM core.menus
            WHERE app_name = @app_name;
        END
        ELSE
        BEGIN
            SELECT @menu_ids = COALESCE(@menu_ids + ',', '') + CONVERT(national character varying(500), menu_id)
            FROM core.menus
            WHERE app_name = @app_name
            AND menu_name IN (SELECT * FROM @menus);
        END;
        
        EXECUTE auth.save_group_menu_policy @role_id, @office_id, @menu_ids, @app_name;    

                
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

        DECLARE @ErrorMessage national character varying(4000)  = ERROR_MESSAGE();
        DECLARE @ErrorSeverity int                              = ERROR_SEVERITY();
        DECLARE @ErrorState int                                 = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;
GO

DECLARE @office_id integer = core.get_office_id_by_office_name('Default');
EXECUTE auth.create_app_menu_policy
'Admin', 
@office_id, 
'MixERP.Finance',
'{*}';


GO
";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
