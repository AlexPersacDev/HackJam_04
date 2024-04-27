using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    
    private List<IngredientsSO> selectedIngredients = new List<IngredientsSO>();

    private int badScore, goodScore;
    private bool inTurn;

    public bool InTurn => inTurn;
    public int PlayerNumber => playerNumber;

    public static event Action<PlayerSelector> OnStartGame;

    public event Action OnTurnConsumed;

    private void OnEnable ()
    {
        OnStartGame?.Invoke(this);
        Ingredient.OnIngredientSelected += ReciveIngredient;
    }

    private void OnDisable ()
    {
        Ingredient.OnIngredientSelected -= ReciveIngredient;
    }


    public void SwitchInTurn (bool ImInTurn)
    {
        print("lelo");
        inTurn = ImInTurn;
    }
    private void ReciveIngredient (IngredientsSO ingredientRecived)
    {
        if (!inTurn) return;
        
        OnTurnConsumed?.Invoke();
        
        if (selectedIngredients.Count == 3)
        {
            return;
        }

        selectedIngredients.Add(ingredientRecived);

        if(selectedIngredients.Count == 3)
        { 

            badScore = selectedIngredients.Count((x) => x.Rank == Ranks.Bad);
            goodScore = selectedIngredients.Count((x) => x.Rank == Ranks.Good);

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
        Debug.Log(selectedIngredients + "//" + this.name);
    }
    
}
