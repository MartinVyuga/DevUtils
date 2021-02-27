﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using DevUtilsD365.Kernel;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;

namespace DevUtilsD365.EnumCreator
{
    public class EnumCreatorParms
    {
        public string EnumName { get; set; } = "";

        public string EnumLabel { get; set; } = "";
        public string EnumHelpText { get; set; } = "";

        public int EnumValueStartIndex { get; set; } = 0;

        public string ValuesSeparator { get; set; } = "|";
        public string EnumValuesStr { get; set; } = "";

        public Boolean IsCreateEnumType { get; set; }
        public string EnumTypeName { get; set; } = "";

        private string _logString;

        void AddLog(string logLocal)
        {
            _logString += logLocal;
        }

        public void DisplayLog()
        {
            CoreUtility.DisplayInfo($"The following elements({_logString}) were created and added to the project");
        }

        public string GetPreviewString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (AxEnumValue enumValue in GetAxEnumValues())
            {
                stringBuilder.AppendLine($"Element name:{enumValue.Name}; Element label:{enumValue.Label};");
            }

            if (this.IsCreateEnumType)
            {
                stringBuilder.AppendLine($"EDT {EnumTypeName} will be created");
            }
            AxHelper axHelper = new AxHelper();
            AxEnum newEnum = axHelper.MetadataProvider.Enums.Read(EnumName);

            if (newEnum == null)
            {
                stringBuilder.AppendLine($"Enum {EnumName} will be created");
            }
            else
            {
                stringBuilder.AppendLine($"Existing enum {EnumName} will be updated");
            }

            return stringBuilder.ToString();
        }

        public bool EnumLabelModified()
        {
            bool res = false;
            if (EnumName == "" && EnumLabel != "")
            {
                EnumName = AxHelper.GetTypeNameFromLabel(EnumLabel);
                res = true;
            }
            return res;
        }
        public bool IsCreateEnumTypeModified()
        {
            bool res = false;
            if (IsCreateEnumType)
            {
                if (EnumTypeName == "")
                {
                    EnumTypeName = $@"{EnumName}Type";
                    res = true;
                }
            }
            return res;
        }

        private List<AxEnumValue> GetAxEnumValues()
        {
            List<AxEnumValue> resList = new List<AxEnumValue>();

            List<string> listImp = new List<string>(
                EnumValuesStr.Split(new[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries));

            bool isFirstElement = true;
            int currentIndex = EnumValueStartIndex;
            foreach (string lineImp in listImp)
            {
                string enumLabelLocal = "", enumNameLocal = "";

                if (lineImp.Contains(ValuesSeparator))
                {
                    List<string> listLineImp = new List<string>(
                    lineImp.Split(new[] { ValuesSeparator },
                            StringSplitOptions.None));
                    enumLabelLocal = listLineImp[0].Trim();
                    enumNameLocal  = listLineImp[1].Trim();
                    if (enumLabelLocal == "" && enumNameLocal == "" && isFirstElement)
                    {
                        enumNameLocal = "None";
                    }
                }
                else
                {
                    enumLabelLocal = lineImp.Trim();
                    enumNameLocal = AxHelper.GetTypeNameFromLabel(enumLabelLocal);
                    //enumNameLocal = textInfo.ToTitleCase(enumLabelLocal).Replace(" ", "");
                }

                isFirstElement = false;
                if (enumNameLocal != "")
                {
                    AxEnumValue enumValue = new AxEnumValue {Label = enumLabelLocal, Name = enumNameLocal};
                    enumValue.Value = currentIndex;
                    currentIndex++;
                    resList.Add(enumValue);
                }
                else
                {
                    break;
                }
            }
            return resList;
        }

        public void CreateEnum()
        {
            _logString = "";
            AxHelper axHelper = new AxHelper();

            AxEnum newEnum = axHelper.MetadataProvider.Enums.Read(EnumName);

            if (newEnum == null)
            {
                newEnum = new AxEnum {Name = EnumName, Label = EnumLabel, Help = EnumHelpText, UseEnumValue = NoYes.No};

                axHelper.MetaModelService.CreateEnum(newEnum, axHelper.ModelSaveInfo);
                axHelper.AppendToActiveProject(newEnum);

                AddLog($"Enum {newEnum.Name};");

                if (IsCreateEnumType)
                {
                    AxEdtEnum  newAxEdtEnum = axHelper.MetadataProvider.Edts.Read(EnumTypeName) as AxEdtEnum;
                    if (newAxEdtEnum == null)
                    {
                        newAxEdtEnum = new AxEdtEnum {Name = EnumTypeName, EnumType = newEnum.Name};

                        axHelper.MetaModelService.CreateExtendedDataType(newAxEdtEnum, axHelper.ModelSaveInfo);
                        axHelper.AppendToActiveProject(newAxEdtEnum);

                        AddLog($"Enum type {newAxEdtEnum.Name};");
                    }
                }
                newEnum = axHelper.MetadataProvider.Enums.Read(EnumName);
            }

            foreach (var ea in GetAxEnumValues())
            {
                newEnum.AddEnumValue(ea);
            }
            axHelper.MetaModelService.UpdateEnum(newEnum, axHelper.ModelSaveInfo);

        }
    }
}
