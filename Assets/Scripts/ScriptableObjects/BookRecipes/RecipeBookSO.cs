using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe Book", menuName = "Recipe Book")]
public class RecipeBookSO : ScriptableObject
{
    [SerializeField] private int totalRequiredIngredients;
    
    //private List<RecipeSO> totalRecipes = new List<RecipeSO>();

    private List<IngredientsSO[]> recipesIngredientes;
    
    public List<IngredientsSO[]> RecipesIngredientes => recipesIngredientes;
    
    //public List<RecipeSO> TotalRecpies => totalRecipes;

    public void AddNewRecipe (IngredientsSO[] recivedIngredients)
    {
        if (recivedIngredients.Length != totalRequiredIngredients)return;
        
        recipesIngredientes.Add(recivedIngredients);
    }
}
