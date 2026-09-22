using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UIContactConsole
{
    internal class Program
    {
        private static UIContactConsole.Screens.ContactScreen _contactScreen =
                new UIContactConsole.Screens.ContactScreen();
        static void Main(string[] args)
        {
            _contactScreen.Show();
        }
    }
}
