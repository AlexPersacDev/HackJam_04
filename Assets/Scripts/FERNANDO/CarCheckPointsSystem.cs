using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckPointsSystem : CarSystem
{



    private Checkpoint lastCheckPoint;
    private Checkpoint nextCheckPoint;

    private int checkPointsPassed;

    private int lapsPassed;

    private float remainingDistanceToNextCheck;

    public Checkpoint NextCheckPoint { set => nextCheckPoint = value; }
    public Checkpoint LastCheckPoint { get => lastCheckPoint;}
    public float RemainingDistanceToNextCheck { get => remainingDistanceToNextCheck; }
    public int LapsPassed { get => lapsPassed;  }
    public int CheckPointsPassed { get => checkPointsPassed; }

    protected override void Awake()
    {
        base.Awake();
        main.CheckPointsSystem = this;
    }

    private void Update()
    {
        if(nextCheckPoint)
        {
            remainingDistanceToNextCheck = Vector3.Distance(transform.position, nextCheckPoint.transform.position);
            main.GM.UpdateRanking();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Checkpoint thisCheckPoint))
        {
            if(thisCheckPoint.CheckPointNumber == checkPointsPassed + 1)
            {
                if(lastCheckPoint != thisCheckPoint)
                {
                    NewCheckPoint(thisCheckPoint);
                }

            }
        }
    }

    private void NewCheckPoint(Checkpoint thisCheckPoint)
    {
        checkPointsPassed++;
        lastCheckPoint = thisCheckPoint;
        main.NewCheckPointPassed();
        if (checkPointsPassed == main.GM.TotalCheckPoints) //Si he llegado al último contando con meta...
        {
            NewLap();
        }
    }

    private void NewLap()
    {
        checkPointsPassed = 0;
        lapsPassed++;
        main.NewLapPassed();
        if(lapsPassed == main.GM.TotalLaps)
        {
            Debug.Log("WIIIIIIIN");
        }
    }
}
