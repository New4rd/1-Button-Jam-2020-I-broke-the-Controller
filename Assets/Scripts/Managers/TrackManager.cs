using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    static public TrackManager Instance;

    public int trackNumber;
    public bool endOfLap = false, lapStarted = false;

    [SerializeField] int checkpointsAmount;

    int passedCheckpoints = 0;
    float startTime, endTime, totalTime;

    private void Awake()
    {
        Instance = this;
    }


    private IEnumerator Start()
    {
        AudioManager.Instance.LoadRandomMusic();
        AudioManager.Instance.PauseEngineSound();

        yield return new WaitUntil(() => lapStarted);

        AudioManager.Instance.LaunchEngineSound();

        startTime = Time.time;
        yield return new WaitUntil(() => passedCheckpoints == checkpointsAmount);

        endTime = Time.time;
        totalTime = endTime - startTime;

        AudioManager.Instance.PauseEngineSound();

        AudioManager.Instance.LoadSound("Applause");
        AudioManager.Instance.ModifyVolume(.2f);

        Debug.Log("TIME::: " + totalTime);

        GameManager.Instance.UpdateTimeOnIndex(trackNumber, totalTime);
        int medal = GameManager.Instance.UpdateMedalsOnIndex(trackNumber, totalTime);

        endOfLap = true;
        PlayerMovements.Instance.move = false;

        yield return new WaitForSecondsRealtime(1);

        StartCoroutine(ScenesManager.Instance.LoadScene("UI Finish Scene"));
        yield return new WaitUntil(() => UIFinishDisplayHandler.Instance != null);

        UIFinishDisplayHandler.Instance.DisplayMedal(medal);
        UIFinishDisplayHandler.Instance.DisplayTime(totalTime);
    }

    public int GetPassedCheckpoints ()
    {
        return passedCheckpoints;
    }

    public void IncreasePassedCheckpoints ()
    {
        passedCheckpoints++;
    }
}
