using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Turns Event")]
public class TurnsEventSO : ScriptableObject
{
    private Player[] playersInGame;

    public event Action OnChangeTurn;
    private void OnEnable ()
    {
        for (int i = 0; i < playersInGame.Length; i++)
        {
            playersInGame[i].OnTurnConsumed += TurnChanged;
        }
    }


    private void TurnChanged ()
    {
        OnChangeTurn?.Invoke();
    }
    private void OnDisable ()
    {
        for (int i = 0; i < playersInGame.Length; i++)
        {
            playersInGame[i].OnTurnConsumed -= TurnChanged;
        }
    }
}
