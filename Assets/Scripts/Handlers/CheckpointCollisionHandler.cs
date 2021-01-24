using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollisionHandler : MonoBehaviour
{
    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * The player will start on/before the start line. We make sure that it's not
         * triggered the first time the player touches it!
         */
        if (!(triggered) && transform.tag == "Start Line" && TrackManager.Instance.GetPassedCheckpoints() == 0)
        {
            Debug.Log("Ignoring the finish line");
            return;
        }

        if (!triggered)
        {
            Debug.Log("PASSING ONE CHECKPOINT!");
            TrackManager.Instance.IncreasePassedCheckpoints();
            triggered = true;
        }
    }
}
