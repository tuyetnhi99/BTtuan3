using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace SQLite
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Database db = new Database();
            db.createDatabase();
        }

        private void cmdthemLoaiHoa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync (new ThemLoaiHoa());
            //MainPage = new NavigationPage(new ThemLoaiHoa());
        }

        private void cmdThemHoa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThemHoa());
        }

        private void cmdShowLoaiHoa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowLoaiHoa());
        }
        private void cmdShowHoa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowHoa());
        }
    }
}

