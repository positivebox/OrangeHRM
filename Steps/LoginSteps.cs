using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Utils.Models;
using Utils.PageObjects;

namespace Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I open Orange website")]
        public void GivenIOpenToOrangeWebsite()
        {
            PageManager.LoginPage.OpenPage();
        }
        
        [Given(@"I login with credentials")]
        public void GivenILoginAsAdmin(Table table)
        {
            var credentials = table.CreateInstance<Credentials>();

            PageManager.LoginPage.Username.Clear();
            PageManager.LoginPage.Username.SendKeys(credentials.Username);
            PageManager.LoginPage.Password.Clear();
            PageManager.LoginPage.Password.SendKeys(credentials.Password);
            PageManager.LoginPage.LoginButton.ClickAndWait();
        }
    }
}
