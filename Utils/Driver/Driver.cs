using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Utils.Enums;

namespace Utils.Driver
{
    public class Driver
    {
        private readonly IWebDriver _driver;

        internal Driver(Browser browser)
        {
            var assemblyLocation = Path
                .GetDirectoryName(new Uri(Assembly
                    .GetExecutingAssembly()
                    .CodeBase)
                    .LocalPath);
            switch (browser)
            {
                case Browser.Chrome:
                    _driver = new ChromeDriver(assemblyLocation);
                    break;

                default:
                    throw new NotSupportedException($"The browser {browser} is not supported");
            }
        }

        /// <summary>
        /// Opens URL in browser
        /// </summary>
        /// <param name="url">URL to open</param>
        public void OpenUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Finds first element by specified locator
        /// </summary>
        /// <param name="locatorValue">Value of chosen locator</param>
        /// <param name="locator">Locator by which to find the element</param>
        /// <returns>First found element</returns>
        public IWebElement FindElement(string locatorValue, SearchBy locator)
        {
            switch (locator)
            {
                case (SearchBy.Id):
                    return _driver.FindElement(By.Id(locatorValue));

                case (SearchBy.Name):
                    return _driver.FindElement(By.Name(locatorValue));

                case (SearchBy.Xpath):
                    return _driver.FindElement(By.XPath(locatorValue));

                default:
                    throw new NotSupportedException($"Search by {locator} is not supported");
            }
        }

        /// <summary>
        /// Finds all elements by specified locator
        /// </summary>
        /// <param name="locatorValue">Value of chosen locator</param>
        /// <param name="locator">Locator by which to find the element</param>
        /// <returns>List of found element</returns>
        public List<IWebElement> FindElements(string locatorValue, SearchBy locator)
        {
            switch (locator)
            {
                case (SearchBy.Id):
                    return _driver.FindElements(By.Id(locatorValue)).ToList();

                case (SearchBy.Name):
                    return _driver.FindElements(By.Name(locatorValue)).ToList();

                case (SearchBy.Xpath):
                    return _driver.FindElements(By.XPath(locatorValue)).ToList();

                default:
                    throw new NotSupportedException($"Search by {locator} is not supported");
            }
        }

        /// <summary>
        /// Waits for Ajax to finish
        /// </summary>
        /// <param name="timeoutSecs">Time to wait, in seconds</param>
        public void WaitForAjax(int timeoutSecs = 10)
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, timeoutSecs));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
        }

        /// <summary>
        /// Switches driver to specific frame
        /// </summary>
        /// <param name="frameId">Id of the frame (or name)</param>
        public void SwitchToFrame(string frameId)
        {
            _driver.SwitchTo().Frame(frameId);
        }

        /// <summary>
        /// Quits driver
        /// </summary>
        public void Quit()
        {
            _driver.Quit();
        }
    }
}
