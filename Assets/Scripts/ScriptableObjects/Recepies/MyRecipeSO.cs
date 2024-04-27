using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class MyRecipeSO : ScriptableObject
{
    [SerializeField]
    private IngredientsSO[] ingredients;

    public IngredientsSO[] Ingredients { get => ingredients; }
}
