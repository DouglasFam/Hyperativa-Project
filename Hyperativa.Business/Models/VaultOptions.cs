using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa.Business.Models
{
    public class VaultOptions
    {
        public string Address { get; set; }
        public string Role { get; set; }

        public string Secret { get; set; }
        public string MountPath { get; set; }
        public string SecretType { get; set; }
    }
}
