using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GarageManager : MonoBehaviour
{

    [SerializeField]
    private PlayerSO myPlayer;

    [SerializeField]
    private GameObject[] cigarretes;

    [SerializeField]
    private GameObject[] skulls;

    [SerializeField]
    private GameObject[] dinos;

    [SerializeField]
    private GameObject[] mates;

    [SerializeField]
    private GameObject[] mushrooms;

    [SerializeField]
    private GameObject[] uraniums;

    [SerializeField]
    private GameObject[] beers;

    [SerializeField]
    private GameObject[] totems;

    [SerializeField]
    private GameObject[] cakes;

    [SerializeField]
    private GameObject[] drinks;

    [SerializeField]
    private GameObject[] nitrogen;

    [SerializeField]
    private GameObject[] gas;



    private void Awake()
    {
        ActivateItems(cigarretes, "Cigarretes");
        ActivateItems(skulls, "Skull");
        ActivateItems(dinos, "Dinosaur");
        ActivateItems(mates, "Mate");
        ActivateItems(mushrooms, "Mushrooms");
        ActivateItems(uraniums, "Uranium");

        ActivateItems(beers, "Beer");
        ActivateItems(totems, "Totem");
        ActivateItems(cakes, "Cake");
        ActivateItems(drinks, "Drink");
        ActivateItems(nitrogen, "Nitrogen");
        ActivateItems(gas, "Gas");

    }

    private void ActivateItems(GameObject[] array, string nameOfItem)
    {
        int numberOfItems = myPlayer.InventoryIngredients.Count((x) => x.IngredientName == nameOfItem);

        //Se limita el número de items.
        if(numberOfItems > array.Length)
        {
            numberOfItems = array.Length;
        }

        for (int i = 0; i < numberOfItems; i++)
        {
            array[i].SetActive(true);
        }
    }

}
