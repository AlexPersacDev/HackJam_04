using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class GarageCanvas : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private GameObject readyButton;

    [SerializeField] private GameObject garageGate;


    private void OnEnable()
    {
        gM.OnPlayerFinishedFormula += ActivateReadyButton;
    }

    private void ActivateReadyButton()
    {
        readyButton.SetActive(true);
    }
    public async void OnReadyButtonClicked()
    {
        gM.playersReady++;
        if (gM.playersReady < 2)
        {
            gM.LoadNewScene(4);
            return;
        }

        gM.LoadNewScene(0);
    }

    private void OnDisable()
    {
        gM.OnPlayerFinishedFormula -= ActivateReadyButton;
    }
}
