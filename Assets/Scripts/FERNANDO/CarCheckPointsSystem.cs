using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckPointsSystem : MonoBehaviour
{
    private Checkpoint lastCheckPoint;

    private int checkPointsPassed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Checkpoint thisCheckPoint))
        {
            if(lastCheckPoint != thisCheckPoint)
            {
                checkPointsPassed++;
                lastCheckPoint = thisCheckPoint;
            }
        }
    }

    private void Update()
    {
        Debug.Log(checkPointsPassed);
    }
}
