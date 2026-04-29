using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using FastTrackLogistics.Models;

namespace FastTrackLogistics.Views
{
    public partial class RoutingView : Page
    {
        public ObservableCollection<RouteItem> Routes { get; set; }

        public RoutingView()
        {
            InitializeComponent();

            // Инициализация данных
            Routes = new ObservableCollection<RouteItem>
            {
                new RouteItem { Id = "FT-101", Destination = "Москва - Сочи", Distance = "1600 км", Status = "Активен", ETA = "12:00" },
                new RouteItem { Id = "FT-102", Destination = "СПБ - Казань", Distance = "1200 км", Status = "Ожидание", ETA = "18:30" }
            };

            RoutesGrid.ItemsSource = Routes;
        }

        // Этот метод вызывается кнопкой из XAML
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Изменения успешно сохранены в системе!", "FastTrack");
        }
    }

    public class RouteItem
    {
        public string Id { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string Distance { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ETA { get; set; } = string.Empty;
    }
}