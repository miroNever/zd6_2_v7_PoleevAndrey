using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ListLunber :ContentPage
    {
        public List<Lunber> Lunbers { get; set; }
        public ListLunber ()
        {
            InitializeComponent();
            Lunbers = new List<Lunber>
            {
                new Lunber {Title="Брус", TypeTree="Дуб", Price=1000, Category="Очищенный", Manufacturer="Цитрон",Days = 4, Availability="в наличии", ImagePath="brus.jpg", Description="Пиломатериал толщиной и шириной 100 мм и более." +
                " Брусья изготовляются из брёвен или клееных досок. Используются в строительстве домов, в мебельной промышленности, производстве тары и др. " },
                new Lunber {Title="Доска обрезаная", TypeTree="Берёза", Category="Очищенный",Manufacturer="ЛесМари",Days = 3,Price=600,Availability="в наличии", ImagePath="doska_obreznay.jpg", Description="Пиломатериал размерами сечений от 16 × 8 мм до 250 × 100 мм. Обрезные доски изготавливаются из древесины разных пород." +
                " Основное отличие обрезной доски - это наличие обзола, не более допустимого по соответствующей нормативно-технической документации."},
                new Lunber {Title="Антисептированный брус",TypeTree="Дуб", Category="Очищенный", Price=1200, Manufacturer="ТАЛИЯ",Days = 10,Availability="в наличии",ImagePath="antiseptirovannyy_brus.jpg", Description="Антисептированный брус – это брус, полученный путем обработки пиломатериала антисептирующим раствором (методами погружения, пропитки под давлением, обработки специальными пастами или обработка растворами на масляной основе). " +
                "Отдельная категория пропиток – антипирены, они повышают огнеупорные качества древесины и, как правило, дополнительно защищают ее от плесени и гнили."}
            };
            Label header = new Label
            {
                Text = "Онлайн-магазин лесничества",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Green,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Yellow,
            };

            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = Lunbers,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Title");
                    Binding companyBinding = new Binding { Path = "Price", StringFormat = "Цена материала {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
                    return imageCell;
                })
            };
            listView.ItemTapped += OnItemTapped;
            this.Content = new StackLayout { Children = { header, listView, runningtitle, date, button} };
        }
        Lunber selectedLunber;
        public void OnItemTapped (object sender, ItemTappedEventArgs e)
        {
            selectedLunber = e.Item as Lunber;
            if (selectedLunber != null)
            {
                runningtitle.Text = "Выбранный материал " + $"{selectedLunber.Availability} - {selectedLunber.Title}";
            }

        }

        private void Button_Clicked (object sender, EventArgs e)
        {
            if (selectedLunber != null)
            { 
                Navigation.PushAsync( new MainPage(selectedLunber));
            }
            else
                this.DisplayToastAsync("Выберите материал");
        }

        private void Button_Clicked_1 (object sender, EventArgs e)
        {
            if (selectedLunber != null)
            {
                Navigation.PushAsync(new CostCalculation(selectedLunber.Mert, selectedLunber.Price, selectedLunber.Days));
            }
            else
                this.DisplayToastAsync("Выберите материал");
        }
    }
}



            