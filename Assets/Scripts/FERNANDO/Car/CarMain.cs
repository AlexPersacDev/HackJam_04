using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMain : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private PlayerSO myId;

    #region MySystems
    private CarMovementSystem movementSystem;
    private CarInventorySystem inventorySystem;
    private CarCheckPointsSystem checkPointsSystem;
    #endregion



    [SerializeField]
    private string playerNumber;

    private Rigidbody rb;
    public string PlayerNumber { get => playerNumber;  }
    public CarMovementSystem MovementSystem { get => movementSystem; set => movementSystem = value; }
    public GameManagerSO GM { get => gM;  }
    public CarCheckPointsSystem CheckPointsSystem { get => checkPointsSystem; set => checkPointsSystem = value; }
    public CarInventorySystem InventorySystem { get => inventorySystem; set => inventorySystem = value; }
    public PlayerSO MyId { get => myId; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gM.Players.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIDCar (PlayerSO idRecived)
    {
        myId = idRecived;
        playerNumber = myId.PlayerNumber.ToString();
    }
    public void NewLapPassed()
    {
        gM.PlayerPassedLap(this);
    }

    public void NewCheckPointPassed()
    {
        gM.PlayerPassedCheckPoint(this);
    }

    public void Stop()
    {
        movementSystem.enabled = false;
    }
}
