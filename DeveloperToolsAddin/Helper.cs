using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EnvDTE;
using EnvDTE80;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.AX.Metadata.Service;
using Microsoft.Dynamics.Framework.Tools;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.Labels;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.ProjectSupport;
using Microsoft.Dynamics.Framework.Tools.ProjectSystem;
using System.Threading.Tasks;
using DeveloperToolsAddin.Parameters;

namespace DeveloperToolsAddin
{
    static class Helper
    {
        static Helper()
        {

            var metaModelProviders = CoreUtility.ServiceProvider.GetService(typeof(IMetaModelProviders)) as IMetaModelProviders;
            MetaService = metaModelProviders?.CurrentMetaModelService;

            //ProjectService = CoreUtility.ServiceProvider.GetService(typeof(IDynamicsProjectService)) as IDynamicsProjectService;
            ElementService = CoreUtility.ServiceProvider.GetService(typeof(IDisplayElementProvider)) as IDisplayElementProvider;


        }

        public static IDisplayElementProvider ElementService { get; }
        public static IMetaModelService MetaService { get; }
        //public static IDynamicsProjectService ProjectService { get; }

        // DTE interface represents Visual Studio object model and offers access to many related
        // objects and methods.
        // This is not anything specific to Dynamics AX.
        public static DTE2 MyDte => CoreUtility.ServiceProvider.GetService(typeof(DTE)) as DTE2;


        public static VSApplicationContext Context => new VSApplicationContext(MyDte.DTE);

        /// <summary>
        ///     Gets the currently selected project in Visual Studio.
        /// </summary>
        /// <returns>The selected project node, if any; otherwise null.</returns>
        public static VSProjectNode GetActiveProjectNode()
        {
            var projects = MyDte.ActiveSolutionProjects as Array;

            if (projects?.Length > 0)
            {
                Project project = projects.GetValue(0) as Project;
                return project?.Object as VSProjectNode;
            }
            return null;
        }

        /// <summary>
        ///     Gets the currently selected project in Visual Studio.
        /// </summary>
        /// <returns>The selected project node, if any; otherwise null.</returns>
        public static Project GetActiveProject()
        {
            var projects = MyDte.ActiveSolutionProjects as Array;

            if (projects?.Length > 0)
            {
                var project = projects.GetValue(0) as Project;
                return project;
            }
            return null;
        }


        public static ModelSaveInfo GetModel()
        {

            var modelInfo = GetActiveProjectNode().GetProjectsModelInfo();

            var model = new ModelSaveInfo
            {
                Id = modelInfo.Id,
                Layer = modelInfo.Layer
            };
            return model;
        }

        public static string ToCamelCase(this string txt)
        {
            return char.ToLowerInvariant(txt[0]) + txt.Substring(1);
        }

        public static VSProjectNode ProjectNode =Helper.GetActiveProjectNode();

        public static IMetaModelProviders MetaModelProviders = CoreUtility.ServiceProvider.GetService(typeof(IMetaModelProviders)) as IMetaModelProviders;
        public static IMetaModelService MetaModelService = MetaModelProviders?.CurrentMetaModelService;

        private static string UppercaseFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public static string Convert(this string name, string alternative = null)
        {
            var Project = GetActiveProjectNode();

            MetaModelProviders = CoreUtility.ServiceProvider.GetService(typeof(IMetaModelProviders)) as IMetaModelProviders;
            if (MetaModelProviders != null)
                MetaModelService = MetaModelProviders.CurrentMetaModelService;
            AxLabelFile labelFile = GetLabelFile(MetaModelProviders, MetaModelService);
            if (labelFile == null)
                throw new Exception("Labels file not found");
            var extension = labelFile.LabelFileId;
            var labelKey = name.Replace(extension, "");
            string lableTxt;

            if (alternative != null && !alternative.StartsWith("@"))
                lableTxt = alternative;
            else
                lableTxt = Regex.Replace(labelKey, "((?<=[a-z])[A-Z]|[A-Z](?=[a-z]))", " $1").Trim().ToLower().UppercaseFirst();

            Microsoft.Dynamics.Framework.Tools.Labels.LabelControllerFactory factory = new LabelControllerFactory();
            LabelEditorController labelEditorController = factory.GetOrCreateLabelController(labelFile, Helper.Context);

            if (!labelEditorController.Exists(labelKey))
            {
                labelEditorController.Insert(labelKey, lableTxt, string.Empty);
                labelEditorController.Save();
            }

            return $"@{extension}:{labelKey}";
        }
        private static AxLabelFile GetLabelFile(IMetaModelProviders metaModelProviders, IMetaModelService metaModelService)
        {
            //var extension = ProjectParameters.ParamInstance.Extension;
            //var defaultLablesFileName = ProjectParameters.ParamInstance.LabelsFileName;
            String labelFilesString = "Label Files";
            var projItems = Helper.GetActiveProject().ProjectItems.Item(labelFilesString);
            //always selects the first of the labels
            var enumerator = projItems.ProjectItems.GetEnumerator();
            ProjectItem projlabelfile = null;
            if (enumerator.MoveNext())
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

    }
}
