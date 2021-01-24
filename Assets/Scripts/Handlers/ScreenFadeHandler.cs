using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeHandler : MonoBehaviour
{
    static public ScreenFadeHandler Instance;

    public bool animationDone;

    [SerializeField] Animator fadeAnimator;

    Image blackFadeImage;


    private void Awake()
    {
        Instance = this;
    }


    public void ScreenFadeIn ()
    {
        animationDone = false;
        fadeAnimator.SetTrigger("Fade In Trigger");
        animationDone = true;
    }


    public void ScreenFadeOut ()
    {
        animationDone = false;
        fadeAnimator.SetTrigger("Fade Out Trigger");
        animationDone = true;
    }


    public void UpdateAnimationState ()
    {
        animationDone = true;
    }
}
