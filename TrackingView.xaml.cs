using System.Collections.Generic;
using System.Collections.ObjectModel;
using FastTrackLogistics.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FastTrackLogistics.Views
{
    public partial class TrackingView : Page
    {
        private ObservableCollection<TrackingItem> _allItems;
        public ObservableCollection<TrackingItem> FilteredItems { get; set; }

        public TrackingView()
        {
            InitializeComponent();

            // Имитация базы данных
            _allItems = new ObservableCollection<TrackingItem>
            {
                new TrackingItem { CargoId = "FT-8821", CurrentLocation = "Москва (Склад)", Progress = 10, StatusText = "ПОГРУЗКА", StatusColor = Brushes.Orange, History = new List<string>{"Принято в обработку", "Сортировка завершена"} },
                new TrackingItem { CargoId = "FT-9012", CurrentLocation = "Трасса М4", Progress = 65, StatusText = "В ПУТИ", StatusColor = new SolidColorBrush(Color.FromRgb(166, 196, 188)), History = new List<string>{"Выезд из Москвы", "Проезд Тулы"} },
                new TrackingItem { CargoId = "FT-4432", CurrentLocation = "Сочи (Терминал)", Progress = 100, StatusText = "ГОТОВО", StatusColor = Brushes.RoyalBlue, History = new List<string>{"Прибытие в Сочи", "Разгрузка"} }
            };

            FilteredItems = new ObservableCollection<TrackingItem>(_allItems);
            TrackingList.ItemsSource = FilteredItems;
        }

        // Поиск в реальном времени
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchBox.Text.ToLower();
            var filtered = _allItems.Where(x => x.CargoId.ToLower().Contains(query) || x.CurrentLocation.ToLower().Contains(query)).ToList();

            FilteredItems.Clear();
            foreach (var item in filtered) FilteredItems.Add(item);
        }

        // Клик по карточке — показ деталей
        private void Card_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn?.DataContext is TrackingItem selected)
            {
                DetailsPanel.Visibility = Visibility.Visible;
                DetailId.Text = selected.CargoId;
                HistoryList.ItemsSource = selected.History;
            }
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Команда отправлена на сервер мониторинга ФастТрэк", "Система");
        }
    }

    public class TrackingItem
    {
        public string CargoId { get; set; } = string.Empty;
        public string CurrentLocation { get; set; } = string.Empty;
        public int Progress { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public Brush StatusColor { get; set; } = Brushes.Gray;
        public List<string> History { get; set; } = new List<string>();
    }
}