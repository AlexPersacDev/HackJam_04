using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Turns Event")]
public class TurnsEventSO : ScriptableObject
{
    private Player[] playersInGame = Array.Empty<Player>();

    public event Action OnChangeTurn;
    private void OnEnable ()
    {
        foreach (Player player in playersInGame)
        {
            player.OnTurnConsumed += TurnChanged;
        }
    }

    private void OnDisable ()
    {
        foreach (Player player in playersInGame)
        {
            player.OnTurnConsumed -= TurnChanged;
        }
    }

    private void TurnChanged ()
    {
        OnChangeTurn?.Invoke();
    }
}
