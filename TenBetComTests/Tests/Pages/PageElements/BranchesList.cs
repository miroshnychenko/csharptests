using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TenBetComTests.Tests.Pages.PageElements
{
    public class BranchesList
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/sports/football\"]")] private IWebElement footbalBranch;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/sports/basketball\"]")] private IWebElement basketballBranch;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/sports/cricket\"]")] private IWebElement cricketBranch;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/sports/horse-racing\"]")] private IWebElement horseRacingBranch;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/sports/rugby-league\"]")] private IWebElement rugbyLeagueBranch;

        public BranchesList(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        public void clickFootbalBranch()
        {
            footbalBranch.Click();
        }
        
        public void clickBasketballBranch()
        {
            basketballBranch.Click();
        }
        public void clickCricketBranch()
        {
            cricketBranch.Click();
        }
        public void clickHorseRacingBranch()
        {
            horseRacingBranch.Click();
        }
        public void clickRugbyLeagueBranch()
        {
            rugbyLeagueBranch.Click();
        }

    }
}