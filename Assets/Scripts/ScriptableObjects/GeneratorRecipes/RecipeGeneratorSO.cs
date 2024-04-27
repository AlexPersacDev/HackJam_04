using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeGenerator", menuName = "RecipeGenerator")]
public class RecipeGeneratorSO : ScriptableObject
{
    [SerializeField] private List<IngredientsSO> ingredients;
    [SerializeField] private RecipeBookSO recipeBook;
    
    private List<IngredientsSO> usedIngredients;
    private void OnEnable ()
    {
        GenerateRecepies();
    }

    private void GenerateRecepies ()
    {
        foreach (IngredientsSO ingredientOne in ingredients)
        {
            usedIngredients.Add(ingredientOne);
            foreach (IngredientsSO ingredienTwo in ingredients)
            {
                if (usedIngredients.Contains(ingredienTwo)) continue;
                foreach (IngredientsSO ingredientThree in ingredients)
                {
                    if (usedIngredients.Contains(ingredientThree) || ingredientThree == ingredienTwo) continue;
                    
                    recipeBook.AddNewRecipe(new IngredientsSO[]{ingredientOne, ingredienTwo, ingredientThree});
                }
            }
        }
    }
}
