using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class PlayerSO : ScriptableObject
{
    private List<IngredientsSO> currentIngredients = new List<IngredientsSO>();

    public List<IngredientsSO> CurrentIngredients { get => currentIngredients; set => currentIngredients = value; }


    private void OnDisable()
    {
        currentIngredients.Clear();
    }
}
