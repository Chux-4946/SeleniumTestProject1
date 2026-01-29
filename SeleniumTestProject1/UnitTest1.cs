using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;



namespace SeleniumTestProject1
{
    public class Tests
    {
        IWebDriver webDriver;


        [SetUp]
        public void Setup()
        {
            // Create instance of webdriver


            //Nagivate to Url
            webDriver = new ChromeDriver();
             webDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
             //webDriver.Navigate().GoToUrl("https://practice.expandtesting.com/");
            // webDriver.Navigate().GoToUrl("https://practice.expandtesting.com/dropdown");
            //webDriver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            //create timeout
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMicroseconds(10);
            //Maximise browser window
            webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {

            //Find element
            IWebElement webElement = webDriver.FindElement(By.CssSelector("#main-navbar > ul.navbar-nav.flex-row.flex-wrap.pt-2.py-md-0 > li:nth-child(6) > a"));
            //Click element
            webElement.Click();
            //close browser
            webDriver.Close();
            //Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            //# examples > div:nth-child(11) > div:nth-child(3) > div > div.card-footer.d-flex.justify-content-between.align-items-center > div > a
            //div:nth-child(10) div:nth-child(3) div:nth-child(1) div:nth-child(2) div:nth-child(1) a:nth-child(1)
            ////a[@href='/dropdown'][normalize-space()='Try it out']
            // IWebElement webElement1 = 
            // webDriver.FindElement(By.LinkText("Dropdown List")).Click();

            IWebElement webElement = webDriver.FindElement(By.CssSelector("#dropdown"));
            webElement.Click();
        }
        [Test]
        public void OrangeHRMTest()
        {

            IWebElement webElement = webDriver.FindElement(By.Name("username"));
            IWebElement webElement2 = webDriver.FindElement(By.Name("password"));
            webElement.SendKeys("Admin");
            webElement2.SendKeys("admin123");
            //webElement.Click();
            //webElement.SendKeys("Admin");
        }

        [Test]
        public void Test3()
        {
            string name = "france";
            //Nagivate to Url
            // webDriver = new ChromeDriver();
            //webDriver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            //create timeout
            // webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMicroseconds(10);
            //Maximise browser window
            //webDriver.Manage().Window.Maximize();

            IWebElement webelement3 = webDriver.FindElement(By.CssSelector("#country"));
            SelectElement selectElement = new SelectElement(webelement3);
            // selectElement.SelectByValue("uk");


            //IList<IWebElement> selectedOption =selectElement.AllSelectedOptions;
            //IList<IWebElement> selectedOption = selectElement.Options;
            var selectedOption = selectElement.Options;

            // var status = false;


            foreach (IWebElement option in selectedOption)

            {
                Console.WriteLine("print:" + option.Text);
                //string value = option.Text;
                //if (value.Equals(name))
                //{
                //    selectElement.SelectByValue(name);
                //    //status = true;
                //    break;
                //    //option.Click();
                //}

                //Console.WriteLine(option.Text);
                //Console.WriteLine(name);
                //break;






            }



        }
        [Test]
        public void Datepickertest1()

        {
            //expected dated
            string month = "June";
            string date = "14";
            string year = "2025";


            IWebElement datepicker = webDriver.FindElement(By.CssSelector("#datepicker"));
            // datepicker.SendKeys("15 / 06 / 2025");
            datepicker.Click();

            while (true)
            {
                var cureentMonth = webDriver.FindElement(By.CssSelector("#ui-datepicker-div > div > div > span.ui-datepicker-month"));
                var currentYear = webDriver.FindElement(By.CssSelector("#ui-datepicker-div > div > div > span.ui-datepicker-year"));

                if (cureentMonth.Equals(month) && currentYear.Equals(year))
                {
                    break;
                }
                var nextButton = webDriver.FindElement(By.CssSelector("#ui-datepicker-div > div > a.ui-datepicker-next.ui-corner-all"));
                nextButton.Click();
                break;
            }
            //select date
            var allDates = webDriver.FindElements(By.XPath("//*[@id=\"ui-datepicker-div\"]/table//tbody//tr/td//a"));
            foreach (IWebElement dt in allDates)
            {
                var value = dt.Text;
                if (value.Equals(date))
                {
                    dt.Click();
                    break;
                }
            }
        }
        [Test]
        public void Datepickertest2()

        {

            //expected dated
            string month = "Aug";
            string date = "20";
            string year = "2027";

            //find datepicker and click inputbox
            IWebElement datepicker = webDriver.FindElement(By.CssSelector("#txtDate"));
            datepicker.Click();
            //identify monthdropdown and select month
            var monthDropdown = webDriver.FindElement(By.CssSelector("#ui-datepicker-div > div > div > select.ui-datepicker-month"));
            SelectElement selectedMonth = new SelectElement(monthDropdown);
            selectedMonth.SelectByText(month);
            //identify yeardropdown and select year
            var yearDropdown = webDriver.FindElement(By.CssSelector("#ui-datepicker-div > div > div > select.ui-datepicker-year"));
            SelectElement selectedYear = new SelectElement(yearDropdown);
            selectedYear.SelectByText(year);
            //identify all dates elements, store in a variable and loop through to click expected date 
            var Alldate = webDriver.FindElements(By.XPath("//*[@id=\"ui-datepicker-div\"]/table//tbody//tr/td//a"));
            foreach (IWebElement dt in Alldate)
            {
                var value = dt.Text;
                if (value.Equals(date))
                {
                    dt.Click();
                }
                //Console.WriteLine("print the details of :" + value);
            }

        }
        [Test]
        public void Datepickertest3()
        {

            //expected dated
            string month = "Aug";
            string date = "20";
            string year = "2027";

            //find datepicker and click inputbox
            IWebElement datepicker = webDriver.FindElement(By.CssSelector("#txtDate"));
            datepicker.Click();
            //identify calender table
            //webDriver.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/table"));
            //identify monthdropdown and select month
            var monthDropdown = webDriver.FindElement(By.CssSelector("#ui-datepicker-div > div > div > select.ui-datepicker-month"));
            SelectElement selectedMonth = new SelectElement(monthDropdown);
            // selectedMonth.SelectByText(month);
            var allSelectedOption = selectedMonth.Options;
            foreach (IWebElement option in allSelectedOption)
            {
                // Console.WriteLine(option.Text);

                var value = option.Text;
                if (value.Equals(month))
                {
                    selectedMonth.SelectByText(month);
                    break;
                }

            }



        }

        //Mouse and Keyboard Action using Action Class

        [Test]
        public void MouseOverTest()
        {
            var PointMeElement = webDriver.FindElement(By.ClassName("dropbtn"));
            var laptopButton = webDriver.FindElement(By.XPath("//*[@id=\"HTML3\"]/div[1]/div/div/a[1]"));
            Actions act = new Actions(webDriver);
            act.MoveToElement(PointMeElement).MoveToElement(laptopButton).Pause(TimeSpan.FromSeconds(2)).Click().Build().Perform();
            // Thread.Sleep(20000);
            webDriver.Close();

        }

        [Test]
        public void DragAndDropTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            //var js = webDriver as IJavaScriptExecutor;
            //string args = null;
            //js.ExecuteScript(args);


            var sourceElement = webDriver.FindElement(By.CssSelector("#draggable > p"));
            var targetElement = webDriver.FindElement(By.CssSelector("#droppable"));
            //webDriver.ExecuteJavaScript("arguments[0].value='droppable' ", targetElement);
            //webDriver.ExecuteJavaScript("window.scrollTo(0, document.body.scrollHeight)");

            Actions act = new Actions(webDriver);
            act.DragAndDrop(sourceElement, targetElement).ScrollToElement(targetElement).Build().Perform();
            js.ExecuteScript("arguments[0].scrollIntoView(true);", targetElement);
            // js.ExecuteScript("arguments[0].setAttribute");
            //js.ExecuteScript ("arguments[0].scrollInview(); targetElement);
            //if (js != null
            //{
            //

            //}

            Thread.Sleep(20000);

        }
        [Test]
        public void DoubleClickTest()
        {
            var fieldbox1 = webDriver.FindElement(By.XPath("//input[@id='field1']"));
            var fieldbox2 = webDriver.FindElement(By.XPath("//input[@id='field2']"));
            var submitButton = webDriver.FindElement(By.XPath("//button[normalize-space()='Copy Text']"));

            fieldbox1.Clear();
            fieldbox1.SendKeys("Chux");
            Actions act = new Actions(webDriver);
            act.DoubleClick(submitButton).Build().Perform();

            //validation
            string text = fieldbox2.GetAttribute("value");

            if (text.Equals("Chux"))
            {
                Console.WriteLine("text copied");
            }
            else
            {
                Console.WriteLine("text not copied");
            }



//# dropdown > div:nth-child(1) #dropdown
        }
        [Test]
        public void ScrolllingDropdownTest()
        {
            //var selectedOption = " Item 74";
            
             var inputfield = webDriver.FindElement(By.CssSelector("#comboBox"));
             inputfield.Click();
            var itmoption = webDriver.FindElement(By.CssSelector("#dropdown > div:nth-child(7)"));
           
            
            Actions act = new Actions(webDriver);
            act.MoveToElement(itmoption).Click().Build().Perform();

            // var drpdown = webDriver.FindElement(By.CssSelector("#dropdown"));
            //drpdown.FindElements(By.CssSelector("#dropdown"));
            // inputfield.SendKeys("Item 70");

            //var inputbox = webDriver.FindElement(By.XPath("//*[@id=\"comboBox\"]"));
            //var itemOption32 = webDriver.FindElement(By.XPath("//*[@id=\"dropdown\"]/div[32]"));
            //  IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            //  js.ExecuteScript("arguments[0].scrollIntoView(true);");

            //SelectElement selectoption = new SelectElement(itmoptions1);
            //var alloptions =selectoption.Options;
            //Console.WriteLine(alloptions.Count);
           

          

            //foreach (IWebElement option in alloptions)
            //{
            //    // Console.WriteLine(option.Text);

            //    var value = option.Text;
            //    if (value.Equals(selectedOption))
            //    {
            //        drpdown.Click();
            //        break;
            //    }

            //}

           


        }
        [Test]
        public void ScrollingDropdownTest2()
        {
            //IList<IWebElement> options=webDriver.FindElements(By.XPath("//div[@id='dropdown']/div"));
            //IList<IWebElement> options = webDriver.FindElements(By.XPath("//div[@id='dropdown']//ancestor::div"));
           var inputcombobox= webDriver.FindElement(By.CssSelector("#comboBox"));
            inputcombobox.Click();
            IList<IWebElement> options = webDriver.FindElements(By.XPath("//div[@id='dropdown']//parent::div"));
            Console.WriteLine("list of options are..." + options.Count);

            foreach(IWebElement option in options)
            {
                //TO PRINT ALL OPTION IN CONSOLE WINDOW USE BELOW Console method otherwise to click use the other
                //Console.WriteLine(option.Text);
                //break;
                string item = option.Text;
                if(item.Equals("Item 14"))
                {
                    option.Click();
                }
               

                
            }
        }
    }
}



