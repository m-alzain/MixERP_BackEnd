using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class finance_20_99sampledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
insert into core.offices(office_code, office_name, allow_transaction_posting, currency_code)
values('DEF', 'Default', 1, 'USA')

-->-->-- src/Frapid.Web/Areas/MixERP.Finance/db/SQL Server/2.x/2.0/src/99.sample-data/00.default-values.sample.sql --<--<--
SET NOCOUNT ON;

/*
IMPORTANT:
The table account_masters must only be translated, but not changed.        
*/
UPDATE core.offices
SET allow_transaction_posting = 1;


/*
IMPORTANT:
The table cash_flow_headings must only be translated, but not changed.        
*/
INSERT INTO finance.cash_flow_headings(cash_flow_heading_id, cash_flow_heading_code, cash_flow_heading_name, cash_flow_heading_type, is_debit,is_sales, is_purchase)
SELECT 20001, 'CRC',    'Cash Receipts from Customers',                 'O',   1, 1, 0    UNION ALL
SELECT 20002, 'CPS',    'Cash Paid to Suppliers',                       'O',   0, 0, 1   UNION ALL
SELECT 20003, 'CPE',    'Cash Paid to Employees',                       'O',   0, 0, 0   UNION ALL
SELECT 20004, 'IP',     'Interest Paid',                                'O',   0, 0, 0   UNION ALL
SELECT 20005, 'ITP',    'Income Taxes Paid',                            'O',   0, 0, 0   UNION ALL
SELECT 20006, 'SUS',    'Against Suspense Accounts',                    'O',   1, 0, 0   UNION ALL
SELECT 30001, 'PSE',    'Proceeds from the Sale of Equipment',          'I',   1, 0, 0    UNION ALL
SELECT 30002, 'DR',     'Dividends Received',                           'I',   1, 0, 0    UNION ALL
SELECT 40001, 'DP',     'Dividends Paid',                               'F',   0, 0, 0;

UPDATE finance.cash_flow_headings SET is_sales= 1 WHERE cash_flow_heading_code='CRC';
UPDATE finance.cash_flow_headings SET is_purchase= 1 WHERE cash_flow_heading_code='CPS';

/*
IMPORTANT:
The table cash_flow_setup must only be translated, but not changed.
*/
INSERT INTO finance.cash_flow_setup(cash_flow_heading_id, account_master_id)
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('CRC'), finance.get_account_master_id_by_account_master_code('ACR') UNION ALL --Cash Receipts from Customers/Accounts Receivable
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('CPS'), finance.get_account_master_id_by_account_master_code('ACP') UNION ALL --Cash Paid to Suppliers/Accounts Payable
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('CPE'), finance.get_account_master_id_by_account_master_code('SAP') UNION ALL --Cash Paid to Employees/Salary Payable
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('IP'),  finance.get_account_master_id_by_account_master_code('INT') UNION ALL --Interest Paid/Interest Expenses
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('ITP'), finance.get_account_master_id_by_account_master_code('ITX') UNION ALL --Income Taxes Paid/Income Tax Expenses
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('PSE'), finance.get_account_master_id_by_account_master_code('PPE') UNION ALL --Proceeds from the Sale of Equipment/Property, Plants, and Equipments
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('DR'),  finance.get_account_master_id_by_account_master_code('DIR') UNION ALL --Dividends Received/Dividends Received
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('DP'),  finance.get_account_master_id_by_account_master_code('DIP') UNION ALL --Dividends Paid/Dividends Paid

--We cannot guarantee that every transactions posted is 100% correct and falls under the above-mentioned categories.
--The following is the list of suspense accounts, cash entries posted directly against all other account masters.
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('BSA') UNION ALL --Against Suspense Accounts/Balance Sheet A/C
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('PLA') UNION ALL --Against Suspense Accounts/Profit & Loss A/C
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('CRA') UNION ALL --Against Suspense Accounts/Current Assets
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('FIA') UNION ALL --Against Suspense Accounts/Fixed Assets
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('OTA') UNION ALL --Against Suspense Accounts/Other Assets
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('CRL') UNION ALL --Against Suspense Accounts/Current Liabilities
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('LTL') UNION ALL --Against Suspense Accounts/Long-Term Liabilities
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('SHE') UNION ALL --Against Suspense Accounts/Shareholders' Equity
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('RET') UNION ALL --Against Suspense Accounts/Retained Earning
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('REV') UNION ALL --Against Suspense Accounts/Revenue
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('NOI') UNION ALL --Against Suspense Accounts/Non Operating Income
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('FII') UNION ALL --Against Suspense Accounts/Financial Incomes
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('COS') UNION ALL --Against Suspense Accounts/Cost of Sales
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('DRC') UNION ALL --Against Suspense Accounts/Direct Costs
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('ORX') UNION ALL --Against Suspense Accounts/Operating Expenses
SELECT finance.get_cash_flow_heading_id_by_cash_flow_heading_code('SUS'), finance.get_account_master_id_by_account_master_code('FIX');          --Against Suspense Accounts/Financial Expenses


INSERT INTO finance.cost_centers(cost_center_code, cost_center_name)
SELECT 'DEF', 'Default'                             UNION ALL
SELECT 'GEN', 'General Administration'              UNION ALL
SELECT 'HUM', 'Human Resources'                     UNION ALL
SELECT 'SCC', 'Support & Customer Care'             UNION ALL
SELECT 'GAE', 'Guest Accomodation & Entertainment'  UNION ALL
SELECT 'MKT', 'Marketing & Promotion'               UNION ALL
SELECT 'SAL', 'Sales & Billing'                     UNION ALL
SELECT 'FIN', 'Finance & Accounting';

INSERT INTO finance.cash_repositories(office_id, cash_repository_code, cash_repository_name)
SELECT core.get_office_id_by_office_name('Default'), 'CAC', 'Cash in Counter' UNION ALL
SELECT core.get_office_id_by_office_name('Default'), 'CAV', 'Cash in Vault';

INSERT INTO finance.journal_verification_policy(user_id, office_id, can_verify, verification_limit, can_self_verify, self_verification_limit, effective_from, ends_on, is_active)
SELECT
    account.users.user_id,
    core.offices.office_id,
    1,
    0,
    1,
    0,
    '1-1-2000',
    '1-1-2100',
    1
FROM account.users
CROSS JOIN core.offices
WHERE account.users.role_id = 9999;

INSERT INTO finance.auto_verification_policy(user_id, office_id, verification_limit, effective_from, ends_on, is_active)
SELECT
    account.users.user_id,
    core.offices.office_id,
    0,
    '1-1-2000',
    '1-1-2100',
    1
FROM account.users
CROSS JOIN core.offices
WHERE account.users.role_id = 9999;

INSERT INTO finance.fiscal_year (fiscal_year_code, fiscal_year_name, starts_from, ends_on, office_id) 
VALUES ('FY1617', 'FY 2016/2017', '2016-07-17', '2017-07-16', core.get_office_id_by_office_name('Default'));

INSERT INTO finance.frequency_setups (fiscal_year_code, frequency_setup_code, value_date, frequency_id, office_id) 
SELECT 'FY1617', 'Jul-Aug', '2016-08-16', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Aug-Sep', '2016-09-16', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Sep-Oc',  '2016-10-17', 3, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Oct-Nov', '2016-11-16', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Nov-Dec', '2016-12-15', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Dec-Jan', '2017-01-14', 4, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Jan-Feb', '2017-02-12', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Feb-Mar', '2017-03-14', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Mar-Apr', '2017-04-13', 3, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Apr-May', '2017-05-14', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'May-Jun', '2017-06-15', 2, core.get_office_id_by_office_name('Default') UNION ALL
SELECT 'FY1617', 'Jun-Jul', '2017-07-16', 5, core.get_office_id_by_office_name('Default');

INSERT INTO finance.tax_setups(office_id, income_tax_rate, income_tax_account_id, sales_tax_rate, sales_tax_account_id)
SELECT office_id, 25, finance.get_account_id_by_account_number('20770'), 13, finance.get_account_id_by_account_number('20710')
FROM core.offices;


EXECUTE finance.create_card_type 1, 'CRC', 'Credit Card';
EXECUTE finance.create_card_type 2, 'DRC', 'Debit Card';
EXECUTE finance.create_card_type 3, 'CHC', 'Charge Card';
EXECUTE finance.create_card_type 4, 'ATM', 'ATM Card';
EXECUTE finance.create_card_type 5, 'SVC', 'Store-value Card';
EXECUTE finance.create_card_type 6, 'FLC', 'Fleet Card';
EXECUTE finance.create_card_type 7, 'GFC', 'Gift Card';
EXECUTE finance.create_card_type 8, 'SCR', 'Scrip';
EXECUTE finance.create_card_type 9, 'ELP', 'Electronic Purse';


EXECUTE finance.create_payment_card 'CR-VSA', 'Visa',                1;
EXECUTE finance.create_payment_card 'CR-AME', 'American Express',    1;
EXECUTE finance.create_payment_card 'CR-MAS', 'MasterCard',          1;
EXECUTE finance.create_payment_card 'DR-MAE', 'Maestro',             2;
EXECUTE finance.create_payment_card 'DR-MAS', 'MasterCard Debit',    2;
EXECUTE finance.create_payment_card 'DR-VSE', 'Visa Electron',       2;
EXECUTE finance.create_payment_card 'DR-VSD', 'Visa Debit',          2;
EXECUTE finance.create_payment_card 'DR-DEL', 'Delta',               2;


--ROLLBACK TRANSACTION;


GO

";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
