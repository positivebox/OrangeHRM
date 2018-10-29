using Utils.PageObjects.Pages;

namespace Utils.PageObjects
{
    public static class PageManager
    {
        public static LoginPage LoginPage => new LoginPage();

        public static EmployeeAttendanceRecordsPage EmployeeAttendanceRecords => new EmployeeAttendanceRecordsPage();
    }
}
