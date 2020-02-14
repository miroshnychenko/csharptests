using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TenBetComTests.Tests.Pages
{
    public class Utils
    {
        public static void HoverWebElement(IWebElement element, IWebDriver driver)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }
        
        
    }
}