using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemHoa : ContentPage
    {
        Database db = new Database();
        public List<LoaiHoa> dsloaihoa { get; set; }
        public ThemHoa()
        {
            InitializeComponent();
            db.createDatabase();
            dsloaihoa = db.selectLoaiHoa();
            cboloaihoa.ItemsSource = dsloaihoa;
        }

        private void addHoa_Clicked(object sender, EventArgs e)
        {
            if (cboloaihoa.SelectedIndex >= 0)
            {
                LoaiHoa l = (LoaiHoa)cboloaihoa.SelectedItem;
                Hoa h = new Hoa
                {
                    MaLoai = l.MaLoai,
                    TenHoa = txttenhoa.Text,
                    Hinh = txthinh.Text,
                    Gia = double.Parse(txtgia.Text),
                    MoTa = txtMota.Text
                };
                if (db.InsertHoa(h) == true)
                    DisplayAlert("Thông báo", "Thêm hoa thành công", "OK");
                else
                    DisplayAlert("Thông báo", "Thêm hoa Thất bại", "OK");
            }
            else DisplayAlert("Thông báo", "Bạn phải chọn loại hoa", "OK");
        }
        private void cboloaihoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}