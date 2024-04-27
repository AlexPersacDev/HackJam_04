using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class PlayerSO : ScriptableObject
{
    private List<IngredientsSO> inventoryIngredients = new List<IngredientsSO>();
    private List<IngredientsSO> raceIngredients = new List<IngredientsSO>();

    public List<IngredientsSO> InventoryIngredients { get => inventoryIngredients; set => inventoryIngredients = value; }
    public List<IngredientsSO> RaceIngredients { get => raceIngredients; set => raceIngredients = value; }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnNewSceneLoaded;
    }

    private void OnNewSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        if(scene.buildIndex == 0) //Carrera
        {
            raceIngredients.Clear();
        }
    }

    private void OnDisable()
    {
        raceIngredients.Clear();
        inventoryIngredients.Clear();
    }
}
