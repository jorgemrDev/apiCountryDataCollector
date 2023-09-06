using System.Text.Json.Serialization;
using System.Transactions;

namespace ApiCountryDataCollector.Models
{
   public class Country
{
        public Name name { get; set; }

        public long population { get; set; }

        public string[] tld { get; set; }

        public bool independent { get; set; }

        public string status { get; set; }

        public bool snMember { get; set; }

        public string[] capital { get; set; }

        public string region { get; set; }

        public string subregion { get; set; }

        public double[] latlng { get; set; }
        public bool landlocked { get; set; }

        public string[] borders { get; set; }

        public double srea { get; set; }

        public string flag { get; set; }

        public string[] timezones { get; set; }

        public string[] continents { get; set; }

        public string startOfWeek { get; set; }

    }

    public class Name
    {
        public string common { get; set; }

    }
}
