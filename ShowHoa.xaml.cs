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
    public partial class ShowHoa : ContentPage
    {
        Database db = new Database();
        public ShowHoa()
        {
            InitializeComponent();
            ShowListHoa();
        }
        void ShowListHoa()
        {
            List<Hoa> dshoa = new List<Hoa>();
            dshoa = db.selectHoa();
            MyListViewHoa.ItemsSource = dshoa;
        }
    }
}