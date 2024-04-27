using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


[CreateAssetMenu(menuName ="GameManager")]
public class GameManagerSO : ScriptableObject
{
    private List<PlayerSelector> players = new List<PlayerSelector>();

    private List<CarMain> carPlayers = new List<CarMain>();
    private List<Checkpoint> checkpoints = new List<Checkpoint>();

    //---------
    [SerializeField]
    private int totalCheckPoints;

    [SerializeField]
    private int totalLaps;
    
    //EVENTS------------
    [SerializeField] private TurnsEventSO turnEvent;
    //-----------

    #region events
    public event Action<CarMain> OnNewWinner;
    #endregion

    public int TotalCheckPoints { get => totalCheckPoints; }
    public List<CarMain> Players {get => carPlayers; }
    public List<Checkpoint> Checkpoints { get => checkpoints;}
    public int TotalLaps { get => totalLaps; }

    private int nextCheckPointIndex;


    //gm ordena a los coches en funci�n de los siguientes criterios:
    //1. Numero de vueltas
    //2. Numerod de checkpoints
    //3. DISTANCAI a su siguiente checkPoint

    private void OnEnable ()
    {
        turnEvent.OnChangeTurn += ChangePlayerTurn;
        PlayerSelector.OnStartGame += RecivePlayerInGame;
    }

    private void ChangePlayerTurn()
    {
        
    }
    private void RecivePlayerInGame (PlayerSelector playerrecived)
    {
        if (!players.Contains(playerrecived)) players.Add(playerrecived); ;
        
    }
    public void PlayerPassedCheckPoint(CarMain car)
    {
        CarCheckPointsSystem checkSystem = car.CheckPointsSystem;
        nextCheckPointIndex = checkSystem.LastCheckPoint.CheckPointNumber + 1;
        Debug.Log(nextCheckPointIndex);
        if(nextCheckPointIndex == totalCheckPoints)
        {
            nextCheckPointIndex = 0;
        }
        else if(nextCheckPointIndex > totalCheckPoints)
        {
            nextCheckPointIndex = 1;
        }
        checkSystem.NextCheckPoint = checkpoints[nextCheckPointIndex];
        Debug.Log("El coche " + car.name + " cruz� el checkpoint " + checkSystem.LastCheckPoint.CheckPointNumber);
    }
    public void PlayerPassedLap(CarMain car)
    {
        //TODO si es el primer coche en cruzar meta se posiciona como ganador, cuando el segundo coche cruce meta se terminará con un delay
        Debug.Log("El coche " + car.name + " cruz� meta!");
    }

    public void SortCheckPoints()
    {
        checkpoints.OrderBy((x) => x.CheckPointNumber);

        checkpoints.Reverse();
    }



    public void UpdateRanking()
    {
        carPlayers.OrderByDescending((x) => x.CheckPointsSystem.LapsPassed).
            OrderByDescending((y) => y.CheckPointsSystem.CheckPointsPassed).
            OrderBy((z) => z.CheckPointsSystem.RemainingDistanceToNextCheck);

        //players.Reverse();
    }
    private void OnDisable()
    {
        checkpoints.Clear();
        carPlayers.Clear();
        PlayerSelector.OnStartGame -= RecivePlayerInGame;
        turnEvent.OnChangeTurn -= ChangePlayerTurn;
    }

    internal void NewItemSelected(IngredientsSO ingredient)
    {
        throw new NotImplementedException();
    }

    public void Winner(CarMain winnerCar)
    {
        OnNewWinner?.Invoke(winnerCar);

        //Deshabilito movimiento de coches.
        foreach (var player in carPlayers)
        {
            player.Stop();
        }
        //Start
    }

    public void LoadNewScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
