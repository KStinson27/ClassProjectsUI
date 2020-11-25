using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace ClassProjectsUI.Pages.Admin
{
    [Authorize]
    public class Vacation_Budget_PlannerModel : PageModel
    {


        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string TravelLocation { get; set; }
        [BindProperty]
        public int TripLength { get; set; }
        [BindProperty]
        public decimal SpendingMoney { get; set; }

        public string money;
        public double perDiem;
        
        public decimal euroRate = OnGet(1);
        public decimal colRate = OnGet(2);
        public string perDiemConversion;
        public double hours;
        public double minutes;
        public double inCountryRate;
        public TimeSpan expand;

        CultureInfo eu = new CultureInfo("fr-FR");
        CultureInfo co = new CultureInfo("es-CO");



        public static decimal OnGet(int a)
          {
              var webRequest = WebRequest.Create("https://api.currencyfreaks.com/latest?apikey=b18b2da76e9a4749b187a39c606468df&symbols=EUR,USD,COP") as HttpWebRequest;

              webRequest.ContentType = "application/json";

              using (var s = webRequest.GetResponse().GetResponseStream())
              {
                  using (var sr = new StreamReader(s))
                  {
                      string currencyRatesAsJson = sr.ReadToEnd();

                      JObject currencyRates = JObject.Parse(currencyRatesAsJson);

                      decimal eurConversionRate = (decimal)currencyRates["rates"]["EUR"];
                      decimal copConversionRate = (decimal)currencyRates["rates"]["COP"];

                      //Console.WriteLine(currencyRates); //- test print of json
                      //Console.WriteLine(eurConversionRate); //- test print of euro rate
                      //Console.WriteLine(copConversionRate); //-test print of cop rate

                      if (a == 1)
                      {
                          return eurConversionRate;
                      }
                      else
                      {
                          return copConversionRate;
                      }

                  }

              }
          }

        
       
        public void OnPost()
        {
            money = SpendingMoney.ToString("C2");

            expand = TimeSpan.FromDays(TripLength);
            hours = expand.TotalHours;
            minutes = expand.TotalMinutes;

            if (TravelLocation == "Colombia")
            {
                perDiem = (double)(SpendingMoney / TripLength);
                inCountryRate = (double)(SpendingMoney * colRate) / TripLength;

                perDiemConversion = inCountryRate.ToString("c", co);

            }

            else if (TravelLocation == "Portugal")
            {
                perDiem = (double)(SpendingMoney / TripLength);
                inCountryRate = (double)(SpendingMoney * euroRate) / TripLength;

                perDiemConversion = inCountryRate.ToString("c", eu);

            }
            else
            {
                perDiem = 0;
                inCountryRate = 0;
                perDiemConversion = null;
            }

        }

    }
}


