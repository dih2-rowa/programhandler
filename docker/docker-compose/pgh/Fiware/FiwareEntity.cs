// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace Fiware
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        public string id { get; set; }
        // public string name { get; set; }
        public Temperature temperature { get; set; }
        public string type { get; set; }
    }

    public class Metadata
    {
    }

    public class Entity
    {
        public List<Data> data { get; set; }
         public string subscriptionId { get; set; }
    }

    public class Temperature
    {
        public Metadata metadata { get; set; }
        public string type { get; set; }
        public double value { get; set; }
    }


}
