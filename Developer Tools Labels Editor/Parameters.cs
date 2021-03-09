using System;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace Developer_Tools_Labels_Editor.Parameters
{
    public partial class Parameters : Form
    {
        public Parameters()
        {
            InitializeComponent();

            try
            {
                ProjectParameters.Contruct();

                ProjectExtensionTB.DataBindings.Add(nameof(ProjectExtensionTB.Text), ProjectParameters.Instance,
                    nameof(ProjectParameters.Instance.Extension), false,
                    DataSourceUpdateMode.OnPropertyChanged);

                DefaultLabelsFileNameTB.DataBindings.Add(nameof(DefaultLabelsFileNameTB.Text), ProjectParameters.Instance,
                  nameof(ProjectParameters.Instance.DefaultLabelsFileName), false,
                  DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ee)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ee);
            }
        }

        public string Xml { get; set; }

        private void SaveParameters_Click(object sender, EventArgs e)
        {
            ProjectParameters.Instance.Save();
            this.Close();
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Parameters
        //    // 
        //    this.ClientSize = new System.Drawing.Size(984, 496);
        //    this.Name = "Parameters";
        //    this.ResumeLayout(false);

        //}
    }
}