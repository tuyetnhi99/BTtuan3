using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowLoaiHoa : ContentPage
    {
        Database db = new Database();

        public ShowLoaiHoa()
        {
            InitializeComponent();
            ShowListLoaiHoa();
        }

        void ShowListLoaiHoa()
        {
            List<LoaiHoa> dsloaihoa = new List<LoaiHoa>();
            dsloaihoa = db.selectLoaiHoa();
            MyListView.ItemsSource = dsloaihoa;

        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            LoaiHoa l = (LoaiHoa)MyListView.SelectedItem;
            Navigation.PushAsync(new HoaTheoLoai(l.MaLoai));
        }
    }
}
