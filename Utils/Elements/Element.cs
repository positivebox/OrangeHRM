using System.Threading;
using OpenQA.Selenium;
using Utils.Driver;
using Utils.Enums;
using Utils.PageObjects;

namespace Utils.Elements
{
    public class Element
    {
        private readonly IWebElement _element;

        internal Element(string locatorValue, SearchBy locator)
        {
            _element = DriverManager.Driver.FindElement(locatorValue, locator);
        }

        internal Element(IWebElement webElement)
        {
            _element = webElement;
        }

        /// <summary>
        /// Gets the inner text of the element
        /// </summary>
        /// <returns>Element inner text</returns>
        public string GetInnerText()
        {
            return _element.Text;
        }

        /// <summary>
        /// Types to element
        /// </summary>
        /// <param name="text">Text to type</param>
        public void SendKeys(string text)
        {
            _element.SendKeys(text);
        }

        /// <summary>
        /// Clears element content
        /// </summary>
        public void Clear()
        {
            _element.Clear();
        }

        /// <summary>
        /// Performs click on element
        /// </summary>
        public void Click()
        {
            _element.Click();
        }

        /// <summary>
        /// Performs click on element and waits for Ajax
        /// </summary>
        public void ClickAndWait()
        {
            _element.Click();
            DriverManager.Driver.WaitForAjax();
        }

        /// <summary>
        /// Performs navigation to page object
        /// </summary>
        /// <typeparam name="T">Type of PageObject returned after navigation</typeparam>
        /// <param name="timeoutSecs">Time to wait after navigation is performed (in seconds)</param>
        /// <returns>PageObject returned after navigation</returns>
        public T NavigateTo<T>(int timeoutSecs = 0) where T : BasePageObject, new()
        {
            _element.Click();
            if (timeoutSecs != 0)
            {
                Thread.Sleep(timeoutSecs * 1000);
            }
            return new T();
        }

        /// <summary>
        /// Performs navigation to page object and waits for Ajax
        /// </summary>
        /// <typeparam name="T">Type of PageObject returned after navigation</typeparam>
        /// <returns>PageObject returned after navigation</returns>
        public T NavigateToAndWait<T>() where T : BasePageObject, new()
        {
            _element.Click();
            DriverManager.Driver.WaitForAjax();
            return new T();
        }
    }
}
