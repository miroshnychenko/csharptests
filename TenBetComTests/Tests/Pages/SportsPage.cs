using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TenBetComTests.Tests.Pages
{
    public class SportsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;


        [FindsBy(How = How.CssSelector, Using = "a[data-dropdown=\"select-language\"]")]
        private IWebElement languageDropdown;
        [FindsBy(How = How.ClassName, Using = "select-lang-code_en")] private IWebElement englishLanguage;

        [FindsBy(How = How.CssSelector, Using = "table[class=\"live_betting_table\"] a[class=\"size_b\"]")]
        private IWebElement betFromML;

        public SportsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        public IWebElement GetLanguageDropdownElement()
        {
            return languageDropdown;
        }
        
        public void ChangeLanguageEN()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(languageDropdown));
            Utils.HoverWebElement(languageDropdown, _driver);
            _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("select-lang-code_en")));
            englishLanguage.Click();
        }

        public void SelectBetFromML()
        {
            betFromML.Click();
        }
    }    
}