using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectSelenium2
{
    public class PageTitleTests


       
    {

         IWebDriver driver;      
    
        [SetUp]
        public void Setup()
        {
            
            // Initialize WebDriver
        driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://app.testdome.com/");
       
        }

        public static String GetPageTitle(IWebDriver driver)
        {
            return driver.Title;
        }



        [Test]
        public void GetTitle()
        {
            

           string title= PageTitleTests.GetPageTitle(driver);
            Console.WriteLine(title);

            
           
        }
      
        
    }
}