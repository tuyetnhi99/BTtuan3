using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLite
{
    public class LoaiHoa
    {
        [PrimaryKey, AutoIncrement]
        //Mã loại là khóa chính, có giá trị tự tăng
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
}
