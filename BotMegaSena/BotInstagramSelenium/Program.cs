using System;
using System.Threading;
using OpenQA.Selenium;
using prmToolkit.Configuration;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;

namespace BotInstagramSelenium
{
    class Program
    {
        static void Main(string[] args)
        {

            var username = Configuration.GetKeyAppSettings("usuario");
            var password = Configuration.GetKeyAppSettings("senha");
            var paginaSeguir = Configuration.GetKeyAppSettings("paginaseguir");
            var drive = Configuration.GetKeyAppSettings("caminhodrive");

            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, drive);

            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(10), "https://www.instagram.com/accounts/login/");
                webDriver.SetText(By.Name("username"), username);
                webDriver.SetText(By.Name("password"), password);
                webDriver.Submit(By.TagName("button"));

                Thread.Sleep(TimeSpan.FromSeconds(10));
                webDriver.LoadPage(TimeSpan.FromSeconds(10), paginaSeguir);

                IWebElement btnSeguir = null;
                try
                {
                    btnSeguir = webDriver.FindElement(By.XPath("//button[contains(text(),'Seguir')]"));
                }
                catch (NoSuchElementException ex)
                {

                    Console.WriteLine("Já está seguindo o usuário");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }

           
            Console.ReadKey();

        }
    }
}
