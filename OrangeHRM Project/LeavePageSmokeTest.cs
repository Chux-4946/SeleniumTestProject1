using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM_Project.Leave;
using OrangeHRM_Project.Pages;


namespace OrangeHRM_Project
{
    //As this is a smoke test of Leave Page of OrangeHRM, my objective is to test primary requirements of the page/build-
    //in other words, the important features of the page/build. In this case I chose to test feature I think are mission-critical:
    // 1. Verify that the page loads correctly with all required features, if page does not load and dsplayed correctly, page features will not render.
    // 2. Verify Search button as this important for search once alll required field are filled during search.
    // 3. Verify Search Reset button as this enable Leave form to reset to default after each search or before or during search actions.
    // 4. Verify Datepicker as this is important feature for every search in the Leave page- every employee leave search requires a date .
    // 5. Verify Leave data table loads correctly, this is important because employees Leaves can be search when form loads.
    // 6. Verify Leave filter dropdown, this is important because it enable specific Leave Status and Leave Type search
    // All the features mentioned above are thought to be critical feature of Leave page as a result before any rigorous test,
    // these features should function before QA further functional/system test on the build(Leave Page). 
    public class LeavePageSmokeTests
    {
        private IWebDriver driver;
        private LeavePage leavePage;
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Go To OrangeHRM URL, Enter Login Details To Login 
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/leave/viewLeaveList");

            //Initialise LoginPage & Login 
            loginPage = new LoginPage(driver);
            loginPage.Login("Admin", "admin123");

            // Ensure login is successful by checking for the Dashboard header
            Assert.That(driver.Url.Contains("dashboard"));

            //Navigate To LeavePage
            leavePage = new LeavePage(driver);
        }

        [Test]
        public void VerifyleavePageLoads()
        {
            //Arrange & Act - Navigate To Leave Menu & Click
            By LeaveMenu = By.CssSelector("a[href*='viewLeaveModule']");
            driver.FindElement(LeaveMenu).Click();

            //Assert
            leavePage.IsLeavePageHeaderDisplayed()
               .Should()
               .BeTrue();
        }

        [Test]
        public void VerifySearchLoads()
        {
            //Act
            leavePage.ClickSearchButton();

            //Assert
            leavePage.IsSearchResultTableDisplayed()
                .Should()
                .BeTrue();
        }

        [Test]
        public void VerifyDatePickerLoads()
        {
            //Act
            leavePage.ClickDatePickerInput();

            //Assert
            leavePage.IsDatePickerInputDisplayed()
                .Should()
                .BeTrue();
        }

        [Test]
        public void VerifySearchButtonVisible()
        {
            //Assert
            leavePage.IsSearchButtonVisibleAndEnabled()
                .Should()
                .BeTrue();
        }

        [Test]
        public void VerifySearchResetButtonVisible()
        {
            //Assert
            leavePage.IsSearchReSetButtonVisibleAndEnabled()
                .Should()
                .BeTrue();
        }

        [Test]
        public void VerifyLeaveDataTableLoads()
        {
            //Act
            leavePage.IsLeaveDataTableVisible()
                .Should()
                .BeTrue();
        }

        [Test]
        public void VerifyLeaveByStausAndType()
        {

            //Arrange
            // Select 'Taken' from the Leave Status multi-select dropdown Menu
            leavePage.SelectDropdownOption("Leave Status", "Taken");

            // Select 'CAN - Vacation' from the Leave Type dropdown Menu
            leavePage.SelectDropdownOption("Leave Type", "CAN - Vacation");

            //Act
            leavePage.ClickSearchButton();

            //Assert
            leavePage.IsTableBodyVisible()
                .Should()
                .BeTrue();
        }

        [Test]
        public void VerifyResetButton()
        {
            //Arrange
            // Select 'Taken' from the Leave Status multi-select dropdown Menu
            leavePage.SelectDropdownOption("Leave Status", "Taken");

            // Select 'CAN - Vacation' from the Leave Type dropdown Menu
            leavePage.SelectDropdownOption("Leave Type", "CAN - Vacation");
            leavePage.EnterEmployeeName("Anna Maria");

            //Act
            leavePage.ClickResetButton();

            //Assert
            leavePage.IsLeaveListTableDataInputVisible()
                .Should()
                .BeFalse();

        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            
        }
    }
}