using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainableItem : MonoBehaviour
{
    [SerializeField]
    private IngredientsSO myData;

    [SerializeField]
    private Vector3 rotationVector = new Vector3(75, 45, 30);

    [SerializeField]
    private float movementAmplitude;

    [SerializeField]
    private float angularVelocity;

    [SerializeField]
    private AudioClip obtainableSound;

    private Vector3 initialPosition;

    public IngredientsSO MyData { get => myData; set => myData = value; }
    public AudioClip ObtainableSound { get => obtainableSound;}

    private void Awake()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        float sineWave = movementAmplitude * Mathf.Sin(angularVelocity * Time.time);
        transform.position = initialPosition + new Vector3(0, sineWave, 0);

        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
