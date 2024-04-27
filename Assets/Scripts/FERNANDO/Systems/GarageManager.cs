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
    private GameObject[] mates;

    [SerializeField]
    private GameObject[] uraniums;

    [SerializeField]
    private GameObject[] dinos;

    [SerializeField]
    private GameObject[] mushrooms;

    private void Awake()
    {
        ActivateItems(cigarretes, "Cigarretes");
        ActivateItems(skulls, "Skull");
        ActivateItems(mates, "Mate");
        ActivateItems(uraniums, "Uranium");
        ActivateItems(dinos, "Dinosaur");
        ActivateItems(mushrooms, "Mushrooms");
        
    }

    private void ActivateItems(GameObject[] array, string nameOfItem)
    {
        int numberOfItems = myPlayer.CurrentIngredients.Count((x) => x.IngredientName == nameOfItem);
        Debug.Log(numberOfItems + " encontrados de " + nameOfItem);
        for (int i = 0; i < numberOfItems; i++)
        {
            array[i].SetActive(true);
        }
    }

}
