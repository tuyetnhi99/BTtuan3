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
    public partial class HoaTheoLoai : ContentPage
    {
        Database db = new Database();
        public HoaTheoLoai(int maloai)
        {
            InitializeComponent();
            List<Hoa> dshoa = new List<Hoa>();
            dshoa = db.selectHoatheoLoaiHoa(maloai);
            MyListViewHoa.ItemsSource = dshoa;
        }
    }
}