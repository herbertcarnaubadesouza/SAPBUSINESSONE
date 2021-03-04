using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlaSapB1
{
    public class OlaSapB1
    {
        private SAPbouiCOM.Application oApplication;
        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;

            oSboGuiApi = new SAPbouiCOM.SboGuiApi();

            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

            oSboGuiApi.Connect(sConnectionString);

            oApplication = oSboGuiApi.GetApplication(-1);


        }
        public void OlaSapB11()
        {
            SetApplication();

            oApplication.MessageBox("OLÁ SAP B1", 1, "OK", "", "");

           

        }
        public OlaSapB1()
        {
            SetApplication();

            oApplication.MessageBox("OLÁ SAP B1", 1, "OK", "", "");
            oApplication.MessageBox("hERBERT", 1, "OK", "", "");
        }
    }
}
