using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class finance_20_05scrudviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"

IF OBJECT_ID('account.get_name_by_user_id') IS NOT NULL
DROP FUNCTION account.get_name_by_user_id;
GO

CREATE FUNCTION account.get_name_by_user_id(@user_id integer)
RETURNS national character varying(500)
AS
BEGIN
    RETURN
    (
		SELECT
			account.users.name
		FROM account.users
		WHERE account.users.user_id = @user_id
		AND account.users.deleted = 0
	);
END;

GO

IF OBJECT_ID('core.get_office_name_by_office_id') IS NOT NULL
DROP FUNCTION core.get_office_name_by_office_id;
GO

CREATE FUNCTION core.get_office_name_by_office_id(@office_id integer)
RETURNS national character varying(500)
AS
BEGIN
    RETURN 
	(
		SELECT core.offices.office_name
		FROM core.offices
		WHERE core.offices.office_id = @office_id
		AND core.offices.deleted = 0
	);
END;

GO
-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.scrud-views/finance.account_scrud_view.sql --<--<--
IF OBJECT_ID('finance.account_scrud_view') IS NOT NULL
DROP VIEW finance.account_scrud_view --CASCADE;

GO



CREATE VIEW finance.account_scrud_view
AS
SELECT
    finance.accounts.account_id,
    finance.account_masters.account_master_code + ' (' + finance.account_masters.account_master_name + ')' AS account_master,
    finance.accounts.account_number,
    finance.accounts.external_code,
    core.currencies.currency_code + ' ('+ core.currencies.currency_name+ ')' currency,
    finance.accounts.account_name,
    finance.accounts.description,
    finance.accounts.confidential,
    finance.accounts.is_transaction_node,
    finance.accounts.sys_type,
    finance.accounts.account_master_id,
    parent_account.account_number + ' (' + parent_account.account_name + ')' AS parent    
FROM finance.accounts
INNER JOIN finance.account_masters
ON finance.account_masters.account_master_id=finance.accounts.account_master_id
LEFT JOIN core.currencies
ON finance.accounts.currency_code = core.currencies.currency_code
LEFT JOIN finance.accounts parent_account
ON parent_account.account_id=finance.accounts.parent_account_id
WHERE finance.accounts.deleted = 0;


GO


-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/05.scrud-views/finance.auto_verification_policy_scrud_view.sql --<--<--
IF OBJECT_ID('finance.auto_verification_policy_scrud_view') IS NOT NULL
DROP VIEW finance.auto_verification_policy_scrud_view;

GO




CREATE VIEW finance.auto_verification_policy_scrud_view
AS
SELECT
    finance.auto_verification_policy.auto_verification_policy_id,
    finance.auto_verification_policy.user_id,
    account.get_name_by_user_id(finance.auto_verification_policy.user_id) AS [user],
    finance.auto_verification_policy.office_id,
    core.get_office_name_by_office_id(finance.auto_verification_policy.office_id) AS office,
    finance.auto_verification_policy.effective_from,
    finance.auto_verification_policy.ends_on,
    finance.auto_verification_policy.is_active
FROM finance.auto_verification_policy
WHERE finance.auto_verification_policy.deleted = 0;


            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.bank_account_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.bank_account_scrud_view') IS NOT NULL
                        DROP VIEW finance.bank_account_scrud_view;

            GO



            CREATE VIEW finance.bank_account_scrud_view
            AS
SELECT
    finance.bank_accounts.bank_account_id,
    finance.bank_accounts.account_id,
    account.users.name AS maintained_by,
    core.offices.office_code + '(' + core.offices.office_name + ')' AS office_name,
      finance.bank_accounts.bank_name,
    finance.bank_accounts.bank_branch,
    finance.bank_accounts.bank_contact_number,
    finance.bank_accounts.bank_account_number,
    finance.bank_accounts.bank_account_type,
    finance.bank_accounts.relationship_officer_name
FROM finance.bank_accounts
INNER JOIN account.users
ON finance.bank_accounts.maintained_by_user_id = account.users.user_id
INNER JOIN core.offices
ON finance.bank_accounts.office_id = core.offices.office_id
WHERE finance.bank_accounts.deleted = 0;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.cash_flow_heading_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.cash_flow_heading_scrud_view') IS NOT NULL
                        DROP VIEW finance.cash_flow_heading_scrud_view;

            GO



            CREATE VIEW finance.cash_flow_heading_scrud_view
            AS
SELECT
  finance.cash_flow_headings.cash_flow_heading_id, 
  finance.cash_flow_headings.cash_flow_heading_code, 
  finance.cash_flow_headings.cash_flow_heading_name, 
  finance.cash_flow_headings.cash_flow_heading_type, 
  finance.cash_flow_headings.is_debit, 
  finance.cash_flow_headings.is_sales, 
  finance.cash_flow_headings.is_purchase
FROM finance.cash_flow_headings
WHERE finance.cash_flow_headings.deleted = 0;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.cash_flow_setup_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.cash_flow_setup_scrud_view') IS NOT NULL
                        DROP VIEW finance.cash_flow_setup_scrud_view;

            GO



            CREATE VIEW finance.cash_flow_setup_scrud_view
            AS
SELECT
    finance.cash_flow_setup.cash_flow_setup_id, 
    finance.cash_flow_headings.cash_flow_heading_code + '(' + finance.cash_flow_headings.cash_flow_heading_name + ')' AS cash_flow_heading,
       finance.account_masters.account_master_code + '(' + finance.account_masters.account_master_name + ')' AS account_master
FROM finance.cash_flow_setup
INNER JOIN finance.cash_flow_headings
ON  finance.cash_flow_setup.cash_flow_heading_id = finance.cash_flow_headings.cash_flow_heading_id
INNER JOIN finance.account_masters
ON finance.cash_flow_setup.account_master_id = finance.account_masters.account_master_id
WHERE finance.cash_flow_setup.deleted = 0;


            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.cash_repository_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.cash_repository_scrud_view') IS NOT NULL
                        DROP VIEW finance.cash_repository_scrud_view;

            GO



            CREATE VIEW finance.cash_repository_scrud_view
            AS
SELECT
    finance.cash_repositories.cash_repository_id,
    core.offices.office_code + ' (' + core.offices.office_name + ') ' AS office,
    finance.cash_repositories.cash_repository_code,
    finance.cash_repositories.cash_repository_name,
    parent_cash_repository.cash_repository_code + ' (' + parent_cash_repository.cash_repository_name + ') ' AS parent_cash_repository,
    finance.cash_repositories.description
FROM finance.cash_repositories
INNER JOIN core.offices
ON finance.cash_repositories.office_id = core.offices.office_id
LEFT JOIN finance.cash_repositories AS parent_cash_repository
ON finance.cash_repositories.parent_cash_repository_id = parent_cash_repository.parent_cash_repository_id
WHERE finance.cash_repositories.deleted = 0;


            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.cost_center_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.cost_center_scrud_view') IS NOT NULL
                        DROP VIEW finance.cost_center_scrud_view;

            GO



            CREATE VIEW finance.cost_center_scrud_view
            AS
SELECT
    finance.cost_centers.cost_center_id,
    finance.cost_centers.cost_center_code,
    finance.cost_centers.cost_center_name
FROM finance.cost_centers
WHERE finance.cost_centers.deleted = 0;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.fiscal_year_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.fiscal_year_scrud_view') IS NOT NULL
                        DROP VIEW finance.fiscal_year_scrud_view;

            GO

            CREATE VIEW finance.fiscal_year_scrud_view
            AS
SELECT

    finance.fiscal_year.fiscal_year_id,
	finance.fiscal_year.fiscal_year_code,
	finance.fiscal_year.fiscal_year_name,
	finance.fiscal_year.starts_from,
	finance.fiscal_year.ends_on,
	finance.fiscal_year.eod_required,
	core.get_office_name_by_office_id(finance.fiscal_year.office_id) AS office
FROM finance.fiscal_year
WHERE finance.fiscal_year.deleted = 0;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.frequency_setup_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.frequency_setup_scrud_view') IS NOT NULL
                        DROP VIEW finance.frequency_setup_scrud_view;

            GO

            CREATE VIEW finance.frequency_setup_scrud_view
            AS
SELECT

    finance.frequency_setups.frequency_setup_id,
	finance.frequency_setups.fiscal_year_code,
	finance.frequency_setups.frequency_setup_code,
	finance.frequency_setups.value_date,
	finance.frequencies.frequency_code,
	core.get_office_name_by_office_id(finance.frequency_setups.office_id) AS office
FROM finance.frequency_setups
INNER JOIN finance.frequencies
ON finance.frequencies.frequency_id = finance.frequency_setups.frequency_id
WHERE finance.frequency_setups.deleted = 0;

            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.journal_verification_policy_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.journal_verification_policy_scrud_view') IS NOT NULL
                        DROP VIEW finance.journal_verification_policy_scrud_view;

            GO




            CREATE VIEW finance.journal_verification_policy_scrud_view
            AS
SELECT
    finance.journal_verification_policy.journal_verification_policy_id,
    finance.journal_verification_policy.user_id,
    account.get_name_by_user_id(finance.journal_verification_policy.user_id) AS [user],
    finance.journal_verification_policy.office_id,
    core.get_office_name_by_office_id(finance.journal_verification_policy.office_id) AS office,
    finance.journal_verification_policy.can_verify,
    finance.journal_verification_policy.can_self_verify,
    finance.journal_verification_policy.effective_from,
    finance.journal_verification_policy.ends_on,
    finance.journal_verification_policy.is_active
FROM finance.journal_verification_policy
WHERE finance.journal_verification_policy.deleted = 0;




            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.merchant_fee_setup_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.merchant_fee_setup_scrud_view') IS NOT NULL
                        DROP VIEW finance.merchant_fee_setup_scrud_view--CASCADE;

            GO



            CREATE VIEW finance.merchant_fee_setup_scrud_view
            AS
SELECT
    finance.merchant_fee_setup.merchant_fee_setup_id,
    finance.bank_accounts.bank_name + ' (' + finance.bank_accounts.bank_account_number + ')' AS merchant_account,
    finance.payment_cards.payment_card_code + ' ( ' + finance.payment_cards.payment_card_name + ')' AS payment_card,
     finance.merchant_fee_setup.rate,
    finance.merchant_fee_setup.customer_pays_fee,
    finance.accounts.account_number + ' (' + finance.accounts.account_name + ')' As account,
    finance.merchant_fee_setup.statement_reference
FROM finance.merchant_fee_setup
INNER JOIN finance.bank_accounts
ON finance.merchant_fee_setup.merchant_account_id = finance.bank_accounts.account_id
INNER JOIN
finance.payment_cards
ON finance.merchant_fee_setup.payment_card_id = finance.payment_cards.payment_card_id
INNER JOIN
finance.accounts
ON finance.merchant_fee_setup.account_id = finance.accounts.account_id
WHERE finance.merchant_fee_setup.deleted = 0;


            GO


            -- > --> --src / Frapid.Web / Areas / MixERP.Finance / db / SQL Server / 2.x / 2.0 / src / 05.scrud - views / finance.payment_card_scrud_view.sql-- < --< --
                        IF OBJECT_ID('finance.payment_card_scrud_view') IS NOT NULL
                        DROP VIEW finance.payment_card_scrud_view;

            GO



            CREATE VIEW finance.payment_card_scrud_view
            AS
SELECT
    finance.payment_cards.payment_card_id,
    finance.payment_cards.payment_card_code,
    finance.payment_cards.payment_card_name,
    finance.card_types.card_type_code + ' (' + finance.card_types.card_type_name + ')' AS card_type
FROM finance.payment_cards
INNER JOIN finance.card_types
ON finance.payment_cards.card_type_id = finance.card_types.card_type_id
WHERE finance.payment_cards.deleted = 0;


            GO



";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
