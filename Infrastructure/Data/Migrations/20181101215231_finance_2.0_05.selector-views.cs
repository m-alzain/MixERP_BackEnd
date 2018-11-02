using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class finance_20_05selectorviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.account_selector_view.sql --<--<--
IF OBJECT_ID('finance.account_selector_view') IS NOT NULL
DROP VIEW finance.account_selector_view;

GO



CREATE VIEW finance.account_selector_view
AS
SELECT
    finance.accounts.account_id,
    finance.accounts.account_number AS account_code,
    finance.accounts.account_name
FROM finance.accounts
WHERE finance.accounts.deleted = 0;


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.asset_selector_view.sql --<--<--
IF OBJECT_ID('finance.asset_selector_view') IS NOT NULL
DROP VIEW finance.asset_selector_view;

GO

CREATE VIEW finance.asset_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS asset_id,
    finance.account_scrud_view.account_name AS asset_name
FROM finance.account_scrud_view
WHERE account_master_id BETWEEN 10000 AND 14999;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.bank_account_selector_view.sql --<--<--
IF OBJECT_ID('finance.bank_account_selector_view') IS NOT NULL
DROP VIEW finance.bank_account_selector_view;

GO

CREATE VIEW finance.bank_account_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS bank_account_id,
    finance.account_scrud_view.account_name AS bank_account_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(10102));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.cash_account_selector_view.sql --<--<--
IF OBJECT_ID('finance.cash_account_selector_view') IS NOT NULL
DROP VIEW finance.cash_account_selector_view;

GO

CREATE VIEW finance.cash_account_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS cash_account_id,
    finance.account_scrud_view.account_name AS cash_account_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(10101));

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.cost_of_sale_selector_view.sql --<--<--
IF OBJECT_ID('finance.cost_of_sale_selector_view') IS NOT NULL
DROP VIEW finance.cost_of_sale_selector_view;

GO


CREATE VIEW finance.cost_of_sale_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS cost_of_sale_id,
    finance.account_scrud_view.account_name AS cost_of_sale_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20400));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.current_asset_selector_view.sql --<--<--
IF OBJECT_ID('finance.current_asset_selector_view') IS NOT NULL
DROP VIEW finance.current_asset_selector_view;

GO

CREATE VIEW finance.current_asset_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS current_asset_id,
    finance.account_scrud_view.account_name AS current_asset_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(10100));

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.current_liability_selector_view.sql --<--<--
IF OBJECT_ID('finance.current_liability_selector_view') IS NOT NULL
DROP VIEW finance.current_liability_selector_view;

GO


CREATE VIEW finance.current_liability_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS current_liability_id,
    finance.account_scrud_view.account_name AS current_liability_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(15000));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.direct_cost_selector_view.sql --<--<--
IF OBJECT_ID('finance.direct_cost_selector_view') IS NOT NULL
DROP VIEW finance.direct_cost_selector_view;

GO


CREATE VIEW finance.direct_cost_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS direct_cost_id,
    finance.account_scrud_view.account_name AS direct_cost_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20500));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.dividends_paid_selector_view.sql --<--<--
IF OBJECT_ID('finance.dividends_paid_selector_view') IS NOT NULL
DROP VIEW finance.dividends_paid_selector_view;

GO


CREATE VIEW finance.dividends_paid_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS dividends_paid_id,
    finance.account_scrud_view.account_name AS dividends_paid_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(15400));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.dividends_received_selector_view.sql --<--<--
IF OBJECT_ID('finance.dividends_received_selector_view') IS NOT NULL
DROP VIEW finance.dividends_received_selector_view;

GO


CREATE VIEW finance.dividends_received_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS dividends_received_id,
    finance.account_scrud_view.account_name AS dividends_received_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20301));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.expense_selector_view.sql --<--<--
IF OBJECT_ID('finance.expense_selector_view') IS NOT NULL
DROP VIEW finance.expense_selector_view;

GO

CREATE VIEW finance.expense_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS expense_id,
    finance.account_scrud_view.account_name AS expense_name
FROM finance.account_scrud_view
WHERE account_master_id > 20400;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.financial_expense_selector_view.sql --<--<--
IF OBJECT_ID('finance.financial_expense_selector_view') IS NOT NULL
DROP VIEW finance.financial_expense_selector_view;

GO


CREATE VIEW finance.financial_expense_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS financial_expense_id,
    finance.account_scrud_view.account_name AS financial_expense_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20700));

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.financial_income_selector_view.sql --<--<--
IF OBJECT_ID('finance.financial_income_selector_view') IS NOT NULL
DROP VIEW finance.financial_income_selector_view;

GO


CREATE VIEW finance.financial_income_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS financial_income_id,
    finance.account_scrud_view.account_name AS financial_income_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20300));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.fixed_asset_selector_view.sql --<--<--
IF OBJECT_ID('finance.fixed_asset_selector_view') IS NOT NULL
DROP VIEW finance.fixed_asset_selector_view;

GO



CREATE VIEW finance.fixed_asset_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS fixed_asset_id,
    finance.account_scrud_view.account_name AS fixed_asset_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(10200));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.income_selector_view.sql --<--<--
IF OBJECT_ID('finance.income_selector_view') IS NOT NULL
DROP VIEW finance.income_selector_view;

GO

CREATE VIEW finance.income_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS income_id,
    finance.account_scrud_view.account_name AS income_name
FROM finance.account_scrud_view
WHERE account_master_id BETWEEN 20100 AND 20399;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.income_tax_expense_selector_view.sql --<--<--
IF OBJECT_ID('finance.income_tax_expense_selector_view') IS NOT NULL
DROP VIEW finance.income_tax_expense_selector_view;

GO


CREATE VIEW finance.income_tax_expense_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS income_tax_expense_id,
    finance.account_scrud_view.account_name AS income_tax_expense_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20800));

GO



-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.interest_expense_selector_view.sql --<--<--
IF OBJECT_ID('finance.interest_expense_selector_view') IS NOT NULL
DROP VIEW finance.interest_expense_selector_view;

GO


CREATE VIEW finance.interest_expense_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS interest_expense_id,
    finance.account_scrud_view.account_name AS interest_expense_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20701));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.liability_selector_view.sql --<--<--
IF OBJECT_ID('finance.liability_selector_view') IS NOT NULL
DROP VIEW finance.liability_selector_view;

GO

CREATE VIEW finance.liability_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS liability_id,
    finance.account_scrud_view.account_name AS liability_name
FROM finance.account_scrud_view
WHERE account_master_id BETWEEN 15000 AND 19999;

GO

-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.long_term_liability_selector_view.sql --<--<--
IF OBJECT_ID('finance.long_term_liability_selector_view') IS NOT NULL
DROP VIEW finance.long_term_liability_selector_view;

GO


CREATE VIEW finance.long_term_liability_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS long_term_liability_id,
    finance.account_scrud_view.account_name AS long_term_liability_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(15100));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.non_operating_income_selector_view.sql --<--<--
IF OBJECT_ID('finance.non_operating_income_selector_view') IS NOT NULL
DROP VIEW finance.non_operating_income_selector_view;

GO


CREATE VIEW finance.non_operating_income_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS non_operating_income_id,
    finance.account_scrud_view.account_name AS non_operating_income_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20200));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.operating_expense_selector_view.sql --<--<--
IF OBJECT_ID('finance.operating_expense_selector_view') IS NOT NULL
DROP VIEW finance.operating_expense_selector_view;

GO


CREATE VIEW finance.operating_expense_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS operating_expense_id,
    finance.account_scrud_view.account_name AS operating_expense_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20600));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.other_asset_selector_view.sql --<--<--
IF OBJECT_ID('finance.other_asset_selector_view') IS NOT NULL
DROP VIEW finance.other_asset_selector_view;

GO


CREATE VIEW finance.other_asset_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS other_asset_id,
    finance.account_scrud_view.account_name AS other_asset_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(10300));



GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.payable_account_selector_view.sql --<--<--
IF OBJECT_ID('finance.payable_account_selector_view') IS NOT NULL
DROP VIEW finance.payable_account_selector_view;

GO



CREATE VIEW finance.payable_account_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS payable_account_id,
    finance.account_scrud_view.account_name AS payable_account_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(15010));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.property_plant_equipment_selector_view.sql --<--<--
IF OBJECT_ID('finance.property_plant_equipment_selector_view') IS NOT NULL
DROP VIEW finance.property_plant_equipment_selector_view;

GO


CREATE VIEW finance.property_plant_equipment_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS property_plant_equipment_id,
    finance.account_scrud_view.account_name AS property_plant_equipment_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(10201));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.receivable_account_selector_view.sql --<--<--
IF OBJECT_ID('finance.receivable_account_selector_view') IS NOT NULL
DROP VIEW finance.receivable_account_selector_view;

GO



CREATE VIEW finance.receivable_account_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS receivable_account_id,
    finance.account_scrud_view.account_name AS receivable_account_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(10110));

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.retained_earning_selector_view.sql --<--<--
IF OBJECT_ID('finance.retained_earning_selector_view') IS NOT NULL
DROP VIEW finance.retained_earning_selector_view;

GO


CREATE VIEW finance.retained_earning_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS retained_earning_id,
    finance.account_scrud_view.account_name AS retained_earning_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(15300));



GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.revenue_selector_view.sql --<--<--
IF OBJECT_ID('finance.revenue_selector_view') IS NOT NULL
DROP VIEW finance.revenue_selector_view;

GO


CREATE VIEW finance.revenue_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS revenue_id,
    finance.account_scrud_view.account_name AS revenue_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(20100));

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.salary_payable_selector_view.sql --<--<--
IF OBJECT_ID('finance.salary_payable_selector_view') IS NOT NULL
DROP VIEW finance.salary_payable_selector_view;

GO


CREATE VIEW finance.salary_payable_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS salary_payable_id,
    finance.account_scrud_view.account_name AS salary_payable_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(15011));


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.selector-views/finance.shareholders_equity_selector_view.sql --<--<--
IF OBJECT_ID('finance.shareholders_equity_selector_view') IS NOT NULL
DROP VIEW finance.shareholders_equity_selector_view;

GO


CREATE VIEW finance.shareholders_equity_selector_view
AS
SELECT 
    finance.account_scrud_view.account_id AS shareholders_equity_id,
    finance.account_scrud_view.account_name AS shareholders_equity_name
FROM finance.account_scrud_view
WHERE account_master_id IN(SELECT * FROM finance.get_account_master_ids(15200));


GO

";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
