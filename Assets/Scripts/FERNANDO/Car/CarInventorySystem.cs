using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInventorySystem : CarSystem
{


    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObtainableItem obtainableItem))
        {
            main.MyId.CurrentIngredients.Add(obtainableItem.MyData);

            Destroy(other.gameObject);
        }
    }
}
