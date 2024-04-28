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

    //public event Action<Ranks> OnFormuleFinished; 

    private void OnEnable ()
    {
        player.GetPlayerSelector(this);
        Ingredient.OnIngredientSelected += ReciveIngredient;
    }

    private void OnDisable ()
    {
        Ingredient.OnIngredientSelected -= ReciveIngredient;
    }


    // public void SwitchInTurn (bool ImInTurn)
    // {
    //     player.SwitchInTurn(ImInTurn);
    // }
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
            Ranks rank;
            badScore = selectedIngredients.Count((x) => x.Rank == Ranks.Bad);
            goodScore = selectedIngredients.Count((x) => x.Rank == Ranks.Good);

            if(goodScore == 0)//o MALA O BASE.
            {
                if(badScore >= 2)
                {
                    Debug.Log("Bad result");
                    rank = Ranks.Bad;
                }
                else
                {
                    Debug.Log("BASE RESULT");
                    rank = Ranks.Base;
                }
            }
            else //hAY GOOD SCORE.
            {
                if(goodScore != 3)
                {
                    Debug.Log("MEDIUM RESULT");
                    rank = Ranks.Medium;
                }
                else
                {
                    Debug.Log("FORMULA 1!");
                    rank = Ranks.Good;
                }
            }
            
            gM.PlayerFinishedFormula(rank);
        }
        
        //TODO comprobar receta con las recetas del bookrecipe
        
        //TODO player ready 
        Debug.Log(selectedIngredients + "//" + this.name);
    }
    
}
