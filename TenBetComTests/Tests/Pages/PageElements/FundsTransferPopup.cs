using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TenBetComTests.Tests.Pages.PageElements
{
    public class FundsTransferPopup
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Header _header;
        
        [FindsBy(How = How.CssSelector, Using = "a[href*=\"transferToCasino\"]")] private IWebElement tranferToCasio;
        [FindsBy(How = How.CssSelector, Using = "a[href*=\"transferToSports\"]")] private IWebElement tranferToSports;

        public FundsTransferPopup(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            _header = new Header(driver);
            PageFactory.InitElements(driver, this);
        }

       public void TransferToCasino()
        {
            _wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(
                    By.CssSelector("div[data-dropdown=\"customDropdownElement-2\"]")));
            Utils.HoverWebElement(_header.GetTransferButtonElement(), _driver);
            _wait.Until(ExpectedConditions.ElementToBeClickable(tranferToCasio));
            tranferToCasio.Click();
        }
        public void TransferToSports()
        {
            Utils.HoverWebElement(_header.GetTransferButtonElement(), _driver);
            tranferToSports.Click();
        }
    }
}