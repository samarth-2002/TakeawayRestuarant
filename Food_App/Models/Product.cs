using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_App.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductTypeID { get; set; }
        public decimal Rate { get; set; }
        public string ProductImage { get; set; }

    }
}
