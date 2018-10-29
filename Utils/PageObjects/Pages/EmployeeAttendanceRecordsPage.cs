using System.Collections.Generic;
using Utils.Elements;
using Utils.Enums;
using Utils.PageObjects.Sections;

namespace Utils.PageObjects.Pages
{
    public class EmployeeAttendanceRecordsPage : BasePage
    {
        public Element EmployeeName => new Element("attendance[employeeName][empName]", SearchBy.Name);

        public Element Date => new Element("attendance_date", SearchBy.Id);

        public Element ViewButton => new Element("btView", SearchBy.Id);

        public Element AddButton => new Element("btnAdd", SearchBy.Id);

        public Element PinchInOutButton => new Element("//button[contains(@id, 'btnPunch')]", SearchBy.Xpath);

        public List<EmployeeAttendancesTableRow> Attendances
        {
            get
            {
                var rows = new List<EmployeeAttendancesTableRow>();
                for (int i = 1; i <= FindElements("chkSelectRow[]", SearchBy.Name).Count; i++)
                {
                    rows.Add(new EmployeeAttendancesTableRow(i));
                }
                return rows;
            }
        }

        public Element GetEmployeeAutocompleteOption(string value)
        {
            return new Element($"//div[@class='ac_results']/ul/li[text()='{value}']/div", SearchBy.Xpath);
        }
    }
}
