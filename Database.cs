using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace SQLite
{
    public class Database
    {
        //Lấy thư mục lưu trữ csdl trên hệ thống
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        //Create Database
        public bool createDatabase()
        {
            try
            {
                //tạo csdl
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    //Tạo 2 bảng
                    connection.CreateTable<LoaiHoa>();
                    connection.CreateTable<Hoa>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                //
                return false;
            }
        }

        //Xử lý thêm loại hoa
        public bool InsertLoaiHoa(LoaiHoa loai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(loai);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {

                return false;
            }
        }
        //xử lý Chọn loại hoa
        public List<LoaiHoa> selectLoaiHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<LoaiHoa>().ToList();
                }
            }
            catch (SQLiteException ex)
            {

                return null;
            }
        }
        //Xử lý thêm hoa
        public bool InsertHoa(Hoa hoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(hoa);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {

                return false;
            }
        }
        //Xử lý chọn Hoa
        public List<Hoa> selectHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<Hoa>().ToList();
                }
            }
            catch (SQLiteException ex)
            {

                return null;
            }
        }

        //Chọn loại hoa bằng ID
        public LoaiHoa selectLoaiHoabyID(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var lh = from l in connection.Table<LoaiHoa>().ToList() where l.MaLoai == id select l;
                    return lh.ToList().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {

                return null;
            }
        }

        //Chọn Hoa theo Loại Hoa
        public List<Hoa> selectHoatheoLoaiHoa(int maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var dsh = from lhs in connection.Table<Hoa>().ToList() where lhs.MaLoai == maloai select lhs;
                    return dsh.ToList<Hoa>();
                }
            }
            catch (SQLiteException ex)
            {

                return null;
            }
        }

        //Chọn Hoa
        public List<object> selecthoa1()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var BangHoa = connection.Table<Hoa>();
                    var BangLoaiHoa = connection.Table<LoaiHoa>();
                    var kq = from h in BangHoa
                             join lh in BangLoaiHoa on h.MaLoai equals lh.MaLoai
                             select new { h.MaHoa, h.TenHoa, h.Hinh, h.Gia, h.MaLoai, h.MoTa, lh.TenLoai };
                    return kq.ToList<object>();
                }
            }
            catch (SQLiteException ex)
            {

                return null;
            }
        }

        //Chọn loại hoa
        public List<object> selectLoaiHoa1()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var lh1 = from h in connection.Table<Hoa>()
                              group h by h.MaLoai into kq
                              select new { MaLoai = kq.Key, TongSoHoa = kq.Count() };
                    var lh2 = from lh in connection.Table<LoaiHoa>()
                              join l1 in lh1 on lh.MaLoai equals l1.MaLoai
                              select new { lh.MaLoai, lh.TenLoai, l1.TongSoHoa };
                    return lh2.ToList<object>();
                }
            }
            catch (SQLiteException ex)
            {

                return null;
            }
        }
    }
}
