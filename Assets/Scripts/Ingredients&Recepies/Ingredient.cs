using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IInteractuable
{


    [SerializeField] private IngredientsSO ingredient;

    public static event Action<IngredientsSO> OnIngredientSelected;

    public void ConsumeIngredient ()
    {
        gameObject.SetActive(false);
    }
    void IInteractuable.Interact ()
    {
        OnIngredientSelected?.Invoke(ingredient);
    }

    private void OnMouseDown ()
    {
        ((IInteractuable)this).Interact();
    }
}
