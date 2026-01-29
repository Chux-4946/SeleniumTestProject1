using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Project.Pages
{
  public  class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
           this._driver = driver;
        }

        //Locators
        
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement _txtPassword;
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement _txtUserName;
        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement _btnLogin;

        //Actions
        public void Login(string username, string password)
        {
            _txtUserName.Click();
            _txtUserName.SendKeys(username);
            _txtPassword.Click();
            _txtPassword.SendKeys(password);
            _btnLogin.Submit();
        }
    }
}
