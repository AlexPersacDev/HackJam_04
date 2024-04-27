using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeBookSO : ScriptableObject
{
    [SerializeField] private int totalRequiredIngredients;
    
    private List<RecipeSO> totalRecipes;
    
    public List<RecipeSO> TotalRecpies => totalRecipes;

    public void AddNewRecipe (IngredientsSO[] recivedIngredients)
    {
        if (recivedIngredients.Length != totalRequiredIngredients)
        {
            Debug.Log("Incorect amount of ingredients");
            return;
        }

        if (totalRecipes.Count == 0)
        {
            totalRecipes.Add(new RecipeSO());
            totalRecipes[^1].FillRecipe(recivedIngredients);
            return;
        }

        for (int i = 0; i < totalRecipes.Count; i++)
        {
            int itemsInRecipe = 0;
            if (!totalRecipes[i].RequiredIngredients.Contains(recivedIngredients[i]))
            {
                totalRecipes.Add(new RecipeSO());
                totalRecipes[^1].FillRecipe(recivedIngredients);
                continue;
            }
            itemsInRecipe++;
        }
    }
}
