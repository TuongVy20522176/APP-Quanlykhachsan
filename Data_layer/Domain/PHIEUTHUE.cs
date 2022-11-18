using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_layer.Domain
{
    public class PHIEUTHUE
    {
        public string MAPT { set; get; }
        public string TENKH { set; get; }
        public string MAPH { set; get; }
        public DateTime? NGAYTHUE { set; get; }
        public DateTime? NGAYTRA { set; get; }
        public decimal GIATHUE { set; get; }
        public string TINHTRANG { set; get; }
        public byte? SONGUOI { set; get; }
    }
}
