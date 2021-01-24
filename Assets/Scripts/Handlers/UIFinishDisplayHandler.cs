using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFinishDisplayHandler : MonoBehaviour
{
    static public UIFinishDisplayHandler Instance;

    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] TextMeshProUGUI medalDisplay;


    private void Awake()
    {
        Instance = this;
    }


    public void DisplayMedal (int medalNumber)
    {
        switch (medalNumber)
        {
            case (0):
                medalDisplay.text = "the Bronze Medal";
                medalDisplay.color = new Color(.9f, .5f, 0f, 1f);
                break;

            case (1):
                medalDisplay.text = "the Silver Medal";
                medalDisplay.color = new Color(0.2641509f, 0.2641509f, 0.2641509f, 1f);
                break;

            case (2):
                medalDisplay.text = "the Gold Medal";
                medalDisplay.color = new Color(1, .9f, 0, 1f);
                break;

            case (3):
                medalDisplay.text = "the Master Medal";
                medalDisplay.color = Color.green;
                break;

            case (-1):
                medalDisplay.text = "No Medal :(";
                medalDisplay.color = Color.white;
                break;

            default: break;
        }
    }


    public void DisplayTime (float time)
    {
        timeDisplay.text = string.Format("{0:0.00}", time) + " sec.";
    }
}
