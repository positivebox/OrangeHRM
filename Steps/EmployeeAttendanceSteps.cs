using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using Utils.Driver;
using Utils.Menu;
using Utils.Models;
using Utils.PageObjects;
using Utils.PageObjects.Pages;
using Utils.PageObjects.Sections;

namespace Steps
{
    [Binding]
    public class EmployeeAttendanceSteps
    {
        private const string AttendanceKey = "Attendance";

        [Given(@"I navigate to Employee Records page via menu")]
        public void GivenINavigateToEmployeeRecordsPageViaMenu()
        {
            PageManager.LoginPage.MainMenu.Time
                .NavigateTo<TimeMenu>(1).Attendance
                .NavigateTo<AttendanceMenu>(1).EmployeeRecords
                .NavigateToAndWait<EmployeeAttendanceRecordsPage>();

            DriverManager.Driver.SwitchToFrame(BasePage.NonCoreIframe);
        }

        [When(@"I search today attendance for (.*)")]
        public void WhenISearchAttendanceBy(string employee)
        {
            PageManager.EmployeeAttendanceRecords.EmployeeName.SendKeys(employee);
            PageManager.EmployeeAttendanceRecords.EmployeeName.Click();
            PageManager.EmployeeAttendanceRecords.GetEmployeeAutocompleteOption(employee).Click();

            PageManager.EmployeeAttendanceRecords.Date
                .NavigateTo<DatePicker>(1).Today
                .NavigateTo<EmployeeAttendanceRecordsPage>(1).ViewButton
                .ClickAndWait();

            var searchedAttendance = new Attendance
            {
                EmployeeName = employee,
                PunchIn = DateTime.Today
            };
            ScenarioContext.Current.Add(AttendanceKey, searchedAttendance);
        }

        [When(@"I create new attendance")]
        public void WhenICreateNewAttendancePunchIn()
        {
            PageManager.EmployeeAttendanceRecords.AddButton.ClickAndWait();
            PageManager.EmployeeAttendanceRecords.PinchInOutButton.ClickAndWait();
        }

        [Then(@"I verify number of attendance\(s\) in table is (.*)")]
        public void ThenIVerifyNumberOfAttendancesInTableIs(int numberOfAttendances)
        {
            PageManager.EmployeeAttendanceRecords.Attendances.Count
                .Should().Be(numberOfAttendances);
        }

        [Then(@"Attendance data should be present in table")]
        public void ThenAttendanceDataMatchesExpected()
        {
            var expectedAttendance = ScenarioContext.Current.Get<Attendance>(AttendanceKey);

            PageManager.EmployeeAttendanceRecords.Attendances.Should()
                .Contain(attendance => attendance.EmployeeName.GetInnerText()
                .Equals(expectedAttendance.EmployeeName)
                && attendance.PunchIn.GetInnerText()
                .Contains(expectedAttendance.PunchIn.ToString("yyyy-MM-dd")));
        }
    }
}
