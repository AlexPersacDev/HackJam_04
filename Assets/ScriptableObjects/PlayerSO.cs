using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class PlayerSO : ScriptableObject
{
<<<<<<< HEAD
    private List<IngredientsSO> inventoryIngredients = new List<IngredientsSO>();
    private List<IngredientsSO> raceIngredients = new List<IngredientsSO>();

    public List<IngredientsSO> InventoryIngredients { get => inventoryIngredients; set => inventoryIngredients = value; }
    public List<IngredientsSO> RaceIngredients { get => raceIngredients; set => raceIngredients = value; }
=======
    [SerializeField] private int playerNumber;
    private List<IngredientsSO> currentIngredients = new List<IngredientsSO>();
    private bool inTurn;
    private PlayerSelector currentPlayerSelector;
    
    public bool InTurn => inTurn;
    public int PlayerNumber => playerNumber;
    public List<IngredientsSO> CurrentIngredients { get => currentIngredients; set => currentIngredients = value; }
>>>>>>> 73cc25048a39cf66431eb54ae4c560a4c7db9e2d

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
    
    public void SwitchInTurn (bool ImInTurn)
    {
        inTurn = ImInTurn;
    }

    public void GetPlayerSelector (PlayerSelector recivedPlayerSelector)
    {
        currentPlayerSelector = recivedPlayerSelector;
    }
}
