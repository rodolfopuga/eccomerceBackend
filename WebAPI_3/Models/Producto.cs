using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_3.Models
{
    public class Producto
    {
        [Key]
        public string pro_id { get; set; }

        public string pro_nombre { get; set; }

        public string pro_descripcion { get; set; }

        public decimal pro_precio { get; set; }

        public string pro_cantidad { get; set; }

        public string imgstring {get;set;}

        public Byte[] pro_img { get; set; }
    }
}
