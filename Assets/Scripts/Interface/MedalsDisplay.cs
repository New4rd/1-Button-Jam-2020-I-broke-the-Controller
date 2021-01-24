using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalsDisplay : MonoBehaviour
{
    [SerializeField] UIInteraction uIInteraction;

    [SerializeField] GameObject bronzeMedal;
    [SerializeField] GameObject silverMedal;
    [SerializeField] GameObject goldMedal;
    [SerializeField] GameObject masterMedal;

    private void Start()
    {
        int trackNumber = uIInteraction.lapToLoadNumber;

        bronzeMedal.SetActive(GameManager.Instance.medalsList[trackNumber - 1][0]);
        silverMedal.SetActive(GameManager.Instance.medalsList[trackNumber - 1][1]);
        goldMedal.SetActive(GameManager.Instance.medalsList[trackNumber - 1][2]);
        masterMedal.SetActive(GameManager.Instance.medalsList[trackNumber - 1][3]);
    }
}
