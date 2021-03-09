namespace DeveloperToolsAddin
{
    using Menu = Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Menus;
    using System;
    using System.Linq;
    using System.ComponentModel.Composition;
    using Microsoft.Dynamics.AX.Metadata.Core;
    using Microsoft.Dynamics.Framework.Tools.Extensibility;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
    using System.Text.RegularExpressions;
    using Microsoft.Dynamics.AX.Metadata.MetaModel;
    using Microsoft.Dynamics.AX.Metadata.Service;
    using System.Collections.Generic;
    using Microsoft.Dynamics.Framework.Tools.Labels;
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Menus;
    using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.BaseTypes;

    /// <summary>
    /// TODO: Say a few words about what your AddIn is going to do
    /// </summary>
    [Export(typeof(IDesignerMenu))]
    // TODO: This addin will show when user right clicks on a form root node or table root node. 
    // If you need to specify any other element, change this AutomationNodeType value.
    // You can specify multiple DesignerMenuExportMetadata attributes to meet your needs
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITable))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITableExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseField))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IEdtEnum))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITableExtensionHasBaseFields))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITable))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITableExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFormExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IEdtBase))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IEdtExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseEnum))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseEnumExtension))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseEnumValue))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseField))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITableExtensionHasBaseFields))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldContainer))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldDate))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldEnum))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldGroup))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldGuid))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldInt))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.AX.Metadata.MetaModel.IFieldReal))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldTime))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.AX.Metadata.MetaModel.IFieldString))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldUtcDateTime))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(BaseField))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IMenuItemDisplay))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Menu.IMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IMenuItemAction))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IMenuItemOutput))]
    public class DesignerContextMenuAddIn : DesignerMenuBase
    {
        #region Member variables
        private const string addinName = "DesignerDeveloperToolsAddin";
        static DTE2 MyDte => CoreUtility.ServiceProvider.GetService(typeof(DTE)) as DTE2;
        static IServiceProvider ServiceLocator = CoreUtility.ServiceProvider;
        static VSApplicationContext Context => new VSApplicationContext(MyDte.DTE);
        private static Regex newLabelMatcher =
         new Regex("\\A(?<AtSign>\\@)(?<LabelFileId>[a-zA-Z]\\w*):(?<LabelId>[a-zA-Z]\\w*)",
         RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static Regex legacyLabelMatcher =
            new Regex("\\A(?<LabelId>(?<AtSign>\\@)(?<LabelFileId>[a-zA-Z][a-zA-Z][a-zA-Z])\\d+)",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);
        #endregion

        #region Properties
        /// <summary>
        /// Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption
        {
            get
            {
                return AddinResources.DesignerAddinCaption;
            }
        }

        /// <summary>
        /// Unique name of the add-in
        /// </summary>
        public override string Name
        {
            get
            {
                return DesignerContextMenuAddIn.addinName;
            }
        }
        #endregion

        #region Callbacks
        /// <summary>
        /// Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        public override void OnClick(AddinDesignerEventArgs e)
        {
            //ProjectParameters.InitializeParamsFromFile();


            ModelInfoCollection modelInfoCollection = null;

            IMetaModelService metaModelService = null;
            // Get the metamodel provider
            var metaModelProvider = CoreUtility.ServiceProvider.GetService(typeof(IMetaModelProviders)) as IMetaModelProviders;
            metaModelService = metaModelProvider?.CurrentMetaModelService;
            if (metaModelProvider != null)
            {
                // Get the metamodel service
                metaModelService = metaModelProvider.CurrentMetaModelService;
            }
            try
            {
                // TODO: Do your magic for your add-in
                if (e.SelectedElement is ITable)
                {
                    var table = e.SelectedElement as ITable;

                    modelInfoCollection = metaModelService.GetTableModelInfo(table.Name);
                    AxLabelFile labelFile = this.GetLabelFile(metaModelProvider, metaModelService, modelInfoCollection);

                    this.createLabel(table, labelFile);
                }
                if (e.SelectedElement is ITableExtension)
                {
                    var table = e.SelectedElement as ITableExtension;

                    modelInfoCollection = metaModelService.GetTableModelInfo(table.Name);
                    AxLabelFile labelFile = this.GetLabelFile(metaModelProvider, metaModelService, modelInfoCollection);

                    this.createLabel(table, labelFile);
                }
                //On base Enum
                if (e.SelectedElement is IBaseEnum)
                {
                    var @enum = e.SelectedElement as IBaseEnum;
                    @enum.Label = @enum.Name.Convert();
                }
                //Base enum value
                if (e.SelectedElement is IBaseEnumValue)
                {
                    var menu = e.SelectedElement as IBaseEnumValue;
                    menu.Label = menu.Name.Convert();

                }
                //ON base edt
                if (e.SelectedElement is IEdtBase)
                {
                    var edt = e.SelectedElement as IEdtBase;
                    edt.Label = edt.Name.Convert();
                    if (!this.IsValidLabelId(edt.HelpText))
                    {
                        modelInfoCollection = metaModelService.GetTableModelInfo(edt.Name);
                        AxLabelFile labelFile = this.GetLabelFile(metaModelProvider, metaModelService, modelInfoCollection);
                        edt.HelpText = this.FindOrCreateLabel(edt.HelpText, edt.Name, "Hlp", labelFile);
                    }
                }
                //On base field
                if (e.SelectedElement is IBaseField)
                {
                    var edt = e.SelectedElement as IBaseField;
                    edt.Label = edt.Name.Convert();
                    if (!this.IsValidLabelId(edt.HelpText))
                    {
                        modelInfoCollection = metaModelService.GetTableModelInfo(edt.Name);
                        AxLabelFile labelFile = this.GetLabelFile(metaModelProvider, metaModelService, modelInfoCollection);
                        edt.HelpText = this.FindOrCreateLabel(edt.HelpText, edt.Name, "Hlp", labelFile);
                    }
                }
                //Menu item display
                if (e.SelectedElement is Menu.IMenuItemDisplay)
                {
                    var menu = e.SelectedElement as Menu.IMenuItemDisplay;
                    menu.Label = menu.Name.Convert();

                    if (!this.IsValidLabelId(menu.HelpText))
                    {
                        modelInfoCollection = metaModelService.GetTableModelInfo(menu.Name);
                        AxLabelFile labelFile = this.GetLabelFile(metaModelProvider, metaModelService, modelInfoCollection);
                        menu.HelpText = this.FindOrCreateLabel(menu.HelpText, menu.Name, "Hlp", labelFile);
                    }
                }
                //menu item output
                if (e.SelectedElement is Menu.IMenuItemOutput)
                {
                    var menu = e.SelectedElement as Menu.IMenuItemOutput;
                    menu.Label = menu.Name.Convert();
                    if (!this.IsValidLabelId(menu.HelpText))
                    {
                        modelInfoCollection = metaModelService.GetTableModelInfo(menu.Name);
                        AxLabelFile labelFile = this.GetLabelFile(metaModelProvider, metaModelService, modelInfoCollection);
                        menu.HelpText = this.FindOrCreateLabel(menu.HelpText, menu.Name, "Hlp", labelFile);
                    }
                }
                //Menu
                if (e.SelectedElement is Menu.IMenu)
                {
                    var menu = e.SelectedElement as Menu.IMenu;
                    menu.Label = menu.Name.Convert();

                }
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
        #endregion

        #region helper methods

        private AxLabelFile GetLabelFile(IMetaModelProviders metaModelProviders, IMetaModelService metaModelService, ModelInfoCollection modelInfoCollection)
        {
            //var extension = ProjectParameters.ParamInstance.Extension;
            //var defaultLablesFileName = ProjectParameters.ParamInstance.LabelsFileName;
            String labelFilesString = "Label Files";
            var projItems = Helper.GetActiveProject().ProjectItems.Item(labelFilesString);
            //always selects the first of the labels
            var enumerator = projItems.ProjectItems.GetEnumerator();
            ProjectItem projlabelfile=null;
            if(enumerator.MoveNext())
            { 
                projlabelfile = enumerator.Current as ProjectItem;
            }

            var labelfilename = projlabelfile.Name;

            if (string.IsNullOrEmpty(labelfilename))
                throw new System.Exception(
                    string.Format("Label not found in active project: {0}", Helper.GetActiveProject().Name));

            AxLabelFile labelFile = metaModelService.GetLabelFile(labelfilename);

            if (labelFile == null)
                throw new Exception(string.Format("Label file {0} not found in metamodel service", labelFile));

            return labelFile;
        }

        private void createLabel(ITable table, AxLabelFile labelFile)
        {
            if (this.IsValidLabelId(table.Label) == false)
            {
                table.Label = this.FindOrCreateLabel(table.Label, table.Name, "Lbl", labelFile);
            }

            if (this.IsValidLabelId(table.DeveloperDocumentation) == false)
            {
                table.DeveloperDocumentation = this.FindOrCreateLabel(table.DeveloperDocumentation, table.Name, "DeveloperDocumentation", labelFile);
            }
            //loop through the fields
            var fieldsEnumerator = table.DataContractFields.GetEnumerator();
            while (fieldsEnumerator.MoveNext())
            {
                var field = fieldsEnumerator.Current as IBaseField;
                if (!this.IsValidLabelId(field.Label))
                {
                    field.Label = this.FindOrCreateLabel(field.Label, $"{table.Name}{field.Name}", "Lbl", labelFile);
                }
                if (!this.IsValidLabelId(field.HelpText))
                {
                    field.HelpText = this.FindOrCreateLabel(field.HelpText, $"{table.Name}{field.Name}", "Hlp", labelFile);
                }

            }
            //loop through the fieldgroups
            var fieldGroupsEnumerator = table.FieldGroups.GetEnumerator();
            while (fieldGroupsEnumerator.MoveNext())
            {
                var fieldGroup = fieldGroupsEnumerator.Current as IFieldGroup;
                if (!this.IsValidLabelId(fieldGroup.Label))
                {
                    fieldGroup.Label = this.FindOrCreateLabel(fieldGroup.Label, $"{table.Name}{fieldGroup.Name}", "lbl", labelFile);
                }

            }
        }
        private void createLabel(ITableExtension table, AxLabelFile labelFile)
        {
            //loop through the fields
            var fieldsEnumerator = table.DataContractFields.GetEnumerator();
            while (fieldsEnumerator.MoveNext())
            {
                var field = fieldsEnumerator.Current as IBaseField;
                if (!this.IsValidLabelId(field.Label))
                {
                    field.Label = this.FindOrCreateLabel(field.Label, $"{table.Name}{field.Name}", "Lbl", labelFile);
                }
                if (!this.IsValidLabelId(field.HelpText))
                {
                    field.HelpText = this.FindOrCreateLabel(field.HelpText, $"{table.Name}{field.Name}", "Hlp", labelFile);
                }

            }
            //loop through the fieldgroups
            var fieldGroupsEnumerator = table.FieldGroups.GetEnumerator();
            while (fieldGroupsEnumerator.MoveNext())
            {
                var fieldGroup = fieldGroupsEnumerator.Current as IFieldGroup;
                if (!this.IsValidLabelId(fieldGroup.Label))
                {
                    fieldGroup.Label = this.FindOrCreateLabel(fieldGroup.Label, $"{table.Name}{fieldGroup.Name}", "lbl", labelFile);
                }

            }
        }

        private String FindOrCreateLabel(String labelText, String elementName, String propertyName, AxLabelFile labelFile)
        {
            string newLabelId = String.Empty;

            // Don't bother if the string is empty
            if (!String.IsNullOrEmpty(labelText))
            {
                // Construct a label id that will be unique: elementname:propertyname
                string labelId = $"{elementName}{propertyName}";

                // Get the label factor
                LabelControllerFactory factory = new LabelControllerFactory();

                // Get the label edit controller
                LabelEditorController labelController = factory.GetOrCreateLabelController(labelFile, DesignerContextMenuAddIn.Context);

                // Make sure the label doesn't exist.
                // What will you do if it does?We reassign it
                if (!labelController.Exists(labelId))
                {
                    labelController.Insert(labelId, labelText, String.Empty);
                    labelController.Save();

                    // Construct a label reference to go into the label property
                    newLabelId = $"@{labelFile.LabelFileId}:{labelId}";
                }
                else
                {
                    var label = labelController.Labels.Where<Label>(thlabel=> thlabel.ID==labelId).First<Label>();
                    label.Text = labelText;
                    //labelController.Insert(labelId, labelText, String.Empty);
                    labelController.Save();
                    newLabelId = $"@{labelFile.LabelFileId}:{label.ID}";
                }
            }

            return newLabelId;
        }
        /// <summary>
        /// testing reg ex against new labels
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        private Boolean IsValidLabelId(String labelId)
        {
            bool result = false;

            if (!String.IsNullOrEmpty(labelId))
            {
                //maybe it is a legacy label?
                result = DesignerContextMenuAddIn.IsLegacyLabelId(labelId);
                if (!result)
                {
                    result = (DesignerContextMenuAddIn.newLabelMatcher.Matches(labelId).Count > 0);
                }
            }

            return result;
        }
        /// <summary>
        /// testing reg ex against old labels
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        private static Boolean IsLegacyLabelId(String labelId)
        {
            bool result = false;

            if (!String.IsNullOrEmpty(labelId))
            {
                result = (DesignerContextMenuAddIn.legacyLabelMatcher.Matches(labelId).Count > 0);
            }

            return result;
        }
        #endregion
    }
}
