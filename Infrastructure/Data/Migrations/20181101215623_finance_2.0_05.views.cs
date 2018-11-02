using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class finance_20_05views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"

-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/0. finance.transaction_view.sql --<--<--
IF OBJECT_ID('finance.transaction_view') IS NOT NULL
DROP VIEW finance.transaction_view;

GO


CREATE VIEW finance.transaction_view
AS
SELECT
    finance.transaction_master.transaction_master_id,
    finance.transaction_master.transaction_counter,
    finance.transaction_master.transaction_code,
    finance.transaction_master.book,
    finance.transaction_master.value_date,
    finance.transaction_master.transaction_ts,
    finance.transaction_master.login_id,
    finance.transaction_master.user_id,
    finance.transaction_master.office_id,
    finance.transaction_master.cost_center_id,
    finance.transaction_master.reference_number,
    finance.transaction_master.statement_reference AS master_statement_reference,
    finance.transaction_master.last_verified_on,
    finance.transaction_master.verified_by_user_id,
    finance.transaction_master.verification_status_id,
    finance.transaction_master.verification_reason,
    finance.transaction_details.transaction_detail_id,
    finance.transaction_details.tran_type,
    finance.transaction_details.account_id,
    finance.accounts.account_number,
    finance.accounts.account_name,
    finance.account_masters.normally_debit,
    finance.account_masters.account_master_code,
    finance.account_masters.account_master_name,
    finance.accounts.account_master_id,
    finance.accounts.confidential,
    finance.transaction_details.statement_reference,
    finance.transaction_details.cash_repository_id,
    finance.transaction_details.currency_code,
    finance.transaction_details.amount_in_currency,
    finance.transaction_details.local_currency_code,
    finance.transaction_details.amount_in_local_currency
FROM finance.transaction_master
INNER JOIN finance.transaction_details
ON finance.transaction_master.transaction_master_id = finance.transaction_details.transaction_master_id
INNER JOIN finance.accounts
ON finance.transaction_details.account_id = finance.accounts.account_id
INNER JOIN finance.account_masters
ON finance.accounts.account_master_id = finance.account_masters.account_master_id
WHERE finance.transaction_master.deleted = 0;




GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/1. finance.verified_transaction_view.sql --<--<--
IF OBJECT_ID('finance.verified_transaction_view') IS NOT NULL
DROP VIEW finance.verified_transaction_view --CASCADE;

GO



CREATE VIEW finance.verified_transaction_view
AS
SELECT * FROM finance.transaction_view
WHERE verification_status_id > 0;


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/2.finance.verified_transaction_mat_view.sql --<--<--
IF OBJECT_ID('finance.verified_transaction_mat_view') IS NOT NULL
DROP VIEW finance.verified_transaction_mat_view--CASCADE;

GO

CREATE  VIEW finance.verified_transaction_mat_view
AS
SELECT * FROM finance.verified_transaction_view;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/3. finance.verified_cash_transaction_mat_view.sql --<--<--
IF OBJECT_ID('finance.verified_cash_transaction_mat_view') IS NOT NULL
DROP VIEW finance.verified_cash_transaction_mat_view;

GO

CREATE VIEW finance.verified_cash_transaction_mat_view
AS
SELECT * FROM finance.verified_transaction_mat_view
WHERE finance.verified_transaction_mat_view.transaction_master_id
IN
(
    SELECT finance.verified_transaction_mat_view.transaction_master_id 
    FROM finance.verified_transaction_mat_view
    WHERE account_master_id IN(10101, 10102) --Cash and Bank A/C
);

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/finance.account_view.sql --<--<--
IF OBJECT_ID('finance.account_view') IS NOT NULL
DROP VIEW finance.account_view;

GO



CREATE VIEW finance.account_view
AS
SELECT
    finance.accounts.account_id,
    finance.accounts.account_number + ' (' + finance.accounts.account_name + ')' AS account,
    finance.accounts.account_number,
    finance.accounts.account_name,
    finance.accounts.description,
    finance.accounts.external_code,
    finance.accounts.currency_code,
    finance.accounts.confidential,
    finance.account_masters.normally_debit,
    finance.accounts.is_transaction_node,
    finance.accounts.sys_type,
    finance.accounts.parent_account_id,
    parent_accounts.account_number AS parent_account_number,
    parent_accounts.account_name AS parent_account_name,
    parent_accounts.account_number + ' (' + parent_accounts.account_name + ')' AS parent_account,
    finance.account_masters.account_master_id,
    finance.account_masters.account_master_code,
    finance.account_masters.account_master_name,
    finance.has_child_accounts(finance.accounts.account_id) AS has_child
FROM finance.account_masters
INNER JOIN finance.accounts 
ON finance.account_masters.account_master_id = finance.accounts.account_master_id
LEFT OUTER JOIN finance.accounts AS parent_accounts 
ON finance.accounts.parent_account_id = parent_accounts.account_id
WHERE finance.account_masters.deleted = 0;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/finance.frequency_dates.sql --<--<--
IF OBJECT_ID('finance.frequency_date_view') IS NOT NULL
DROP VIEW finance.frequency_date_view;

GO



CREATE VIEW finance.frequency_date_view
AS
SELECT 
    office_id AS office_id, 
    finance.get_value_date(office_id) AS today, 
    finance.is_new_day_started(office_id) as new_day_started,
    finance.get_month_start_date(office_id) AS month_start_date,
    finance.get_month_end_date(office_id) AS month_end_date, 
    finance.get_quarter_start_date(office_id) AS quarter_start_date, 
    finance.get_quarter_end_date(office_id) AS quarter_end_date, 
    finance.get_fiscal_half_start_date(office_id) AS fiscal_half_start_date, 
    finance.get_fiscal_half_end_date(office_id) AS fiscal_half_end_date, 
    finance.get_fiscal_year_start_date(office_id) AS fiscal_year_start_date, 
    finance.get_fiscal_year_end_date(office_id) AS fiscal_year_end_date 
FROM core.offices;


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/finance.transaction_verification_status_view.sql --<--<--
IF OBJECT_ID('finance.transaction_verification_status_view') IS NOT NULL
DROP VIEW finance.transaction_verification_status_view;

GO

CREATE VIEW finance.transaction_verification_status_view
AS
SELECT
    finance.transaction_master.transaction_master_id,
    finance.transaction_master.user_id,
    finance.transaction_master.office_id,
    finance.transaction_master.verification_status_id, 
    account.get_name_by_user_id(finance.transaction_master.verified_by_user_id) AS verifier_name,
    finance.transaction_master.verified_by_user_id,
    finance.transaction_master.last_verified_on, 
    finance.transaction_master.verification_reason
FROM finance.transaction_master;

GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.views/finance.trial_balance_view.sql --<--<--
IF OBJECT_ID('finance.trial_balance_view') IS NOT NULL
DROP VIEW finance.trial_balance_view;

GO

CREATE VIEW finance.trial_balance_view
AS
SELECT finance.get_account_name_by_account_id(account_id) AS account, 
    SUM(CASE finance.verified_transaction_view.tran_type WHEN 'Dr' THEN amount_in_local_currency ELSE NULL END) AS debit,
    SUM(CASE finance.verified_transaction_view.tran_type WHEN 'Cr' THEN amount_in_local_currency ELSE NULL END) AS Credit
FROM finance.verified_transaction_view
GROUP BY account_id;

GO

";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
