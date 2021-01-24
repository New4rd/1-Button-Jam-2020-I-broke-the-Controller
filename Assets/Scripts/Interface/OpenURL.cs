using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    [SerializeField] string socialMedia;

    public void OpenSocialURL ()
    {
        Application.OpenURL(socialMedia);
    }
}
