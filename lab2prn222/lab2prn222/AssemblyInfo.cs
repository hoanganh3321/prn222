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

        private async void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a URL.");
                return;
            }

            try
            {
                // Show a loading message or indication
                OutputTextBox.Text = "Fetching data...";

                // Send GET request
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    OutputTextBox.Text = content;
                }
                else
                {
                    MessageBox.Show("Failed to retrieve data. HTTP Status: " + response.StatusCode);
                    OutputTextBox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Handle network errors or invalid URL
                MessageBox.Show($"An error occurred: {ex.Message}");
                OutputTextBox.Text = string.Empty;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the URL input and output content
            UrlTextBox.Clear();
            OutputTextBox.Clear();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }
    }
}
