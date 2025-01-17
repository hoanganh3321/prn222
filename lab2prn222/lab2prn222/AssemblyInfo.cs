using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace FetchDataApp
{
    public partial class MainWindow : Window
    {
        private HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        // Fetch data when the "Fetch Data" button is clicked
        private async void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a URL.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                OutputTextBox.Clear();
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    OutputTextBox.Text = content;
                }
                else
                {
                    MessageBox.Show("Failed to fetch data. HTTP Status: " + response.StatusCode, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Clear the input and output fields
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UrlTextBox.Clear();
            OutputTextBox.Clear();
        }

        // Close the application
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
