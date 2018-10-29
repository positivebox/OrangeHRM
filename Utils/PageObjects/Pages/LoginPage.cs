using Utils.Elements;
using Utils.Enums;

namespace Utils.PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        internal LoginPage()
        {
            Url = "https://orangehrm-demo-6x.orangehrmlive.com";
        }

        public Element Username => new Element("txtUsername", SearchBy.Id);

        public Element Password => new Element("txtPassword", SearchBy.Id);

        public Element LoginButton => new Element("btnLogin", SearchBy.Id);
    }
}