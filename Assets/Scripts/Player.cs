using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private RecipeBookSO recipeBook;
    
    private List<IngredientsSO> currentIngredients = new List<IngredientsSO>();

    private void OnEnable ()
    {
        Ingredient.OnIngredientSelected += ReciveIngredient;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDisable ()
    {
        Ingredient.OnIngredientSelected -= ReciveIngredient;
    }

    private void ReciveIngredient (IngredientsSO ingredientRecived)
    {
        //TODO cambiar de jugador
        
        if (currentIngredients.Count < 3)
        {
            currentIngredients.Add(ingredientRecived);
            Debug.Log(ingredientRecived.name + "guardado");
            return;
        }
        
        //TODO comprobar receta con las recetas del bookrecipe
        
        //TODO player ready
        Debug.Log(currentIngredients.Count);
    }

    private void CheckRecipe ()
    {
        for (int i = 0; i < recipeBook.RecipesIngredientes.Count; i++)
        {
            for (int j = 0; j < currentIngredients.Count; j++)
            {
                //if(recipeBook.RecipesIngredientes[i,] )
            }
        }
    }
}
