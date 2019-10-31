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
    public partial class ThemLoaiHoa : ContentPage
    {

        public ThemLoaiHoa()
        {
            InitializeComponent();
        }

        private void cmdaddLoaiHoa_Clicked(object sender, EventArgs e)
        {

            Database db = new Database();
            LoaiHoa l = new LoaiHoa { TenLoai = txtloaihoa.Text };
            bool kq = db.InsertLoaiHoa(l);
            if (kq == true)
                DisplayAlert("Message", "Thêm Thành Công", "OK");
            else
                DisplayAlert("Message", "Thêm thất bại", "OK");
        }
    }
}