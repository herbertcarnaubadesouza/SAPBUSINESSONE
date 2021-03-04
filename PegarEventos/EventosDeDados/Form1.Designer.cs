
namespace EventosDeDados
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridDataEvent = new System.Windows.Forms.DataGrid();
            this.EventData = new System.Data.DataSet();
            this.tblDataEvent = new System.Data.DataTable();
            this.DataColumn1 = new System.Data.DataColumn();
            this.DataColumn2 = new System.Data.DataColumn();
            this.DataColumn3 = new System.Data.DataColumn();
            this.DataColumn4 = new System.Data.DataColumn();
            this.DataColumn5 = new System.Data.DataColumn();
            this.DataColumn6 = new System.Data.DataColumn();
            this.DataColumn7 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridDataEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDataEvent
            // 
            this.GridDataEvent.DataMember = "";
            this.GridDataEvent.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GridDataEvent.Location = new System.Drawing.Point(12, 12);
            this.GridDataEvent.Name = "GridDataEvent";
            this.GridDataEvent.Size = new System.Drawing.Size(775, 418);
            this.GridDataEvent.TabIndex = 0;
            // 
            // EventData
            // 
            this.EventData.DataSetName = "DataSetEvent";
            this.EventData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblDataEvent});
            // 
            // tblDataEvent
            // 
            this.tblDataEvent.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumn1,
            this.DataColumn2,
            this.DataColumn3,
            this.DataColumn4,
            this.DataColumn5,
            this.DataColumn6,
            this.DataColumn7});
            this.tblDataEvent.TableName = "DataEventTable";
            // 
            // DataColumn1
            // 
            this.DataColumn1.Caption = "ActionSucess";
            this.DataColumn1.ColumnName = "ActionSucess";
            // 
            // DataColumn2
            // 
            this.DataColumn2.Caption = "BeforeAction";
            this.DataColumn2.ColumnName = "BeforeAction";
            // 
            // DataColumn3
            // 
            this.DataColumn3.Caption = "EventType";
            this.DataColumn3.ColumnName = "EventType";
            // 
            // DataColumn4
            // 
            this.DataColumn4.Caption = "FormType";
            this.DataColumn4.ColumnName = "FormType";
            // 
            // DataColumn5
            // 
            this.DataColumn5.Caption = "FormUID";
            this.DataColumn5.ColumnName = "FormUID";
            // 
            // DataColumn6
            // 
            this.DataColumn6.Caption = "ObjectKey";
            this.DataColumn6.ColumnName = "ObjectKey";
            // 
            // DataColumn7
            // 
            this.DataColumn7.Caption = "Type";
            this.DataColumn7.ColumnName = "Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridDataEvent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GridDataEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.DataSet EventData;
        private System.Data.DataTable tblDataEvent;
        internal System.Data.DataColumn DataColumn1;
        internal System.Data.DataColumn DataColumn2;
        internal System.Data.DataColumn DataColumn3;
        internal System.Data.DataColumn DataColumn4;
        internal System.Data.DataColumn DataColumn5;
        internal System.Data.DataColumn DataColumn6;
        internal System.Data.DataColumn DataColumn7;
        internal System.Windows.Forms.DataGrid GridDataEvent;
    }
}

