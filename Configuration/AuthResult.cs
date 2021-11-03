using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _004_LukasHansel_FinalProject.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public List<string> Message { get; set; }
    }
}
