using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TenBetComTests.Tests.Pages.PageElements
{
    public class PushPopup
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        
        [FindsBy(How = How.Id, Using = "webpush-custom-prompt")] private IWebElement pushNotificationPopup;
        [FindsBy(How = How.Id, Using = "webpush-custom-prompt-button1")] private IWebElement doNotAllowButton;
        [FindsBy(How = How.Id, Using = "webpush-custom-prompt-button2")] private IWebElement allowButon;

        public PushPopup(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        public bool VerifyPushPopupIsPresent()
        {
            return pushNotificationPopup.Displayed;
        }

        public void ClickAllowButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(allowButon));
            allowButon.Click();
        }

        public void ClickDoNotAllowButton()
        {
            doNotAllowButton.Click();
        }
    }
}