using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName ="GameManager")]
public class GameManagerSO : ScriptableObject
{
    private List<CarMain> players = new List<CarMain>();
    private List<Checkpoint> checkpoints = new List<Checkpoint>();


    [SerializeField]
    private int totalCheckPoints;

    [SerializeField]
    private int totalLaps;



    public int TotalCheckPoints { get => totalCheckPoints; }
    public List<CarMain> Players {get => players; }
    public List<Checkpoint> Checkpoints { get => checkpoints;}
    public int TotalLaps { get => totalLaps; }

    private int nextCheckPointIndex;


    //gm ordena a los coches en función de los siguientes criterios:
    //1. Numero de vueltas
    //2. Numerod de checkpoints
    //3. DISTANCAI a su siguiente checkPoint


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
        Debug.Log("El coche " + car.name + " cruzó el checkpoint " + checkSystem.LastCheckPoint.CheckPointNumber);
    }
    public void PlayerPassedLap(CarMain car)
    {
        Debug.Log("El coche " + car.name + " cruzó meta!");
    }

    public void SortCheckPoints()
    {
        checkpoints.OrderBy((x) => x.CheckPointNumber);

        checkpoints.Reverse();
    }



    public void UpdateRanking()
    {
        players.OrderByDescending((x) => x.CheckPointsSystem.LapsPassed).
            OrderByDescending((y) => y.CheckPointsSystem.CheckPointsPassed).
            OrderBy((z) => z.CheckPointsSystem.RemainingDistanceToNextCheck);

        //players.Reverse();
    }
    private void OnDisable()
    {
        checkpoints.Clear();
        players.Clear();
    }
}
