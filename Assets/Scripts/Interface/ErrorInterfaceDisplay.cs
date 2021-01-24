using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorInterfaceDisplay : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(ScenesManager.Instance.UnloadSceneByObject(gameObject));
    }
}
