using OpenQA.Selenium;
using OpenQA.Selenium.BiDi;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace OrangeHRM_Project.Leave
{
   public class LeavePage
    {
        private readonly IWebDriver _driver;

        public LeavePage(IWebDriver driver)
        {
          this._driver = driver;
        }

        // Locators
        //private By PageHeader = By.XPath("//h5[text()='Leave List']");
        //private By SearchButton = By.CssSelector("button[type='submit']");
        //private By ResetButton = By.CssSelector("button.oxd-button--ghost");
        //private By EmployeeNameInput = By.XPath("//label[text()='Employee Name']/../..//input");
        //private By TableBody = By.ClassName("oxd-table-body");

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement _searchButton;
        [FindsBy(How = How.CssSelector, Using = "button.oxd-button--ghost")]
        private IWebElement _resetButton;
        [FindsBy(How = How.XPath, Using = "//h5[text()='Leave List']")]
        private IWebElement _pageHeader;
        [FindsBy(How = How.XPath, Using = "//label[text()='Employee Name']/../..//input")]
        private IWebElement _employeeNameInputBox;
        [FindsBy(How = How.ClassName, Using = "oxd-table-body")]
        private IWebElement _tableBody;
        [FindsBy(How = How.ClassName, Using = "input[class='oxd-input oxd-input--focus']")]
        private IWebElement _datePickerInput;
        [FindsBy(How = How.ClassName, Using = ".oxd-calendar-dates-grid")]
        private IWebElement _calendarGrid;

        [FindsBy(How = How.XPath, Using = "//label[text()='Leave Status']/../..//div[@class='oxd-select-wrapper']")]
        private IWebElement _leaveStatus;
        [FindsBy(How = How.XPath, Using = "//label[text()='Leave Type']/../..//div[@class='oxd-select-wrapper']")]
        private IWebElement _leavetype;
        [FindsBy(How = How.XPath, Using = "//div[@role='listbox']//span[text()='Taken']")]
        private IWebElement _leaveTakenOption;






        // Actions
        //public bool IsHeaderVisible() => _driver.FindElement(_pageHeader).Displayed;

        public void ClickSearchButton()
        {
            _searchButton.Click();
      
        }

        public void ClickResetButton()
        {
            _resetButton.Click();
        }

        public bool IsLeavePageHeaderDisplayed() => _pageHeader.Displayed;
        
       

      public bool IsSearchResultTableDisplayed() => _tableBody.Displayed;

        



        public void EnterEmployeeName(string name)
        {
            _employeeNameInputBox.SendKeys(name);
        }

        public void ClickDatePickerInput()
        {
            _datePickerInput.Click();
        }

        public bool IsDatePickerInputEnabled() => _datePickerInput.Enabled;
        public bool IsDatePickerInputDisplayed() => _datePickerInput.Displayed;

        public bool IsCalendarGridVisible() => _calendarGrid.Displayed;

        public bool IsTableBodyVisible() => _tableBody.Displayed;

        public void SelectDropdownOption(string labelName, string optionText )
        {
            
            // 1. Locate the dropdown based on the label name (e.g., 'Leave Status')
            var dropdown = _driver.FindElement(By.XPath($"//label[text()='{labelName}']/../..//div[@class='oxd-select-text-input']"));
            dropdown.Click();

            // 2. Wait for the options to appear and click the desired text
            var option = _driver.FindElement(By.XPath($"//div[@role='listbox']//span[text()='{optionText}']"));
            option.Click();
        }

        public bool IsLeaveListTableDataInputVisible() => _tableBody.Displayed;

        public bool IsSearchButtonVisibleAndEnabled() => _searchButton.Enabled;
        public bool IsSearchReSetButtonVisibleAndEnabled() => _resetButton.Enabled;

        public bool IsLeaveDataTableVisible() => _tableBody.Displayed;

    }
}
