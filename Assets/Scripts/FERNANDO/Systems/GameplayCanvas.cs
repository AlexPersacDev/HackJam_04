using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private TMP_Text winnerText;

    private void OnEnable()
    {
        gM.OnNewWinner += ShowWinnerText;
    }

    private void ShowWinnerText(CarMain winner)
    {
        winnerText.gameObject.SetActive(true);
        winnerText.SetText("Player " + winner.PlayerNumber + " wins!");
        Invoke(nameof(GarageReady), 2f);
    }

    private void GarageReady()
    {
        gM.LoadNewScene(1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDisable()
    {
        gM.OnNewWinner -= ShowWinnerText;
    }
}
