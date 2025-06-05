using System;
using System.Windows;

namespace WpfDeadLockusing
{
    public partial class MainWindow : Window
    {
        private readonly string[] Urls = new[]
        {
            "https://example.com",
            "https://jsonplaceholder.typicode.com/posts/1"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeadlockButton_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = "Ожидание...";

            try
            {
                string[] result = DeadLock.ParseSync(Urls);

                ResultText.Text = $"Загружено {result.Length} страниц.";
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Ошибка: {ex.InnerException?.Message}";
            }
        }

        private async void NoDeadlockButton_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = "Ожидание...";

            try
            {
                string[] result = await DeadLock.ParseAsync(Urls);

                ResultText.Text = $"Загружено {result.Length} страниц.";
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Ошибка: {ex.Message}";
            }
        }
    }
}