using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    [Header("Lists of floats for all the medal times")]
    public List<float> bestPersonalTimes;
    public List<float> bronzeTimes;
    public List<float> silverTimes;
    public List<float> goldTimes;
    public List<float> masterTimes;

    public List<List<bool>> medalsList;

    public int trackAmount;

    private void Awake()
    {
        Instance = this;
        medalsList = new List<List<bool>>();
    }


    private void Start()
    {
        bestPersonalTimes = new List<float>();  bronzeTimes = new List<float>();
        silverTimes = new List<float>();        goldTimes = new List<float>();
        masterTimes = new List<float>();

        InitializeMedalList();

        TextDatasaveManager.Instance.FillTimeList(TextDatasaveManager.Instance.FileStringType(TextDatasaveManager.FileType.bronzeTimes), bronzeTimes);
        TextDatasaveManager.Instance.FillTimeList(TextDatasaveManager.Instance.FileStringType(TextDatasaveManager.FileType.silverTimes), silverTimes);
        TextDatasaveManager.Instance.FillTimeList(TextDatasaveManager.Instance.FileStringType(TextDatasaveManager.FileType.goldTimes), goldTimes);
        TextDatasaveManager.Instance.FillTimeList(TextDatasaveManager.Instance.FileStringType(TextDatasaveManager.FileType.masterTimes), masterTimes);
        TextDatasaveManager.Instance.FillTimeList(TextDatasaveManager.Instance.FileStringType(TextDatasaveManager.FileType.personalTimes), bestPersonalTimes);
    }


    public bool UpdateTimeOnIndex (int trackNumber, float newTime)
    {
        if (newTime < bestPersonalTimes[trackNumber-1] || bestPersonalTimes[trackNumber-1] == 0f)
        {
            bestPersonalTimes[trackNumber - 1] = newTime;
            TextDatasaveManager.Instance.UpdatePersonalTimesFile(trackNumber, newTime);

            return true;
        }

        return false;
    }


    
    public void InitializeMedalList ()
    {/*
        for (int i = 0; i < trackAmount; i++)
        {
            List<bool> medals = new List<bool>() { false, false, false, false };
            medalsList.Add(medals);
        }*/


        TextDatasaveManager.Instance.FillMedalsList(medalsList);
    }


    public int UpdateMedalsOnIndex (int trackNumber, float time)
    {
        if (time < masterTimes[trackNumber - 1])
        {
            medalsList[trackNumber - 1][0] = true;
            medalsList[trackNumber - 1][1] = true;
            medalsList[trackNumber - 1][2] = true;
            medalsList[trackNumber - 1][3] = true;
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 0);
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 1);
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 2);
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 3);
            return 3;
        }


        if (time < goldTimes[trackNumber - 1])
        {
            medalsList[trackNumber - 1][0] = true;
            medalsList[trackNumber - 1][1] = true;
            medalsList[trackNumber - 1][2] = true;
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 0);
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 1);
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 2);
            return 2;
        }


        if (time < silverTimes[trackNumber - 1])
        {
            medalsList[trackNumber - 1][0] = true;
            medalsList[trackNumber - 1][1] = true;
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 0);
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 1);
            return 1;
        }


        if (time < bronzeTimes[trackNumber - 1])
        {
            medalsList[trackNumber - 1][0] = true;
            TextDatasaveManager.Instance.UpdateMedalsFile(trackNumber, 0);
            return 0;
        }


        return -1;
    }


    public int GetMedalsAmount (int medalIndex)
    {
        int amount = 0;
        for (int i = 0; i < medalsList.Count; i++)
        {
            if (medalsList[i][medalIndex])
            {
                amount++;
            }
        }
        Debug.Log("Got " + amount + "medals of index " + medalIndex);
        return amount;
    }


    public void ModifyGameSpeed (float newSpeed)
    {
        Time.timeScale = newSpeed;
    }


    public bool gamePause = false;


    public void ResumePauseGame ()
    {
        if (gamePause) ResumeGame();
        else PauseGame();
        gamePause = !gamePause;
    }


    public void PauseGame ()
    {
        gamePause = true;
        ModifyGameSpeed(0);
    }


    public void ResumeGame ()
    {
        gamePause = false;
        ModifyGameSpeed(1);
    }
}
