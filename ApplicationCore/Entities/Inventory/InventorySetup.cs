using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities.Accounts;
using ApplicationCore.Entities.Finance;
using ApplicationCore.Entities.Core;
using ApplicationCore.Entities.Sales;

namespace ApplicationCore.Entities.Inventory
{
    public class InventorySetup
    {
        public int OfficeId { get; set; }
        public string InventorySystem { get; set; }
        public string CogsCalculationMethod { get; set; }
        public bool AllowMultipleOpeningInventory { get; set; }
        public int DefaultDiscountAccountId { get; set; }
        public bool? UsePosCheckoutScreen { get; set; }

        public Account DefaultDiscountAccount { get; set; }
        public Office Office { get; set; }
    }
}
