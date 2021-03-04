using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventFilter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OBJEventFilter oOBJEventFilter = null;
            oOBJEventFilter = new OBJEventFilter();

            System.Windows.Forms.Application.Run();
        }
    }
}
