using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IInteractuable
{
    [SerializeField] private IngredientsSO ingredient;

    public static event Action<IngredientsSO> OnIngredientSelected;
    void IInteractuable.Interact ()
    {
        gameObject.SetActive(false);
        OnIngredientSelected?.Invoke(ingredient);
    }
}
