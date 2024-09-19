using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Nurse : ModelBase
    {
        public string Password { get; set; } = null!;
        public string Theme { get; set; } = null!;
        public string Language { get; set; } = null!;

    }
}
