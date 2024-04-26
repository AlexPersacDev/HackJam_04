using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient")]
public class RecipeSO : ScriptableObject
{ 
    [SerializeField] private IngredientsSO[] requiredIngredients;
    [SerializeField] private int recipeRank;
}
