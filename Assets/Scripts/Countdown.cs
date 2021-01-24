using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI number;
    [SerializeField] float betweenDuration;


    private IEnumerator Start()
    {
        AudioManager.Instance.ModifyVolume(.5f);

        number.text = "3";
        AudioManager.Instance.LoadSound("Countdown");
        yield return new WaitForSecondsRealtime(betweenDuration);
        number.text = "2";
        AudioManager.Instance.LoadSound("Countdown");
        yield return new WaitForSecondsRealtime(betweenDuration);
        number.text = "1";
        AudioManager.Instance.LoadSound("Countdown");
        yield return new WaitForSecondsRealtime(betweenDuration);
        AudioManager.Instance.LoadSound("Race starts");

        TrackManager.Instance.lapStarted = true;
        StartCoroutine(ScenesManager.Instance.UnloadSceneByObject(gameObject));
    }
}
