using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMain : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    #region MySystems
    private CarMovementSystem movementSystem;
    private CarCheckPointsSystem checkPointsSystem;
    #endregion



    [SerializeField]
    private string playerNumber;

    public string PlayerNumber { get => playerNumber;  }
    public CarMovementSystem MovementSystem { get => movementSystem; set => movementSystem = value; }
    public GameManagerSO GM { get => gM;  }
    public CarCheckPointsSystem CheckPointsSystem { get => checkPointsSystem; set => checkPointsSystem = value; }



    // Start is called before the first frame update
    void Start()
    {
        gM.Players.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewLapPassed()
    {
        gM.PlayerPassedLap(this);
    }

    public void NewCheckPointPassed()
    {
        gM.PlayerPassedCheckPoint(this);
    }
}
