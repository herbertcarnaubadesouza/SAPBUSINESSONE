using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioComplexo
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            FormularioComplexo oFormularioComplexo = null;
            oFormularioComplexo = new FormularioComplexo();

            System.Windows.Forms.Application.Run();


        }
    }
}
