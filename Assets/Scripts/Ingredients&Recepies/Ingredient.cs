using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IInteractuable
{
    [SerializeField] private IngredientsSO ingredient;


    void IInteractuable.Interact ()
    {
        
    }
}
