using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSystem : MonoBehaviour
{
    protected CarMain main;
    protected virtual void Awake()
    {
        main = transform.root.GetComponent<CarMain>();
    }
}
