using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private int playerNumber;
    private List<IngredientsSO> currentIngredients = new List<IngredientsSO>();
    private bool inTurn;
    private PlayerSelector currentPlayerSelector;
    
    public bool InTurn => inTurn;
    public int PlayerNumber => playerNumber;
    public List<IngredientsSO> CurrentIngredients { get => currentIngredients; set => currentIngredients = value; }


    private void OnDisable()
    {
        currentIngredients.Clear();
    }
    
    public void SwitchInTurn (bool ImInTurn)
    {
        inTurn = ImInTurn;
    }

    public void GetPlayerSelector (PlayerSelector recivedPlayerSelector)
    {
        currentPlayerSelector = recivedPlayerSelector;
    }
}
