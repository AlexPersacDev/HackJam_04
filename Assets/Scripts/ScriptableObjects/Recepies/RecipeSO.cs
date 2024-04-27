using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class RecipeSO : ScriptableObject
{ 
    private List<IngredientsSO> requiredIngredients;
    private Ranks recipeRank;

    private List<Ranks> ingredientsRecivedRanks;

    public List<IngredientsSO> RequiredIngredients => requiredIngredients;

    public void FillRecipe (IngredientsSO[] ingredientsRecived)
    {
        for (int i = 0; i < requiredIngredients.Count; i++)
        {
            requiredIngredients[i] = ingredientsRecived[i];
        }
        //CalculateRankRecipe();
    }

    private void CalculateRankRecipe ()
    {
        if (requiredIngredients.Count == 0) return;
        for (int i = 0; i < requiredIngredients.Count; i++)
        {
            ingredientsRecivedRanks.Add(requiredIngredients[i].Rank);
        }
        
        if (ingredientsRecivedRanks.Count((ranks) => ranks == ingredientsRecivedRanks[0]) == requiredIngredients.Count || ingredientsRecivedRanks.Count((ranks) => ranks < ingredientsRecivedRanks[0]) ==
            requiredIngredients.Count) //todos iguales
        {
            Debug.Log(recipeRank);
            recipeRank = ingredientsRecivedRanks[0];
            return;
        }
        
        
        //ninguno igual
        for (int i = 0; i <  requiredIngredients.Count; i++)
        {
            //dos iguales
           
            
            //ingredientsRecivedRanks.Count((ranks) => ranks == ingredientsRecivedRanks[0]);
        }

        
    }
}
