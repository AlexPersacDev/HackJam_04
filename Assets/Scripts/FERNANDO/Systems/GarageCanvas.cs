using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
            gM.LoadNewScene(2);
            return;
        }

        gM.LoadNewScene(0);
    }

    public void ClickOneButton ()
    {
        SceneManager.LoadScene("GarajePl1 1");
    }
    public void ClicktwoButton ()
    {
        SceneManager.LoadScene("FER");
    }

    private void OnDisable()
    {
        gM.OnPlayerFinishedFormula -= ActivateReadyButton;
    }
}
