using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TenBetComTests.Tests.Pages
{
    public class FirstVisitPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/\"]")] public IWebElement logo;

        public FirstVisitPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        public void ClickOnLogo()
        {
            logo.Click();
        }
    }
}