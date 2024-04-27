using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private PlayerSO player;

    
    private List<IngredientsSO> selectedIngredients = new List<IngredientsSO>();

    private int badScore, goodScore;
    public bool InTurn => player.InTurn;
    
    public static event Action<PlayerSelector> OnStartGame;

    public event Action OnTurnConsumed;

    private void OnEnable ()
    {
        player.GetPlayerSelector(this);
        Ingredient.OnIngredientSelected += ReciveIngredient;
    }

    private void OnDisable ()
    {
        Ingredient.OnIngredientSelected -= ReciveIngredient;
    }


    public void SwitchInTurn (bool ImInTurn)
    {
        player.SwitchInTurn(ImInTurn);
    }
    private void ReciveIngredient (IngredientsSO ingredientRecived)
    {
        //if (!player.InTurn) return;

        //player.SwitchInTurn(false);
        
        //OnTurnConsumed?.Invoke();
        
        if (selectedIngredients.Count == 3)
        {
            return;
        }

        player.InventoryIngredients.Remove(ingredientRecived);

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

            gM.PlayerFinishedFormula();
            
        }
        
        //TODO comprobar receta con las recetas del bookrecipe
        
        //TODO player ready 
        Debug.Log(selectedIngredients + "//" + this.name);
    }
    
}
