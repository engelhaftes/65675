using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace FastTrackLogistics.Models
{
    /// <summary>
    /// Базовый класс для реализации автоматического обновления интерфейса (INotifyPropertyChanged).
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    /// <summary>
    /// Модель для модуля "Маршрутизация".
    /// </summary>
    public class RouteItem : ObservableObject
    {
        private string _id = string.Empty;
        private string _destination = string.Empty;
        private string _distance = string.Empty;
        private string _status = "Планируется";
        private string _eta = "—";

        public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Destination { get => _destination; set { _destination = value; OnPropertyChanged(); } }
        public string Distance { get => _distance; set { _distance = value; OnPropertyChanged(); } }
        public string Status { get => _status; set { _status = value; OnPropertyChanged(); } }
        public string ETA { get => _eta; set { _eta = value; OnPropertyChanged(); } }
    }

    /// <summary>
    /// Модель для модуля "Мониторинг" с расширенной интерактивностью.
    /// </summary>
    public class TrackingItem : ObservableObject
    {
        private string _cargoId = string.Empty;
        private string _currentLocation = string.Empty;
        private int _progress;
        private string _statusText = "В обработке";
        private Brush _statusColor = Brushes.Gray;
        private bool _isSelected;
        private List<string> _history = new List<string>();

        public string CargoId { get => _cargoId; set { _cargoId = value; OnPropertyChanged(); } }
        public string CurrentLocation { get => _currentLocation; set { _currentLocation = value; OnPropertyChanged(); } }
        public int Progress { get => _progress; set { _progress = value; OnPropertyChanged(); } }
        public string StatusText { get => _statusText; set { _statusText = value; OnPropertyChanged(); } }
        public Brush StatusColor { get => _statusColor; set { _statusColor = value; OnPropertyChanged(); } }

        // Свойство для интерактивного выделения карточки
        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(); OnPropertyChanged(nameof(CardBackground)); }
        }

        public Brush CardBackground => IsSelected ? new SolidColorBrush(Color.FromRgb(240, 245, 244)) : Brushes.White;

        public List<string> History
        {
            get => _history;
            set { _history = value; OnPropertyChanged(); }
        }
    }

    /// <summary>
    /// Модель для модуля "Интеграция".
    /// </summary>
    public class LogEntry : ObservableObject
    {
        private string _message = string.Empty;
        private string _timestamp = DateTime.Now.ToString("HH:mm:ss");
        private string _type = "Info"; // Info, Warning, Error

        public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }
        public string Timestamp { get => _timestamp; set { _timestamp = value; OnPropertyChanged(); } }
        public string Type { get => _type; set { _type = value; OnPropertyChanged(); } }

        public Brush TypeColor => Type switch
        {
            "Error" => Brushes.IndianRed,
            "Warning" => Brushes.Orange,
            _ => new SolidColorBrush(Color.FromRgb(166, 196, 188))
        };
    }
}