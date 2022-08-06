using System.Collections.Generic;
using Newtonsoft.Json;

namespace DLLEstructuraOrganizacional
{
    public class Organigrama
    {
        public string name { get; set; }
        public string title { get; set; }
        [JsonIgnore]
        public long identificador { get; set; }
        public List<Organigrama> children { get; set; }
    }
}
