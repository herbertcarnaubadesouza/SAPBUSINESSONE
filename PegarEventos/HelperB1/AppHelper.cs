﻿using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperB1
{

    public static class AppHelper
    {
        
        public static void SetApplication(ref SAPbouiCOM.Application pApplication)
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;

            oSboGuiApi = new SAPbouiCOM.SboGuiApi();

            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

            try
            {
                oSboGuiApi.Connect(sConnectionString);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
            pApplication = oSboGuiApi.GetApplication(-1);

            pApplication.SetStatusBarMessage(string.Format("Addon {0} Conectado com sucesso!!!);",
                            System.Windows.Forms.Application.ProductName),
                            BoMessageTime.bmt_Medium
                            , false); ;



        }
    }
}
