using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Linq.Expressions;
using Newtonsoft.Json;
using System;
using System.Collections;


namespace GoogleMapsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string source = GoogleLocationFormatter(args[0]);
            string destination = GoogleLocationFormatter(args[1]);
            List<CabProvider> providerList = new List<CabProvider>();
            double distance = 0.0;
            double duration = 0.0;

            string provider = "UberX";

            CabProvider UberX = new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(UberX);

            provider = "UberGo";
            CabProvider UberGo= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(UberGo);

            provider = "UberBlack";
            CabProvider UberBlack= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(UberBlack);

            provider = "OlaPrime";
            CabProvider OlaPrime= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(OlaPrime);

            provider = "OlaMini";
            CabProvider OlaMini= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(OlaMini);

            provider = "OlaEconomySedan";
            CabProvider OlaEconomySedan= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(OlaEconomySedan);



            provider = "MeruCabsDayTime";
            CabProvider MeruCabsDayTime= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(MeruCabsDayTime);



            provider = "MeruCabsNightTime";
            CabProvider MeruCabsNightTime= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(MeruCabsNightTime);



            provider = "EasyCabsDayTime";
            CabProvider EasyCabsDayTime= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(EasyCabsDayTime);

            provider = "EasyCabsNightTime";
            CabProvider EasyCabsNightTime= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(EasyCabsNightTime);


            provider = "MeruFlexi";
            CabProvider MeruFlexi= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(MeruFlexi);


            provider = "GenieDay";
            CabProvider GenieDay= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(GenieDay);

            provider = "GenieNight";
            CabProvider GenieNight= new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM",provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum",provider)])
                );
            providerList.Add(GenieNight);


            provider = "TaxiForSure_Hatchback";
            CabProvider TaxiForSure_Hatchback = new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum", provider)])
                );
            providerList.Add(TaxiForSure_Hatchback);

            provider = "TaxiForSure_Sedan";
            CabProvider TaxiForSure_Sedan = new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum", provider)])
                );
            providerList.Add(TaxiForSure_Sedan);

            provider = "TaxiForSure_SUV";
            CabProvider TaxiForSure_SUV = new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum", provider)])
                );
            providerList.Add(TaxiForSure_SUV);

            provider = "KaliPeeli";
            CabProvider KaliPeeli = new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum", provider)])
                );
            providerList.Add(KaliPeeli);

            provider = "AutoRickshaw";
            CabProvider AutoRickshaw = new CabProvider(
                provider,
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Base", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerMinute", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-IncludedMin", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-PerKM", provider)]),
                Convert.ToDouble(ConfigurationManager.AppSettings[String.Format("{0}-Minimum", provider)])
                );
            providerList.Add(AutoRickshaw);



            string requestURL = String.Format("{0}origins={1}&destinations={2}&key={3}",
             ConfigurationManager.AppSettings["GoogleDistanceUrl"],
             source,
             destination,
             ConfigurationManager.AppSettings["key"]);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);


            try
            {
                // Call the REST endpoint
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var usageResponse = readStream.ReadToEnd();

                DistanceMatrixPayload payload = JsonConvert.DeserializeObject<DistanceMatrixPayload>(usageResponse);

                distance = Convert.ToDouble(payload.rows[0].elements[0].distance.value)/1000;
                duration = Convert.ToDouble(payload.rows[0].elements[0].duration.value)/60;


                Console.WriteLine("Total Distance for trip:   " +distance +" km");
                Console.WriteLine("Total Estimated Duration for trip:    " + duration +" mins");
                Console.WriteLine();
                response.Close();
                readStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("{0} \n\n{1}", e.Message, e.InnerException != null ? e.InnerException.Message : ""));
                Console.ReadLine();
            }
            CabProvider cheapestOption = new CabProvider();
            double cheapestRate = double.MaxValue;
            foreach (CabProvider providerInstance in providerList)
            {
                Console.WriteLine(String.Format("Cost for {0}: {1}",providerInstance.Name, providerInstance.getTotalRate(providerInstance.Name,distance,duration, providerInstance.minfare)));
                if (providerInstance.getTotalRate(providerInstance.Name, distance, duration, providerInstance.minfare) <= cheapestRate)
                {
                    cheapestOption = providerInstance;
                    cheapestRate = providerInstance.getTotalRate(providerInstance.Name, distance, duration, providerInstance.minfare);
                }
            }
            Console.WriteLine();
            Console.WriteLine(String.Format("Cheapest option for {0}:INR  {1}", cheapestOption.Name, cheapestRate));
        }

        public static string GoogleLocationFormatter(string input)
        {
            int len = input.Length;
            string result = "";

            for (int i = 0; i < len; i++)
            {
                if (input[i] == ' ')
                {
                    result = result + '+';
                }
                else
                {
                    result = result + input[i];
                }
            }
            return result;
        }
    }


    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public List<Element> elements { get; set; }
    }

    public class DistanceMatrixPayload
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }
    }
}
