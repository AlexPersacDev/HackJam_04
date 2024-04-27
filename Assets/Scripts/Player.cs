using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private RecipeBookSO recipeBook;
    
    private List<IngredientsSO> currentIngredients = new List<IngredientsSO>();

    private int badScore, baseScore, mediumScore, goodScore;

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
        if (currentIngredients.Count == 3)
        {
            return;
        }

        currentIngredients.Add(ingredientRecived);

        if(currentIngredients.Count == 3)
        { 
            badScore = currentIngredients.Count((x) => x.Rank == Ranks.Bad);
            goodScore = currentIngredients.Count((x) => x.Rank == Ranks.Good);

            if(goodScore == 0)//o MALA O BASE.
            {
                if(badScore >= 2)
                {
                    Debug.Log("Bad result");
                }
                else
                {
                    Debug.Log("BASE RESULT");
                }
            }
            else //hAY GOOD SCORE.
            {
                if(goodScore != 3)
                {
                    Debug.Log("MEDIUM RESULT");
                }
                else
                {
                    Debug.Log("FORMULA 1!");
                }
            }
            
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
