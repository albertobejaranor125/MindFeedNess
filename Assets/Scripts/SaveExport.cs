using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveExport
{
    private static SaveExport instanceSaveExport;
    private string fileName = "";
    public SaveExport()
    {
        instanceSaveExport = new SaveExport();
        fileName = Application.dataPath + "/dataParticipant.csv";
    }
    public static SaveExport getInstance()
    {
        if(instanceSaveExport == null)
        {
            instanceSaveExport = new SaveExport();
        }
        return instanceSaveExport;
    }
    public void AddParticipant(string participantName)
    {
        TextWriter tw = new StreamWriter(fileName, true);
        tw.WriteLine(participantName);
        tw.Close();
    }
    public void AddData(string data)
    {
        TextWriter tw = new StreamWriter(fileName, true);
        tw.WriteLine(data);
        tw.Close();
    }
}
