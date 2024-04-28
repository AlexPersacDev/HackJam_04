using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemsSpawner : MonoBehaviour
{
    private List<Transform> spawnPoints = new List<Transform>();

    private List<Transform> pointsChosen = new List<Transform>();

    [SerializeField]
    private ObtainableItem[] items;

    private void Awake()
    {
        foreach (Transform tr in transform) //Relleno las listas.
        {
            spawnPoints.Add(tr);
            pointsChosen.Add(tr);
        }

        for (int i = 0; i < 15; i++) //Borro para quedarme con 15.
        {
            pointsChosen.RemoveAt(Random.Range(0, pointsChosen.Count));
        }

        foreach (Transform tr in pointsChosen)
        {
            Debug.Log("paso!");
            float randomValue = Random.value;

            if(randomValue <= 0.35f) //Malo //35%
            {
                Instantiate(items[Random.Range(0, 3)], tr.position, Quaternion.identity);
            }
            else if(randomValue <= 0.65f) //Base //30%
            {
                Instantiate(items[Random.Range(3, 6)], tr.position, Quaternion.identity);
            }
            else if(randomValue <= 0.9f) //Medio 25%
            {
                Instantiate(items[Random.Range(6, 9)], tr.position, Quaternion.identity);
            }
            else //Bueno!! 10%
            {
                Instantiate(items[Random.Range(9, 12)], tr.position, Quaternion.identity);
            }
        }
    }
}
