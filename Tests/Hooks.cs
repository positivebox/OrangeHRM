using SpecResults;
using TechTalk.SpecFlow;
using Utils.Driver;
using Utils.Enums;

namespace Tests
{
    [Binding]
    public class Hooks : ReportingStepDefinitions
    {
        [BeforeScenario]
        public void SetupScenario()
        {
            DriverManager.SelectDriver(Browser.Chrome);
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            DriverManager.Driver.Quit();
        }
    }
}
