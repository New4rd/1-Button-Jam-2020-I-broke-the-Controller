using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimesDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bronzeText;
    [SerializeField] TextMeshProUGUI silverText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI personalText;


    private IEnumerator Start()
    {
        yield return new WaitUntil(() => TrackManager.Instance != null);

        bronzeText.text = string.Format ("{0:0.00}",  GameManager.Instance.bronzeTimes[TrackManager.Instance.trackNumber - 1]) + " sec.";
        silverText.text = string.Format ("{0:0.00}", GameManager.Instance.silverTimes[TrackManager.Instance.trackNumber - 1]) + " sec.";
        goldText.text = string.Format ("{0:0.00}", GameManager.Instance.goldTimes[TrackManager.Instance.trackNumber - 1]) + " sec.";
        personalText.text = string.Format ("{0:0.00}", GameManager.Instance.bestPersonalTimes[TrackManager.Instance.trackNumber - 1]) + " sec.";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow));
        StartCoroutine(ScenesManager.Instance.UnloadSceneByObject(gameObject));
        StartCoroutine(ScenesManager.Instance.LoadScene("Countdown Scene"));
    }
}
