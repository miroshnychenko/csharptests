using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TenBetComTests.Tests.Pages.PageElements;

namespace TenBetComTests.Tests.Pages
{
    public class TenBetComSite
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public TenBetComSite(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public FirstVisitPage FirstVisitPage()
        {
            return new FirstVisitPage(_driver);
        }

        public SportsPage SportsPage()
        {
            return new SportsPage(_driver);
        }

        public BetSlip BetSlip()
        {
            return new BetSlip(_driver);
        }

        public Header Header()
        {
            return new Header(_driver);
        }
        
        public FundsTransferPopup FundsTransferPopup()
        {
            return new FundsTransferPopup(_driver);
        }

        public PushPopup PushPopup()
        {
            return new PushPopup(_driver);
        }
    }
}