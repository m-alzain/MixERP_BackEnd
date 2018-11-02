using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class finance_21update_05views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
IF OBJECT_ID('finance.verified_transaction_journal_view') IS NOT NULL
DROP VIEW finance.verified_transaction_journal_view;

GO

CREATE VIEW finance.verified_transaction_journal_view
AS
SELECT
    finance.verified_transaction_view.transaction_master_id,
    finance.verified_transaction_view.transaction_detail_id,
    finance.verified_transaction_view.account_id,
    finance.verified_transaction_view.account_name,
    CASE WHEN finance.verified_transaction_view.tran_type = 'Dr' THEN finance.verified_transaction_view.amount_in_local_currency ELSE 0 END AS dr,
    CASE WHEN finance.verified_transaction_view.tran_type = 'Cr' THEN finance.verified_transaction_view.amount_in_local_currency ELSE 0 END AS cr
FROM finance.verified_transaction_view;

GO

";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
