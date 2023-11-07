using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Text.Encodings.Web;

namespace UITestProject
{
    public class UnitTest1
    {
        string test_url = "https://www.google.com";

        IWebDriver driver;

        public UnitTest1()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = test_url;

            PageFactory.InitElements(driver, this);
        }

        [Fact]
        public void Test1()
        {
            IWebElement rejeitarTudoBtn = driver.FindElement(By.Id("W0wltc"));
            rejeitarTudoBtn.Click();

            IWebElement searchText = driver.FindElement(By.Name("q"));

            searchText.SendKeys("LambdaTest");

            System.Threading.Thread.Sleep(2000);

            IWebElement searchButton = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]"));

            searchButton.Click();

            System.Threading.Thread.Sleep(4000);

            IWebElement firstTitleResult = driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div/div[1]/div/span/a/h3"));

            Assert.Equal("LambdaTest: Next-Generation Mobile Apps and Cross ...", firstTitleResult.Text);
            Assert.Contains("LambdaTest", driver.Title);
        }

        [FindsBy(How = How.Id, Using = "W0wltc")]
        [CacheLookup]
        private IWebElement rejeitar_tudo_btn;

        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        private IWebElement search_text;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/form/div[1]/div[1]/div[4]/center/input[1]")]
        [CacheLookup]
        private IWebElement search_button;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div/div[1]/div/span/a/h3")]
        [CacheLookup]
        private IWebElement first_title_result;

        [Fact]
        public void Test2()
        {
            rejeitar_tudo_btn.Click();

            search_text.SendKeys("LambdaTest");

            System.Threading.Thread.Sleep(2000);

            search_button.Click();

            System.Threading.Thread.Sleep(4000);

            Assert.Equal("LambdaTest: Next-Generation Mobile Apps and Cross ...", first_title_result.Text);
            Assert.Contains("LambdaTest", driver.Title);
        }
    }
}