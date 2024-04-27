using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
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
        //CalculateRankRecipe();
    }

    private void CalculateRankRecipe ()
    {
        if (requiredIngredients.Length == 0) return;
        for (int i = 0; i < requiredIngredients.Length; i++)
        {
            ingredientsRecivedRanks.Add(requiredIngredients[i].Rank);
        }
        
        if (ingredientsRecivedRanks.Count((ranks) => ranks == ingredientsRecivedRanks[0]) == requiredIngredients.Length || ingredientsRecivedRanks.Count((ranks) => ranks < ingredientsRecivedRanks[0]) ==
            requiredIngredients.Length) //todos iguales
        {
            Debug.Log(recipeRank);
            recipeRank = ingredientsRecivedRanks[0];
            return;
        }
        
        
        //ninguno igual
        for (int i = 0; i <  requiredIngredients.Length; i++)
        {
            //dos iguales
           
            
            //ingredientsRecivedRanks.Count((ranks) => ranks == ingredientsRecivedRanks[0]);
        }

        
    }
}
