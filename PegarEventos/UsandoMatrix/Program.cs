using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsandoMatrix
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            UsandoMatrix oUsandoMatrix = null;
            oUsandoMatrix = new UsandoMatrix();

            System.Windows.Forms.Application.Run();

            
        }
    }
}
