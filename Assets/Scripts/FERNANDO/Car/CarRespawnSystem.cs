using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRespawnSystem : CarSystem
{
    private Vector3 lastSpawnPosition; //El primero es la propia meta.
    private Quaternion lastSpawnRotation; 

    private int boundsDetected;

    [SerializeField]
    private float checkRateTime;

    [SerializeField]
    private float recoverTime;

    [SerializeField]
    private float carIsRecoveredThreshold;

    private Rigidbody rb;



    protected override void Awake()
    {
        base.Awake();
        rb = transform.root.GetComponent<Rigidbody>();

        lastSpawnPosition = transform.position; //Por si no llegamos a ning�n checkPoint y nos salimos.
        lastSpawnRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Checkpoint checkPoint))
        {
            lastSpawnPosition = checkPoint.SpawnLocation.position;
            lastSpawnRotation = checkPoint.SpawnLocation.rotation;
        }
        else if(other.CompareTag("Ground"))
        {
            StartCoroutine(Check());
        }
        else if(other.CompareTag("Scenery"))
        {
            boundsDetected++;
        }
    }

    private IEnumerator Check()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkRateTime);

            if(Vector3.Dot(transform.up, Vector3.up) >= carIsRecoveredThreshold)
            {
                StopAllCoroutines();
            }
            else
            {
                ResetCar();

            }

        }
    }

    private void ResetCar()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        rb.rotation = lastSpawnRotation;
        rb.position = lastSpawnPosition;
        Invoke(nameof(BackToDynamic), recoverTime);
        StopAllCoroutines();
    }
    private void BackToDynamic()
    {
        rb.isKinematic = false;

    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Scenery"))
        {
            boundsDetected--;
            if (boundsDetected > 0) return;
            ResetCar();
        }
    }
}
