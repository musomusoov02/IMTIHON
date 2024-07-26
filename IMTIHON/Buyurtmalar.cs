using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMTIHON
{
    public class Buyurtmalar
    {
        public int id { get; set; }
        public string name { get; set; }
        List<Kategoriyalar> kategoriyalarssss { get; set; } = new List<Kategoriyalar>();
    }
}
