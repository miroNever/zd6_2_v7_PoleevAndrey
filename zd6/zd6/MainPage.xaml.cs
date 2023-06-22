using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zd6
{
    public partial class MainPage :ContentPage
    {
        double Metr; 
        double Price; 
        int Days; 
        public MainPage (Lunber lunber)
        {
            InitializeComponent();
            Info(lunber);

        }
        public void Info(Lunber lunber)
        { 
            try
            {
                picture.Source = lunber.ImagePath;
                title.Text = "Название " + lunber.Title;
                typeTree.Text = "Тип дерева: " + lunber.TypeTree;
                categori.Text = "Категория: " + lunber.Category;
                manufacturer.Text = "Производитель: " + lunber.Manufacturer;
                days.Text = "Количество дней на изготовление: " + lunber.Days;
                description.Text = lunber.Description;
                Price = lunber.Price;
                Days = Convert.ToInt32(lunber.Days);
            }
            catch
            {
                this.DisplayToastAsync("Введите число");
            }
        }
        private void next_Clicked(object sender, EventArgs e)
        {
            try
            {
                Metr = double.Parse(entry.Text);
                Navigation.PushAsync(new CostCalculation(Metr, Price, Days));
            }
            catch
            {
                this.DisplayToastAsync("Введите число");
            }
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
