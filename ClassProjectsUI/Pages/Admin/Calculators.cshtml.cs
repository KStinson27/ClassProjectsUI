using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassProjectsUI.Pages.Admin
{
    [Authorize]
    public class CalculatorsModel : PageModel
    {
        [BindProperty]
        public decimal ProductPrice { get; set; }
        [BindProperty]
        public decimal StateTax { get; set; }
        [BindProperty]
        public decimal SalesTax { get; set; }

        [BindProperty]
        public string Selection { get; set; }

        public decimal total;
        public decimal stateTaxConversion;

        [BindProperty]
        public double TemperatureFahrenheit { get; set; }
        public double temperatureCelsius;

        [BindProperty]
        public decimal TipAmount { get; set; }

        [BindProperty]
        public decimal BillTotal { get; set; }

        public decimal tipOwed;

        public decimal tipPercentage;

        [BindProperty]
        public decimal GroupBillTotal { get; set; }
        [BindProperty]
        public decimal Contributors { get; set; }

        public decimal individualContributorTotal;

        public string selection;
        public string Message;


        public void OnPostTemp()
        {
            selection = "temp";
            temperatureCelsius = (TemperatureFahrenheit - 32) * 5 / 9;

            Message = temperatureCelsius.ToString() + "° Celsius";
        }

        public void OnPostTax()
        {
            selection = "tax";

            stateTaxConversion = StateTax / 100;
            SalesTax = (stateTaxConversion * ProductPrice);

            total = SalesTax + ProductPrice;

            Message = "Your total is: $" + Decimal.Round(total);

        }

        public void OnPostTip()
        {
            selection = "tip";
            tipPercentage = TipAmount / 100;

            tipOwed = BillTotal * tipPercentage;

            Message = "You would owe $" + Decimal.Round(tipOwed) + " as a tip";
        }

        public void OnPostSplit()
        {
            selection = "split";

            individualContributorTotal = GroupBillTotal / Contributors;

            Message = "Each person needs to pay $" + Decimal.Round(individualContributorTotal);

        }
    }

}
