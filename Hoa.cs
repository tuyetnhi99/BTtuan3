using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLite
{
    public class Hoa
    {
        [PrimaryKey, AutoIncrement]
        //Mã hoa là khóa chính, có giá trị tự tăng
        public int MaHoa { get; set; }
        public int MaLoai { get; set; }
        public string TenHoa { get; set; }
        public string Hinh { get; set; }
        public string MoTa { get; set; }
        public double Gia { get; set; }

    }
}

