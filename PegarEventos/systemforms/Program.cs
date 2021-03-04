using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systemforms
{
    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            frmPedidoDeVenda ofrmPedidoDeVenda = new frmPedidoDeVenda();
            System.Windows.Forms.Application.Run();
        }
    }
}

