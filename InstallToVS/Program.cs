using System;
using System.Collections;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace InstallToVS
{
    class Program
    {
        private const string DevUtilsDll     = "DEVUtilsD365.dll";
        private const string DevUtilsPdb     = "DEVUtilsD365.pdb";
        private const string LabelEditorDLL = "DeveloperToolsLabelsEditor.dll";
        private const string LabelEditorPdb = "DeveloperToolsLabelsEditor.pdb";
        private const string AddinFolder = "AddinExtensions";

        static void Main(string[] args)
        {
            try
            {
                //initialize files to copy
                ArrayList dllArrayList = new ArrayList();
                dllArrayList.Add(DevUtilsDll);
                dllArrayList.Add(DevUtilsPdb);
                dllArrayList.Add(LabelEditorDLL);
                dllArrayList.Add(LabelEditorPdb);
                string extensionFolderName = FindExtensionFolder();
                Console.WriteLine($"VS extension folder: {extensionFolderName}");

                foreach (string fileName in dllArrayList)
                {
                    string sourcePath = Path.Combine(Environment.CurrentDirectory, fileName);
                    string targetPath = Path.Combine(extensionFolderName, fileName);
                    File.Copy(sourcePath, targetPath, true);
                }

                Console.WriteLine("Setup finished! Close and enjoy!");

            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee);
                Console.Error.WriteLine("Seems that an issue prevented me from doing my job :(");
            }

            Console.ReadLine();
        }
        private static string FindExtensionFolder()
        {
            /*
            using (var extensionsRegKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio\14.0\ExtensionManager\EnabledExtensions"))
            {
                string path = "";
                if (extensionsRegKey != null)
                {
                    string axToolsKeyName = extensionsRegKey.GetValueNames()
                        .FirstOrDefault(name => name.StartsWith("DynamicsRainierVSTools"));
                    if (axToolsKeyName != null)
                    {
                        path = (string) extensionsRegKey.GetValue(axToolsKeyName);
                    }
                }
                */
            string path = "";
            RegistryKey d365Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio\14.0_Config\AutomationProperties\Dynamics 365");
            if (d365Key != null)
            {
                string package = (string) d365Key.GetValue("Package");

                RegistryKey pathKey =
                    Registry.CurrentUser.OpenSubKey(
                        $@"SOFTWARE\Microsoft\VisualStudio\14.0_Config\BindingPaths\{package}");
                if (pathKey != null)
                {
                    path = pathKey.GetValueNames()[0];
                }
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ApplicationException("Could not find D365FO tools in Windows registry.");
            }
            return Path.Combine(path, AddinFolder);
            //}

        }
    }
}
