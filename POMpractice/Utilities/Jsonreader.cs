using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMpractice.Utilities
{
    public class Jsonreader
    {
        public Jsonreader()
        {
            
        }
        public string ExtractData(string tokenName)
        {
           string Jasonfille = File.ReadAllText("Utilities/TestData.json");
           var datainjason = JToken.Parse(Jasonfille);
            return datainjason.SelectToken(tokenName).Value<string>();

        }
    }
}
