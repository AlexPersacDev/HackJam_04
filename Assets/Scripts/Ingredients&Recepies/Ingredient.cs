using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IInteractuable
{
    [SerializeField] private IngredientsSO ingredient;
    
    public Outline objectOutline;

    public static event Action<IngredientsSO> OnIngredientSelected;

    private void OnEnable ()
    {
        objectOutline = gameObject.GetComponent<Outline>();
        objectOutline.enabled = false;
    }

    public void ConsumeIngredient ()
    {
        gameObject.SetActive(false);
    }
    void IInteractuable.Interact ()
    {
        ConsumeIngredient();
        OnIngredientSelected?.Invoke(ingredient);
    }

    // private void OnMouseDown ()
    // {
    //     ((IInteractuable)this).Interact();
    // }
}
