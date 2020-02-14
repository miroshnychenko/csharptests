using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TenBetComTests.Tests.Pages.PageElements
{
    public class Header
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        
        [FindsBy(How = How.Id, Using = "HeaderLogoElement")] private IWebElement logo;
        [FindsBy(How = How.Id, Using = "NewHeaderUsername")] private IWebElement usernameField;
        [FindsBy(How = How.Id, Using = "NewHeaderPassword")] private IWebElement passwordField;
        [FindsBy(How = How.Id, Using = "NewHeaderLoginButton")] private IWebElement loginButton;
        [FindsBy(How = How.CssSelector, Using = "div[data-dropdown=\"customDropdownElement-2\"]")] private IWebElement transferButton;
        

        public Header(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        public IWebElement GetTransferButtonElement()
        {
            return transferButton;
        }

        public void EnterUsername(string username)
        {
            usernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            loginButton.Click();
           
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
            Utils.HoverWebElement(logo, _driver);
        }

    }
}