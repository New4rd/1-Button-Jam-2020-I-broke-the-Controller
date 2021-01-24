using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteraction : MonoBehaviour
{
    /// <summary>
    /// Value used for the buttons that need to load a specific lap number.
    /// </summary>
    public int lapToLoadNumber;


    public void LoadTrackNumberButton ()
    {
        Debug.Log("Loading lap N°" + lapToLoadNumber);
        StartCoroutine(ScenesManager.Instance.LoadScene("Track " + lapToLoadNumber + " Scene"));
        StartCoroutine(ScenesManager.Instance.LoadScene("UI Scores Display Scene"));
        StartCoroutine(ScenesManager.Instance.LoadScene("Interface Scene"));
        StartCoroutine(ScenesManager.Instance.UnloadScene("Track Selection Scene"));
        AudioManager.Instance.LoadSound("Page flip 1", loop:false);
    }


    public void BackToMenuButton ()
    {
        GameManager.Instance.ResumeGame();
        Debug.Log("Back to main menu");
        AudioManager.Instance.LoadMusic("Spanish Flea");
        AudioManager.Instance.LoadSound("Page flip 2", loop:false);
        AudioManager.Instance.UnloadEngineSound();

        StartCoroutine(ScenesManager.Instance.LoadScene("Track Selection Scene"));

        if (TrackManager.Instance.endOfLap)
        {
            StartCoroutine(ScenesManager.Instance.UnloadScene("Track " + TrackManager.Instance.trackNumber + " Scene"));
            StartCoroutine(ScenesManager.Instance.UnloadScene("UI Finish Scene"));
            StartCoroutine(ScenesManager.Instance.UnloadScene("Interface Scene"));
        }

        else
        {
            StartCoroutine(ScenesManager.Instance.UnloadScene("Track " + TrackManager.Instance.trackNumber + " Scene"));
            StartCoroutine(ScenesManager.Instance.UnloadScene("Interface Scene"));
        }
    }


    public void RestartButton ()
    {
        GameManager.Instance.ResumeGame();
        Debug.Log("Restarting the track");
        StartCoroutine(ScenesManager.Instance.ReloadScene("Track " + TrackManager.Instance.trackNumber + " Scene"));
        StartCoroutine(ScenesManager.Instance.LoadScene("UI Scores Display Scene"));
        StartCoroutine(ScenesManager.Instance.UnloadSceneByObject(gameObject));
    }


    public void OnePlayerButton ()
    {
        Debug.Log("One player selected!");
        StartCoroutine(ScenesManager.Instance.LoadScene("Track Selection Scene"));
        StartCoroutine(ScenesManager.Instance.UnloadScene("Main Title Scene"));
        AudioManager.Instance.LoadSound("Page flip 1", loop:false);
    }


    public void TwoPlayersButton ()
    {
        Debug.Log("Two players selected!");
        StartCoroutine(ScenesManager.Instance.LoadScene("2P Track Selection Scene"));
        StartCoroutine(ScenesManager.Instance.UnloadScene("Main Title Scene"));
        AudioManager.Instance.LoadSound("Page flip 1", loop:false);
    }


    public void InformationButton ()
    {
        Debug.Log("Getting more infos");
        StartCoroutine(ScenesManager.Instance.LoadScene("Informations Scene"));
        StartCoroutine(ScenesManager.Instance.UnloadScene("Main Title Scene"));
        AudioManager.Instance.LoadSound("Page flip 1", loop:false);
    }


    public void BackToMainTitleButton()
    {
        Debug.Log("Back to main title");
        StartCoroutine(ScenesManager.Instance.LoadScene("Main Title Scene"));
        StartCoroutine(ScenesManager.Instance.UnloadSceneByObject(gameObject));
        AudioManager.Instance.LoadSound("Page flip 2", loop:false);
    }


    public void PauseButton ()
    {
        GameManager.Instance.ResumePauseGame();
    }


    public void ReloadButton ()
    {
        GameManager.Instance.ResumeGame();
        if (ScenesManager.Instance.IsSceneLoaded("UI Finish Scene")) StartCoroutine(ScenesManager.Instance.UnloadScene("UI Finish Scene"));
        if (ScenesManager.Instance.IsSceneLoaded("Countdown Scene")) StartCoroutine(ScenesManager.Instance.UnloadScene("Countdown Scene"));
        if (ScenesManager.Instance.IsSceneLoaded("UI Scores Display Scene")) StartCoroutine(ScenesManager.Instance.UnloadScene("UI Scores Display Scene"));

        StartCoroutine(ScenesManager.Instance.ReloadScene("Track " + TrackManager.Instance.trackNumber + " Scene"));
        StartCoroutine(ScenesManager.Instance.LoadScene("UI Scores Display Scene"));
    }
}
