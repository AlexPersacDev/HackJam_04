using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnSystem : CarSystem
{
    private Vector3 lastSpawnPosition;



    protected override void Awake()
    {
        base.Awake();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CheckPoint"))
        {
            lastSpawnPosition = other.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Scenery"))
        {

        }
    }
}
