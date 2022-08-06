using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPSR
{
    public class ModelLogin
    {
        public class ARCRequest
        {
            public int ClaveUsuario { get; set; }
            public int ClaveAplicacion { get; set; }
            public int ClaveBuzon { get; set; }
        }
        public class LoginRequest
        {
            public string IDI { get; set; }
            public string UserID { get; set; }
            public string UserPW { get; set; }
        }
    }
}
