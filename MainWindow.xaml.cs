using System.Windows;
using FastTrackLogistics.Views; // Подключаем папку с вашими страницами

namespace FastTrackLogistics
{
    public partial class MainWindow : Window
    {
        // Поля для хранения страниц (Lazy Loading)
        private RoutingView? _routingPage;
        private TrackingView? _trackingPage;
        private IntegrationView? _integrationPage;

        public MainWindow()
        {
            InitializeComponent();
            ShowRouting(); // Загружаем первую страницу при старте
        }

        private void NavRouting_Click(object sender, RoutedEventArgs e) => ShowRouting();
        private void NavTracking_Click(object sender, RoutedEventArgs e) => ShowTracking();
        private void NavIntegration_Click(object sender, RoutedEventArgs e) => ShowIntegration();

        private void ShowRouting()
        {
            _routingPage ??= new RoutingView();
            MainFrame.Navigate(_routingPage);
            TxtHeader.Text = "Управление маршрутами";
        }

        private void ShowTracking()
        {
            _trackingPage ??= new TrackingView();
            MainFrame.Navigate(_trackingPage);
            TxtHeader.Text = "Мониторинг грузов";
        }

        private void ShowIntegration()
        {
            _integrationPage ??= new IntegrationView();
            MainFrame.Navigate(_integrationPage);
            TxtHeader.Text = "Интеграция данных";
        }
    }
}