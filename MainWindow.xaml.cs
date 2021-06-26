using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotaView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void get_btn_Click(object sender, RoutedEventArgs e)
        {
            string api_Key = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://community-dota-2.p.rapidapi.com/IDOTA2Match_570/GetMatchDetails/V001/?key=" + api_Key + "&matches_requested=25&match_id=" + matchID_textBox.Text),
                Headers =
    {
        { "x-rapidapi-key", "7552910df6mshcf5a85682b9b491p155cc0jsn5d9d9b862c47" },
        { "x-rapidapi-host", "community-dota-2.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                textBox.Text = body.ToString();
                //Console.WriteLine(body);
            }
        }

        private void matchID_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
