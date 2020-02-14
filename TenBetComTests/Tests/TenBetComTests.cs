using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TenBetComTests.Tests.Pages;

namespace TenBetComTests.Tests
{
    [TestFixture]
    public class TenBetComTests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private TenBetComSite _site;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            _site = new TenBetComSite(_driver);
            _driver.Navigate().GoToUrl("https://10bet.com");
            _site.FirstVisitPage().ClickOnLogo();
            ClosePushPopup();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver = null;
        }

        [Test]
        public void ClosePushPopup()
        {
            if (_site.PushPopup().VerifyPushPopupIsPresent())
            {
                _site.PushPopup().ClickDoNotAllowButton();
            }
        }

        [Test]
        public void LoginTest()
        {
            _site.Header().Login("10betcomauto", "Password1");
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("BalanceDropdownElement")));
            _wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(
                    By.CssSelector("div[id=\"CustomLinkElement1\"] > a")));
            Assert.True(_driver.FindElement(By.CssSelector("div[id=\"CustomLinkElement1\"] > a")).Text.Equals("10betcomauto"));
        }

        [Test]
        public void ChangeLanguageTest()
        {
            _site.SportsPage().ChangeLanguageEN();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("langIcon")));
            Assert.True(_site.SportsPage().GetLanguageDropdownElement().Text.Equals("English"));
            ClosePushPopup();
        }

        [Test]
        public void PlaceBetFromMLTest()
        {
            LoginTest();
            
            if (_driver.FindElement(By.CssSelector("p[class*=\"clear\"] a")).Displayed)
            {
                _site.BetSlip().ClearBetSlip();
            }
            
            _site.SportsPage().SelectBetFromML();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("singleDepositField")));
            _site.BetSlip().EnterStakeAmount("1");
            _site.BetSlip().ClickPlaceBetsButton();
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(".success, .singleSpecific")));
            Assert.True(_site.BetSlip().CheckBetConfirmation());
        }

        [Test]
        public void CashoutTest()
        {
            LoginTest();
            _site.BetSlip().ClickOnMyBetsTab();
            _site.BetSlip().ClickCashOutButton();
        }

        [Test]
        public void TransferToCasinoTest()
        {
            ChangeLanguageTest();
            LoginTest();
            _site.FundsTransferPopup().TransferToCasino();
            _wait.Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("h2[id=\"lightBoxTopHeader\"]")));
            var transferPopup = _driver.FindElement(By.CssSelector("h2[id=\"lightBoxTopHeader\"]"));
            Assert.True(transferPopup.Displayed);
            var transferOptions = _driver.FindElements(By.CssSelector("#transferFundsFrom option"));
            Assert.True(transferOptions[0].GetAttribute("value").Equals("0"));
            Assert.True(transferOptions[1].GetAttribute("value").Equals("11")); 
        }
    }
}