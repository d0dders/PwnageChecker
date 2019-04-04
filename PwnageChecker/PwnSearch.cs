using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwnageChecker
{

    public class PwnSearch
    {
        [JsonProperty(PropertyName = "Property1")]
        public List<PwnResult> PwnResults { get; set; }
    }

    public class PwnResult
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string BreachDate { get; set; }
        public string AddedDate { get; set; }
        public string ModifiedDate { get; set; }
        public int PwnCount { get; set; }
        public string Description { get; set; }
        public string[] DataClasses { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Title: {1}, Domain: {2}, Breach Date: {3}, Added Date: {4}, Modified Date: {5}, Pwn Count: {6}, Description: {7}",
                Name, Title, Domain, BreachDate, AddedDate, ModifiedDate, PwnCount, Description);
        }
    }



}
