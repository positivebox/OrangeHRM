using Utils.Elements;
using Utils.Enums;

namespace Utils.PageObjects.Sections
{
    public class EmployeeAttendancesTableRow : BasePageObject
    {
        public Element EmployeeName { get; private set; }
        public Element PunchIn { get; private set; }

        public EmployeeAttendancesTableRow(int index)
        {
            EmployeeName = new Element($"//table[@id='resultTable']/tbody/tr[{index}]/td[2]", SearchBy.Xpath);
            PunchIn = new Element($"//table[@id='resultTable']/tbody/tr[{index}]/td[3]", SearchBy.Xpath);
        }
    }
}
