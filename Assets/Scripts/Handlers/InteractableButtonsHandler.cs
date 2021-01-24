using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableButtonsHandler : MonoBehaviour
{
    [SerializeField] List<Button> buttons;


    private void Start()
    {
        InitialSetup();
    }


    public void InitialSetup ()
    {
        buttons[0].interactable = true;

        for(int i = 0; i < GameManager.Instance.GetMedalsAmount(1); i++)
        {
            Debug.Log(buttons[i+1].name + "INTERACTABLE");

            if (GameManager.Instance.GetMedalsAmount(1) == GameManager.Instance.trackAmount)
            {
                return;
            }

            buttons[i+1].interactable = true;
        }
    }
}
