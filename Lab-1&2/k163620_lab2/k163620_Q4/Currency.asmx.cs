using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace k163620_Q4
{
    /// <summary>
    /// Summary description for Currency
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Currency : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        public Dictionary<String, double> OneDollarEquivalence()
        {
            Dictionary<String, double> oneDollar = new Dictionary<string, double>();
            oneDollar.Add("PKR", 154.96);
            oneDollar.Add("EUR", 0.89);
            oneDollar.Add("PND", 0.77);
            oneDollar.Add("YEN", 108.21);
            return oneDollar;
        }


        //a)Get List of all Currencies and their rates against 1 US Dollar.
        [WebMethod]
        public string GetList()
        {
            Dictionary<string, double> oneDollar = OneDollarEquivalence();

            string  list = "";

            foreach (KeyValuePair<string, double> currency in oneDollar)
            {
                list += String.Format("{0}{1} = 1$", currency.Value, currency.Key);
            }
            return list;
        }

        //b) A method to convert currency from one to another. Your method would include 3 parameters,
        //one for Source Currency, one for value to be converted, one for Destination Currency).

        [WebMethod]
        public double currencyConverter(double Amount, string convertFrom, string convertTo)
        {
            Dictionary<String, double> oneDollar = OneDollarEquivalence();

            //one dollar equivalence
            double source = oneDollar[convertFrom.ToUpper()];
            double dest = oneDollar[convertTo.ToUpper()];

            //convert source to dollars
            double oneDollarEquiv = Amount / source;

            

            return oneDollarEquiv * dest;

        }

    }
}
