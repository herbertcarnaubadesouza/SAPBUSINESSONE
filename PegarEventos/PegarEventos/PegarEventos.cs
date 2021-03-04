using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegarEventos
{
    public class PegarEventos
    {
        public PegarEventos()
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

        public PegarEventos()
        {
            SetApplication();

            oApplication.AppEvent += OApplication_AppEvent;
        }

        private void OApplication_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.
            }
        }
    }
    {
    }
}
