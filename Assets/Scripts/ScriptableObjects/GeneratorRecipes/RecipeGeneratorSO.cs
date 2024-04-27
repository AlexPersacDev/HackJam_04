using System.Collections.Generic;
using System.Threading.Tasks;
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
        int recipes = 0;
        for (int i = 0; i < ingredients.Count; i++)
        {
            usedIngredients.Add(ingredients[i]);
            for (int j = 0; j < ingredients.Count; j++)
            {
                if (usedIngredients.Contains(ingredients[j])) continue;
                for (int k = 0; k < ingredients.Count; k++)
                {
                    if (usedIngredients.Contains(ingredients[k]) || ingredients[k] == ingredients[j]) continue;
                    Debug.Log(ingredients[i] + "///" + ingredients[j] + "///" + ingredients[k]);
                    recipes++;
                    //recipeBook.AddNewRecipe(new IngredientsSO[]{ingredients[i], ingredients[j], ingredients[k]});
                }
            }
        }
        Debug.Log(recipes);
        
        // foreach (IngredientsSO ingredientOne in ingredients)
        // {
        //     usedIngredients.Add(ingredientOne);
        //     foreach (IngredientsSO ingredienTwo in ingredients)
        //     {
        //         if (usedIngredients.Contains(ingredienTwo)) continue;
        //         foreach (IngredientsSO ingredientThree in ingredients)
        //         {
        //             if (usedIngredients.Contains(ingredientThree) || ingredientThree == ingredienTwo) continue;
        //             
        //             recipeBook.AddNewRecipe(new IngredientsSO[]{ingredientOne, ingredienTwo, ingredientThree});
        //         }
        //     }
        // }
    }
}
