using DeveloperToolsAddin.Parameters;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveloperToolsAddin
{
    public partial class LabelFileInformation : Form
    {
        public LabelFileInformation()
        {
            InitializeComponent();
            try
            {
                ProjectParameters.InitializeParamsFromFile();

                textBoxProjectPrefix.DataBindings.Add(nameof(textBoxProjectPrefix.Text), ProjectParameters.ParamInstance,
                    nameof(ProjectParameters.ParamInstance.Extension), false,
                    DataSourceUpdateMode.OnPropertyChanged);

                textBoxLabelFile.DataBindings.Add(nameof(textBoxLabelFile.Text), ProjectParameters.ParamInstance,
                  nameof(ProjectParameters.ParamInstance.LabelsFileName), false,
                  DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ee)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ee);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectParameters.ParamInstance.Save();
            this.Close();
        }
    }
}
