using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TenBetComTests.Tests.Pages.PageElements
{
    public class BetSlip
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        
        [FindsBy(How = How.ClassName, Using = "singleDepositField")] private IWebElement stakeAmountInput;
        [FindsBy(How = How.CssSelector, Using = "p[class*=\"clear\"] a")] private IWebElement clearBetSlipButton;
        [FindsBy(How = How.Id, Using = "PlaceBetButton")] private IWebElement placeBetButton;
        [FindsBy(How = How.CssSelector, Using = ".success, .singleSpecific")] private IWebElement betConfirmation;
        [FindsBy(How = How.Id, Using = "betting_slip_sliptab")] private IWebElement bettingSlipTab;
        [FindsBy(How = How.Id, Using = "betting_slip_mybetstab")] private IWebElement myBetsTab;
        [FindsBy(How = How.CssSelector, Using = "button[id*=\"mainCashoutBtn\"]")] private IWebElement cashOutButton;

        public BetSlip(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromMinutes(30));
            PageFactory.InitElements(driver, this);
        }

        public void ClearBetSlip()
        {
            clearBetSlipButton.Click();
        }

        public void EnterStakeAmount(string amount)
        {
            stakeAmountInput.Clear();
            stakeAmountInput.SendKeys(amount);
        }

        public void ClickPlaceBetsButton()
        {
            placeBetButton.Click();
        }

        public bool CheckBetConfirmation()
        {
            return betConfirmation.Displayed;
        }

        public void ClickOnBettingSlipTab()
        {
            bettingSlipTab.Click();
        }

        public void ClickOnMyBetsTab()
        {
            myBetsTab.Click();
        }

        public void ClickCashOutButton()
        {
            IList <IWebElement> cashOutButtons = _driver.FindElements(By.CssSelector("button[id*=\"mainCashoutBtn\"]"));
            foreach (var IWeblement in cashOutButtons)
            {
                if (!IWeblement.Displayed) continue;
                IWeblement.Click();
                IWeblement.Click();
                break;
            }
        }
    }
}