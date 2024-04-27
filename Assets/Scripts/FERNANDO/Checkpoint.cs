using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private int checkPointNumber;

    public Transform SpawnLocation { get => spawnLocation;}
    public int CheckPointNumber { get => checkPointNumber; }

    private void Start()
    {
        gM.Checkpoints.Add(this);
        if(gM.Checkpoints.Count == gM.TotalCheckPoints) //Soy el último..
        {
            gM.SortCheckPoints();
        }
    }
}
