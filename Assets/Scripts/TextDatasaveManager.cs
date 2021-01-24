using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDatasaveManager : MonoBehaviour
{
    static public TextDatasaveManager Instance;

    string filesPath;

    string bestPersonalTimesFile, bronzeTimesFile,
        silverTimesFile, goldTimesFile, masterTimesFile, obtainedMedalsFile;


    private void Awake()
    {
        Instance = this;

        /* 
        * https://docs.unity3d.com/Manual/StreamingAssets.html
        * https://docs.unity3d.com/Manual/PlatformDependentCompilation.html
        */

        if (
            Application.platform == RuntimePlatform.OSXEditor ||
            Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.LinuxEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.LinuxPlayer)
        {
            filesPath = Application.dataPath + "/StreamingAssets/";
        }

        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            filesPath = Application.dataPath + "/Resources/Data/StreamingAssets/";
        }

        bestPersonalTimesFile = filesPath + "PersonalTimes.txt";
        bronzeTimesFile = filesPath + "BronzeTimes.txt";
        silverTimesFile = filesPath + "SilverTimes.txt";
        goldTimesFile = filesPath + "GoldTimes.txt";
        masterTimesFile = filesPath + "MasterTimes.txt";
        obtainedMedalsFile = filesPath + "ObtainedMedals.txt";
    }


    public void FillTimeList(string filename, List<float> timesList)
    {
        string[] times = File.ReadAllLines(filename);
        foreach (string time in times)
        {
            timesList.Add(float.Parse(time));
        }
    }


    public void FillMedalsList (List<List<bool>> medalsList)
    {
        string[] medals = File.ReadAllLines(obtainedMedalsFile);
        foreach(string tr_medals in medals)
        {
            string[] sub_medal = tr_medals.Split(' ');
            List<bool> bool_medals = new List<bool>();

            foreach (string str_medal in sub_medal)
            {
                bool_medals.Add(Boolean.Parse(str_medal));
            }

            medalsList.Add(bool_medals);
        }
    }


    public void UpdatePersonalTimesFile (int trackNumber, float newTime)
    {
        string[] persTimes = File.ReadAllLines(bestPersonalTimesFile);
        persTimes[trackNumber - 1] = newTime.ToString();
        File.WriteAllLines(bestPersonalTimesFile, persTimes);
    }


    public void UpdateMedalsFile (int trackNumber, int medalType)
    {
        string[] medals = File.ReadAllLines(obtainedMedalsFile);
        string[] subMedals = medals[trackNumber - 1].Split(' ');
        subMedals[medalType] = "true";
        medals[trackNumber - 1] = subMedals[0] + ' ' + subMedals[1] + ' ' + subMedals[2] + ' ' + subMedals[3];
        File.WriteAllLines(obtainedMedalsFile, medals);
    }


    public string FileStringType (FileType ft)
    {
        switch (ft)
        {
            case (FileType.bronzeTimes): return bronzeTimesFile;
            case (FileType.silverTimes): return silverTimesFile;
            case (FileType.goldTimes): return goldTimesFile;
            case (FileType.masterTimes): return masterTimesFile;
            case (FileType.personalTimes): return bestPersonalTimesFile;
            case (FileType.obtainedMedals): return obtainedMedalsFile;
            default: return null;
        }
    }


    public enum FileType
    {
        bronzeTimes,
        silverTimes,
        goldTimes,
        masterTimes,
        personalTimes,
        obtainedMedals
    }
}
