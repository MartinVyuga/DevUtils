using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.ProjectSupport;
using Exception = System.Exception;

namespace DeveloperToolsAddin.Parameters
{
    /// <summary>
    /// Singleton saves all project parameters
    /// </summary>
    [XmlRoot("ProjectParameters")]
    public class ProjectParameters
    {
        private static ProjectParameters paramInstance;

        private ProjectParameters()
        {
        }

        public static string ParamFilePath { get; set; }

        [XmlElement("Extension")]
        public string Extension { get; set; }

        [XmlElement("LabelFileName")]
        public string LabelsFileName { get; set; }

        public static ProjectParameters ParamInstance
        {
            get { if (paramInstance==null) { paramInstance = new ProjectParameters(){Extension="MyProject", LabelsFileName="MyProject_en-us" };} return paramInstance; }
        }

        public static void InitializeParamsFromFile()
        {

            XmlDocument doc = new XmlDocument();
            var xsSubmit = new XmlSerializer(typeof(ProjectParameters));
            var projectName = Helper.GetActiveProjectNode().Name;
            ParamFilePath =  Path.Combine(Helper.GetActiveProjectNode().ProjectFolder, $"{projectName}.xml");

            if (File.Exists(ParamFilePath))
            {
                doc.Load(ParamFilePath);

                using (TextReader reader = new StringReader(doc.InnerXml))
                {
                    var projParams = (ProjectParameters) xsSubmit.Deserialize(reader);
                    ParamInstance.Extension = projParams.Extension;
                    ParamInstance.LabelsFileName = projParams.LabelsFileName;
                }
            }
            else
            {
                File.Create(ParamFilePath);
            }
        }

        public void Save()
        {
            var serializableObject = ParamInstance;
            try
            {
                var xmlDocument = new XmlDocument();
                var serializer = new XmlSerializer(serializableObject.GetType());
                using (var stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(ParamFilePath);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
    }
}