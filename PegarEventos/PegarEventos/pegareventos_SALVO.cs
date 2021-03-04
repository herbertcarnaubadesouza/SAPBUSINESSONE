//using SAPbouiCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PegarEventos
{
    public class PegarEventos
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.ProgressBar oProgBar;

        public bool BubbleEvent { get; private set; }

        public PegarEventos()
        {
            SetApplication();

            //oApplication.AppEvent += OApplication_AppEvent;

            // oApplication.MenuEvent += OApplication_MenuEvent;

            //oApplication.ItemEvent += OApplication_ItemEvent;

            //oApplication.ProgressBarEvent += OApplication_ProgressBarEvent;
            oApplication.StatusBarEvent += OApplication_StatusBarEvent;

            //ProgressbBarEventos();
            oApplication.SetStatusBarMessage("Mensagem 01",
                             BoMessageTime.bmt_Short
                             , false);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Mensagem 02",
                            BoMessageTime.bmt_Medium
                            , false);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Mensagem 03",
                            BoMessageTime.bmt_Long
                            , false);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Mensagem ERRO 01",
                             BoMessageTime.bmt_Short
                             , true);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Mensagem ERRO 02",
                            BoMessageTime.bmt_Medium
                            , true);
            Thread.Sleep(1000);
            oApplication.SetStatusBarMessage("Mensagem ERRO 03",
                            BoMessageTime.bmt_Long
                            , true);



        }

        private void OApplication_StatusBarEvent(string Text, BoStatusBarMessageType messageType)
        {
            
            oApplication.MessageBox(
                string.Format("Evento de Status Bar com mensagem:{ 0}, MessageType:{1}",Text,messageType.ToString())
                
                ,1,"OK","","");

        }

        private void ProgressbBarEventos()
        {
            oProgBar = oApplication.StatusBar.CreateProgressBar("Minha primeira barra de progresso", 50, true);

            oApplication.SetStatusBarMessage("Barra de Progresso Criada!!!",
                            BoMessageTime.bmt_Short
                            , false);
            oApplication.SetStatusBarMessage("Barra de progresso em frente...",
                            BoMessageTime.bmt_Short
                            , false);



            for (int i = 0; i < 49; i++)
            {
                oProgBar.Value += 1;
                Thread.Sleep(500);

            }
            oApplication.SetStatusBarMessage("Barra de progresso para tras...",
                            BoMessageTime.bmt_Short
                            , false);

            for (int i = 49; 1 > 0; i--)
            {
                oProgBar.Value -= 1;
                Thread.Sleep(500);

            }
            oProgBar.Stop();
            oApplication.SetStatusBarMessage("Barra de progresso Parada!!!",
                            BoMessageTime.bmt_Short
                            , false);
        }

        private void OApplication_ProgressBarEvent(ref ProgressBarEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            oApplication.SetStatusBarMessage("O evento" + pVal.EventType.ToString() + "foi acionado",
                BoMessageTime.bmt_Short
                , false);
           
        }

        private void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if(pVal.FormType != 0)
            {
                BoEventTypes EventEnum = 0;
                EventEnum = pVal.EventType;
                oApplication.SetStatusBarMessage(string.Format(
                    "Evento: {0} ,FormType{1}, FormId :{2}, Before : {3}, ItemUID :{4}"
                    ,EventEnum.ToString()
                    ,pVal.FormType.ToString()
                    ,FormUID
                    ,pVal.BeforeAction.ToString()
                    ,pVal.ItemUID
                    ));

            }
        }

        private void OApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.BeforeAction)
            {
                oApplication.SetStatusBarMessage("Menu Item: " + pVal.MenuUID + "Before", SAPbouiCOM.BoMessageTime.bmt_Long, true);

            }
            else
            {
                oApplication.SetStatusBarMessage("Menu Item:" + pVal.MenuUID + ", Depois", SAPbouiCOM.BoMessageTime.bmt_Long, true);


            }
        }

        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;
            oSboGuiApi = new SAPbouiCOM.SboGuiApi();
            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));
            oSboGuiApi.Connect(sConnectionString);
            oApplication = oSboGuiApi.GetApplication(-1);

        }


        private void OApplication_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    oApplication.MessageBox("A Empresa foi trocada");
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    oApplication.MessageBox("O evento Shut Down foi chamado!!" 
                                            + Environment.NewLine 
                                            + "Fechando o Addon...", 1, "OK", "", "");
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    oApplication.MessageBox("O Idioma Foi modificado");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    oApplication.MessageBox("A fonte foi alterada");
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    oApplication.MessageBox("O Servidor Caiu");
                    System.Windows.Forms.Application.Exit();
                    break;





            }
        }
    }
}
