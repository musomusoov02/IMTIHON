using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMTIHON
{
    public class Attach
    {
        public int id { get; set; }
        public int IdKAKategoriya { get; set; }
        public string NameKategoriya { get; set; }
        public Kategoriyalar KategoriyaAttach { get; set; }
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public Product ProductAttach { get; set; }
        public List<Product> Productssss { get; set; }= new List<Product>();
    }
}
