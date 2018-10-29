using Utils.Enums;

namespace Utils.Driver
{
    public static class DriverManager
    {
        public static Driver Driver;

        public static void SelectDriver(Browser browser)
        {
            Driver = new Driver(browser);
        }
    }
}
