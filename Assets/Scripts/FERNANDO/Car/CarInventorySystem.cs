using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInventorySystem : CarSystem
{

    protected override void Awake()
    {
        base.Awake();
        main.InventorySystem = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObtainableItem obtainableItem))
        {
            main.GM.PlayAudio(obtainableItem.ObtainableSound);
            main.MyId.RaceIngredients.Add(obtainableItem.MyData);

            Destroy(other.gameObject);
        }
    }
}
