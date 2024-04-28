using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu (menuName = "Turns Event")]
public class TurnsEventSO : ScriptableObject
{
    private List<PlayerSelector> playersInGame = new List<PlayerSelector>();
    private PlayerSelector firstInTurn;

    public event Action OnChangeTurn;
    private void OnEnable ()
    {
        for (int i = 0; i < playersInGame.Count; i++)
        {
            playersInGame[i].OnTurnConsumed += TurnChanged;
        }
    }
    public void FillPlayersInGame (PlayerSelector playerRecived)
    {
        playersInGame.Add(playerRecived);
    }
    // public void StartGarage ()
    // {
    //     if (firstInTurn != null)
    //     {
    //         firstInTurn.SwitchInTurn(true);
    //         return;
    //     }
    //     playersInGame[0].SwitchInTurn(true);
    // }

    private void TurnChanged ()
    {
        for (int i = 0; i < playersInGame.Count; i++)
        {
            playersInGame[i].SwitchInTurn(!playersInGame[i].InTurn);
        }
        OnChangeTurn?.Invoke();
    }
    private void OnDisable ()
    {
        for (int i = 0; i < playersInGame.Count; i++)
        {
            playersInGame[i].OnTurnConsumed -= TurnChanged;
        }
    }
}
