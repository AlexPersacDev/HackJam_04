using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    private List<Transform> spawnPoints = new List<Transform>();


    private void Awake()
    {
        foreach (Transform tr in transform)
        {
            spawnPoints.Add(tr);
        }    
    }
    

}
