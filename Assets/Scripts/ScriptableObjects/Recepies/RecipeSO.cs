using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RecipeSO : ScriptableObject
{ 
    private IngredientsSO[] requiredIngredients;
    private Ranks recipeRank;

    private List<Ranks> ingredientsRecivedRanks;

    public IngredientsSO[] RequiredIngredients => requiredIngredients;

    public void FillRecipe (IngredientsSO[] ingredientsRecived)
    {
        for (int i = 0; i < requiredIngredients.Length; i++)
        {
            requiredIngredients[i] = ingredientsRecived[i];
        }
        CalculateRankRecipe();
    }

    private void CalculateRankRecipe ()
    {
        if (requiredIngredients.Length == 0) return;
        for (int i = 0; i < requiredIngredients.Length; i++)
        {
            ingredientsRecivedRanks.Add(requiredIngredients[i].Rank);
        }
        
        if (ingredientsRecivedRanks.Count((ranks) => ranks == ingredientsRecivedRanks[0]) == requiredIngredients.Length)
        {
            recipeRank = ingredientsRecivedRanks[0];
            return;
        }
        
        for (int i = 0; i <  requiredIngredients.Length; i++)
        {
            ingredientsRecivedRanks.Count((ranks) => ranks == ingredientsRecivedRanks[0]);
        }
        
    }
}
