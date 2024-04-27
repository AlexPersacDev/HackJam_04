using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeGenerator", menuName = "RecipeGenerator")]
public class RecipeGeneratorSO : ScriptableObject
{
    [SerializeField] private List<IngredientsSO> allIngredients;
    [SerializeField] private RecipeBookSO recipeBook;
    
    private List<RecipeSO> allRecipes = new List<RecipeSO>();

    private List<RecipeSO> allCombinations = new List<RecipeSO>();
    private void OnEnable()
    {
        GenerateRecepies();
    }

    private void GenerateRecepies ()
    {
        int recipeIndex = 0;
        //for (int i = 0; i < allIngredients.Count; i++)
        //{
            
        //    for (int j = 0; j < allIngredients.Count; j++)
        //    {
        //        for (int k = 0; k < allIngredients.Count; k++)
        //        {
        //            allCombinations[recipeIndex].RequiredIngredients
        //            allRecipes[recipeIndex].RequiredIngredients
                    
                        
        //                Debug.Log(allIngredients[i].IngredientName + "-" + allIngredients[j].IngredientName + "-" + allIngredients[k].IngredientName);
        //            recipeIndex++;
        //            //recipeBook.AddNewRecipe(new IngredientsSO[]{ingredients[i], ingredients[j], ingredients[k]});
        //        }
        //    }
        //}
        Debug.Log(recipeIndex);
        
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

    private void OnDisable()
    {
        //usedIngredients.Clear();
    }
}
