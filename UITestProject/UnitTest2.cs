using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.Encodings.Web;

namespace UITestProject
{
    public class UnitTest2 : IDisposable
    {
        string test_url = "https://localhost:44486/";

        IWebDriver driver;

        public UnitTest2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  // expandir browser

            driver.Url = test_url;
        }

        public void Dispose()
        {
            driver.Close(); // Fechar browser
        }

        [Fact]
        public void Test1()
        {
            SelectElement dropbox = new SelectElement(driver.FindElement(By.Id("dropbox")));
            dropbox.SelectByValue("valor3");

            // verificar se o texto da opção selecionada é Valor 3
            Assert.Equal("Valor 3", dropbox.SelectedOption.Text);

            System.Threading.Thread.Sleep(4000);
        }
    }
}