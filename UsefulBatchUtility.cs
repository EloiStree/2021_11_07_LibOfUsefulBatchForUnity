using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulBatchUtility 
{
    public static void ZipTargetFolder(string folderPath, bool addDateTime=true)
    {
        ZipTargetFolder(folderPath, "", addDateTime);

    }
    public static void ZipTargetFolder(string folderPath, string zipName, bool addDateTime)
    {
        string parentOfFolderToZip = folderPath + "/../";
        E_FilePathUnityUtility.GetJustDirectoryName(in folderPath, out string folderName);

        if (Eloi.E_StringUtility.IsNullOrEmpty(zipName))
        {
            zipName = folderName;
        }
        if (addDateTime)
            zipName += DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss");
        E_LaunchWindowBat.ExecuteCommandHiddenWithReturnInThread(
            new Eloi.MetaAbsolutePathDirectory(parentOfFolderToZip),
            $"tar.exe -a -cf \"{zipName}.zip\" \"{folderName}\" ");
    }
}
