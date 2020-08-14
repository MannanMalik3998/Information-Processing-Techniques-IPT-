using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace k163620_Q6
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
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
        
        public string GetList()
        {
            Dictionary<string, double> oneDollar = OneDollarEquivalence();

            string list = "";

            foreach (KeyValuePair<string, double> currency in oneDollar)
            {
                list += String.Format("{0}{1} = 1$", currency.Value, currency.Key);
            }
            return list;
        }

        //b) A method to convert currency from one to another. Your method would include 3 parameters,
        //one for Source Currency, one for value to be converted, one for Destination Currency).

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
