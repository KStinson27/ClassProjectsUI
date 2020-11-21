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

        public string Message = "Coming Soon";
        //Variables

        /*        [BindProperty]
                public double Fahrenheit { get; set; }

                public double celsius;

                public bool IsDegreeCalcVisible;
                public bool IsTaxCalcVisible;
                public bool IsTipCalcVisible;
                public bool IsSplitCalcVisible;

                [BindProperty]
                public int Selection {get; set;}

                public List<SelectListItem> Calculators { get; set; }


                public void OnGet()
                {
                    Calculators = new List<SelectListItem>
                    {
                        new SelectListItem {Value = "1", Text="Degree Conversion"},
                        new SelectListItem {Value = "2", Text="Tax Calculator"},
                        new SelectListItem {Value = "3", Text="Tip Calculator"},
                        new SelectListItem {Value = "4", Text="Split Bill Calculator"}
                    };*/

        //Commenting out for now. Question: How do I get fields to populate based on Selected ListItem
        /* switch (FormSelection)
         {
             case "DegreeCalc":
                 IsDegreeCalcVisible = true;
                 break;

             case "Tax":
                 IsTaxCalcVisible = true;
                 IsDegreeCalcVisible = false;
                 break;

             case "Tip":

                 IsTipCalcVisible = true;
                 IsDegreeCalcVisible = false;
                 break;

             case "BillSplit":
                 IsSplitCalcVisible = true;
                 IsDegreeCalcVisible = false;
                 break;

             default:
                 IsDegreeCalcVisible = false;
                 IsTaxCalcVisible = false;
                 IsTipCalcVisible = false;
                 IsSplitCalcVisible = false;
                 break;
         }



         //return FormSelection;
     }*/

        /*  public void OnPost()
          {
              if (Selection == 1)
              {
                  IsDegreeCalcVisible = true;
              }
              switch (Selection)
              {
                  case 1:
                      //temperatureFahrenheit = Int32.Parse(Console.ReadLine());
                      while (IsDegreeCalcVisible == true)
                          celsius = (Fahrenheit - 32) * 5 / 9;

                      break;

                  default:
                      break;
              }*/





    }
}


