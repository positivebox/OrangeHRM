using Utils.Elements;
using Utils.Enums;

namespace Utils.PageObjects.Sections
{
    public class DatePicker : BasePageObject
    {
        public Element Today = new Element("//button[contains(@class,'picker__today')]", SearchBy.Xpath);
    }
}
