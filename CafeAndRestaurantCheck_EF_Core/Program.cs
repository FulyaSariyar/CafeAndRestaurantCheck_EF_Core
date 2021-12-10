using CafeAndRestaurantCheck_EF_Core.Forms;

namespace CafeAndRestaurantCheck_EF_Core
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPersonel());
        }
    }
}