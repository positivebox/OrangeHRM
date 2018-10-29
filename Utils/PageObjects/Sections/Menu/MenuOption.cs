using Utils.Elements;
using Utils.Enums;

namespace Utils.Menu
{
    public class MenuOption : Element
    {
        internal MenuOption(string name) : base($"//span[@class='left-menu-title' and text() = '{name}']", SearchBy.Xpath)
        {

        }
    }
}
