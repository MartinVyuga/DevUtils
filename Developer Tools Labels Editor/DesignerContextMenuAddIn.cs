namespace Developer_Tools_Labels_Editor
{
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
    /// This addin is designed to automatically add labels into the label file from properties
    /// </summary>
    // TODO: This addin will show when user right clicks on a form root node or table root node. 
    // If you need to specify any other element, change this AutomationNodeType value.
    // You can specify multiple DesignerMenuExportMetadata attributes to meet your needs
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ITable))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IEdtBase))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseEnum))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseEnumValue))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IBaseField))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldContainer))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldDate))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldEnum))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldGroup))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldGuid))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldInt))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.AX.Metadata.MetaModel.IFieldString))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Microsoft.Dynamics.AX.Metadata.MetaModel.IFieldReal))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldTime))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IFieldUtcDateTime))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(BaseField))]
    public class DesignerContextMenuAddIn : DesignerMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "Scales Label Editor";

        private const string AddinName = "SCAUtilsD365.LabelEditor";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        static DTE2 MyDte => CoreUtility.ServiceProvider.GetService(typeof(DTE)) as DTE2;
        static IServiceProvider ServiceLocator = CoreUtility.ServiceProvider;
        static VSApplicationContext Context => new VSApplicationContext(MyDte.DTE);
        private static Regex newLabelMatcher =
         new Regex("\\A(?<AtSign>\\@)(?<LabelFileId>[a-zA-Z]\\w*):(?<LabelId>[a-zA-Z]\\w*)",
         RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static Regex legacyLabelMatcher =
            new Regex("\\A(?<LabelId>(?<AtSign>\\@)(?<LabelFileId>[a-zA-Z][a-zA-Z][a-zA-Z])\\d+)",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        //These expressions will be used by the following methods.
        private Boolean IsValidLabelId(String labelId)
        {
            bool result = false;

            if (String.IsNullOrEmpty(labelId) == false)
            {
                result = DesignerContextMenuAddIn.IsLegacyLabelId(labelId);
                if (result == false)
                {
                    result = (DesignerContextMenuAddIn.newLabelMatcher.Matches(labelId).Count > 0);
                }
            }

            return result;
        }

        private static Boolean IsLegacyLabelId(String labelId)
        {
            bool result = false;

            if (String.IsNullOrEmpty(labelId) == false)
            {
                result = (DesignerContextMenuAddIn.legacyLabelMatcher.Matches(labelId).Count > 0);
            }

            return result;
        }

        //Handle the click event in the OnClick method.  Here we will test the selected object, get the object’s model and label file, and create the label.
        public override void OnClick(AddinDesignerEventArgs e)
        {
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
                // Is the selected element a table?
                if (e.SelectedElement is ITable)
                {
                    ITable table = e.SelectedElement as ITable;

                    modelInfoCollection = metaModelService.GetTableModelInfo(table.Name);
                    AxLabelFile labelFile = this.GetLabelFile(metaModelProvider, metaModelService, modelInfoCollection);

                    this.createLabel(table, labelFile);
                }
                
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }

        private AxLabelFile GetLabelFile(IMetaModelProviders metaModelProviders, IMetaModelService metaModelService, ModelInfoCollection modelInfoCollection)
        {
            // Choose the first model in the collection
            ModelInfo modelInfo = ((System.Collections.ObjectModel.Collection<ModelInfo>)modelInfoCollection)[0];

            // Construct a ModelLoadInfo
            ModelLoadInfo modelLoadInfo = new ModelLoadInfo
            {
                Id = modelInfo.Id,
                Layer = modelInfo.Layer,
            };

            // Get the list of label files from that model
            IList<String> labelFileNames = metaModelProviders.CurrentMetadataProvider.LabelFiles.ListObjectsForModel(modelInfo.Name);

            // Choose the en-us
            //var labelfile = (from labelFileName in labelFileNames 
            //                    where labelFileName.Contains("en-us")
            //                     select labelFileName).First<String>();
            AxLabelFile labelFile = metaModelService.GetLabelFile(labelFileNames[0], modelLoadInfo);

            return labelFile;
        }

        private void createLabel(ITable table, AxLabelFile labelFile)
        {
            if (this.IsValidLabelId(table.Label) == false)
            {
                table.Label = this.FindOrCreateLabel(table.Label, table.Name, "Label", labelFile);
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
                    field.Label = this.FindOrCreateLabel(field.Label, field.Name,"",labelFile);
                }
                if (!this.IsValidLabelId(field.HelpText))
                {
                    field.HelpText = this.FindOrCreateLabel(field.HelpText, field.Name, "Hlp", labelFile);
                }

            }
            //loop through the fieldgroups
            var fieldGroupsEnumerator = table.FieldGroups.GetEnumerator();
            while (fieldGroupsEnumerator.MoveNext())
            {
                var fieldGroup = fieldGroupsEnumerator.Current as IFieldGroup;
                if (!this.IsValidLabelId(fieldGroup.Label))
                {
                    fieldGroup.Label = this.FindOrCreateLabel(fieldGroup.Label, fieldGroup.Name, "", labelFile);
                }

            }
        }

        private String FindOrCreateLabel(String labelText, String elementName, String propertyName, AxLabelFile labelFile)
        {
            string newLabelId = String.Empty;

            // Don't bother if the string is empty
            if (String.IsNullOrEmpty(labelText) == false)
            {
                // Construct a label id that will be unique
                string labelId = $"{elementName}{propertyName}";

                // Get the label factor
                LabelControllerFactory factory = new LabelControllerFactory();

                // Get the label edit controller
                LabelEditorController labelController = factory.GetOrCreateLabelController(labelFile, DesignerContextMenuAddIn.Context);

                // Make sure the label doesn't exist.
                // What will you do if it does?
                if (labelController.Exists(labelId) == false)
                {
                    labelController.Insert(labelId, labelText, String.Empty);
                    labelController.Save();

                    // Construct a label reference to go into the label property
                    newLabelId = $"@{labelFile.LabelFileId}:{labelId}";
                }
            }

            return newLabelId;
        }
    }
}
