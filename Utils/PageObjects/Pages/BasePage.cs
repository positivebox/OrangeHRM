using System.Collections.Generic;
using Utils.Driver;
using Utils.Elements;
using Utils.Enums;
using Utils.Menu;

namespace Utils.PageObjects.Pages
{
    public abstract class BasePage : BasePageObject
    {
        public const string NonCoreIframe = "noncoreIframe";

        public MainMenu MainMenu = new MainMenu();

        public string Url { get; protected set; }

        public void OpenPage()
        {
            DriverManager.Driver.OpenUrl(Url);
        }

        public List<Element> FindElements(string locatorValue, SearchBy locator = SearchBy.Id)
        {
            var elements = new List<Element>();

            DriverManager.Driver.FindElements(locatorValue, locator)
                .ForEach(element => elements.Add(new Element(element)));

            return elements;
        }
    }
}
