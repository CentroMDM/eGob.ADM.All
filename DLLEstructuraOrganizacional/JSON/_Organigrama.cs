using System.Collections.Generic;
using Newtonsoft.Json;

namespace EntitiesPSR
{
    public class OrganigramaViejo
    {
        public string name { get; set; }
        public string title { get; set; }
        [JsonIgnore]
        public long identificador { get; set; }
        public List<OrganigramaViejo> children { get; set; }
    }
}
