using System;
using System.ComponentModel.Composition;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using DevUtilsD365.Kernel;

namespace DevUtilsD365.BusinessEventDataContractBuilder
{
    [Export(typeof(IMainMenu))]
    class DataContractBuilderMenu : MainMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "Developer Tools - BusinessEventDataContract class builder";

        private const string AddinName = "DevUtilsD365.BusinessEventDataContract";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        public override void OnClick(AddinEventArgs e)
        {
            try
            {
                SnippetsParms snippetsParms = new SnippetsParms();
                DataContractBuilderParms runBaseBuilder = new DataContractBuilderParms();

                runBaseBuilder.InitDialogParms(snippetsParms);

                SnippetsDialog dialog = new SnippetsDialog();
                dialog.SetParameters(snippetsParms);
                dialog.Show();
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
    }
    
}
