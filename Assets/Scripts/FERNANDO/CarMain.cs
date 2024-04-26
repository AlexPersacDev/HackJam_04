using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMain : MonoBehaviour
{

    #region MySystems
    private CarMovementSystem movementSystem;
    #endregion

    [SerializeField]
    private string playerNumber;

    public string PlayerNumber { get => playerNumber;  }
    public CarMovementSystem MovementSystem { get => movementSystem; set => movementSystem = value; }

    internal void DeactivateMovement()
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
