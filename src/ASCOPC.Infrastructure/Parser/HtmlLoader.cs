using ASCOPC.Infrastructure.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ASCOPC.Infrastructure.Parser
{
    public class HtmlLoader
    {
        private readonly HttpClient _httpClient;

        public HtmlLoader() : this(string.Empty)
        {

        }
        public HtmlLoader(string uri)
         {
            this.Uri = uri;

            _httpClient = new HttpClient();
        }

        public string Uri { get; set; }

        public async Task<string> GetSource()
        {
            if (string.IsNullOrEmpty(Uri))
                throw new ArgumentNullException(nameof(Uri));

            var options = new ChromeOptions();
            options.AddArgument("headless");

            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);

            try
            {
                driver.Navigate().GoToUrl(this.Uri);
                return driver.PageSource;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

    }
}
