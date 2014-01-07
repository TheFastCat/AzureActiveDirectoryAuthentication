using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace NativeClient
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            // Get token
            AuthenticationContext ac = new AuthenticationContext("https://login.windows.net/SalesApplication.onmicrosoft.com");//the 'App ID URI' of the secured resource/API trying to access as configured in AAD 
            
            AuthenticationResult ar =
              ac.AcquireToken("https://SalesApplication.onmicrosoft.com/WebApplication1", //the "name" of the secured resource/API trying to access as configured in AAD ('App ID URI')
              "5685ff14-3fb8-4785-a78e-6f81219b39f8",// the 'client ID' for this client application as configured in AAD
              new Uri("https://SalesApplication.onmicrosoft.com/myWebAPItestclient"));// the redirect URI for this client application as configured in AAD

            // http://goo.gl/Ypb6yv
            // the following generates a security exception since we don't have a valid certificate
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(customXertificateValidation);
          
            // Call Web API
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", ar.AccessToken);

            HttpResponseMessage response = httpClient.GetAsync("https://localhost:44304/api/Values").Result;

            // display the result
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(result);
            }
            else
            {
                result = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show(result, response.StatusCode.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// intercept the certificate check and pass-through if the scope involves a localhost
        /// </summary>
        /// <see cref="http://goo.gl/Ypb6yv"/>
        private static bool customXertificateValidation(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            if (cert.Subject == "CN=localhost")
            {
                return true;
            }

            return false;
        }
    }
}
