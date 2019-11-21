using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class data_phuongtien
    {
        public string id { get; set; }
        public string ten { get; set; }
        public string nhom { get; set; }
        public string so { get; set; }
        public string tinhtrang { get; set; }
        public string madt { get; set; }
        public string sdt { get; set; }
        public string madv { get; set; }
        public string sokhung { get; set; }
        public string ghichu { get; set; }
        public DateTime ngaycapnhat { get; set; }
        public string somay { get; set; }

        //them
        public string tennhom { get; set; }
        public string tendt { get; set; }
        public string tendv { get; set; }
        public string tentinhtrang { get; set; }

        //moi
        public double dinhmuc { get; set; }
        public string dvdinhmuc { get; set; }

        //moi
        public DateTime? dangkiem { get; set; }
        public DateTime? baohiem { get; set; }
        public DateTime? diduong { get; set; }
        public DateTime? tntx { get; set; }
        public int? MAU_DK { get; set; }
        public int? MAU_BH { get; set; }
        public int? MAU_DD { get; set; }
        public int? MAU_NX { get; set; }

    }
}
