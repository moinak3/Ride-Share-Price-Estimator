using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsAPI
{
    public class CabProvider
    {
        public string Name { get; set; }
        public double basePrice { get; set; }
        public double perminute { get; set; }
        public double perkm { get; set; }
        public double includedkm { get; set; }
        public double includedpermin { get; set; }
        public double minfare { get; set; }
        public CabProvider(string name, double basePrice, double perminute, double includedkm, double includedpermin, double perkm,
            double minfare)
        {
            this.Name = name;
            this.basePrice = basePrice;
            this.perminute = perminute;
            this.perkm = perkm;
            this.includedkm = includedkm;
            this.includedpermin = includedpermin;
            this.minfare = minfare;
        }

        public CabProvider ()
        {
            
        }

        public double overage(double total, double included)
        {
            if ((total - included) <= 0)
            {
                return 0.0;
            }
            else
            {
                return (total - included);
            }
        }

        public double getTotalRate(string name, double distance, double duration, double minFare)
        {
            double total = 0.0;
            double distanceTotal = 0.0;
            double durationTotal = 0.0;

            distanceTotal = (overage(distance, includedkm)*perkm); //Distance travelled over and above the included KM quantity multiplied by the per KM rate

            //Adding special logic to determine waiting time (NOT UBER, NOT OLA, NOT TAXI FOR SURE) as 50% of total trip duration and then capping duration total to INR 30 for all cabs and INR 45 for auto
            if (!(name.Contains("Uber") || name.Contains("Ola") || name.Contains("TaxiForSure")))
            {
                duration = duration/2; //Assumed waiting time being 50% of total duration
                if (name.Contains("KaliPeeli") && duration >= 60)
                {
                    durationTotal = 30;
                }
                else if (name.Contains("KaliPeeli") && duration < 60)
                {
                    durationTotal = (duration/60)*30;
                }
                else
                {
                    durationTotal = (overage(duration, includedpermin) * perminute);
                    if (name.Contains("Auto") && durationTotal > 45)
                    {
                        durationTotal = 45;
                    }
                    else if (name.Contains("Auto") && durationTotal < 45)
                    {
                        //no change
                    }
                    else
                    {
                        if (durationTotal > 30)
                        {
                            durationTotal = 30;
                        }
                    }
                }
           }
            else
            {
                durationTotal = (overage(duration, includedpermin) * perminute); //no max caps on duration total for Ola, Uber or TFS
            }

            total = basePrice + distanceTotal + durationTotal;

            if (total <= minFare)
            {
                total = minFare;
            }
            return total;
        }
    }
}
