using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCanvas : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private GameObject readyButton;

    private void OnEnable()
    {
        gM.OnPlayerFinishedFormula += ActivateReadyButton;
    }

    private void ActivateReadyButton()
    {
        readyButton.SetActive(true);
    }
    public void OnReadyButtonClicked()
    {
        gM.LoadNewScene(0);
    }

    private void OnDisable()
    {
        gM.OnPlayerFinishedFormula -= ActivateReadyButton;
    }
}
