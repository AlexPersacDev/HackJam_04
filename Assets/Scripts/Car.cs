using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField]
    private Transform tiresHolder;

    [SerializeField]
    private float springStrength;

    [SerializeField]
    private float springDamper;

    [SerializeField]
    private Transform parteBaja;


    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private float checkDistance;


    private Rigidbody rb;

    private List<Transform> tires = new List<Transform>();


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        foreach (Transform tr in tiresHolder)
        {
            tires.Add(tr);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        
            foreach (Transform tireTransform in tires)
            {
                if (Physics.Raycast(tireTransform.position, Vector3.down, out RaycastHit hit, checkDistance, whatIsGround))
                {
                float suspensionRestDistance = tireTransform.position.y - parteBaja.position.y;

                    Vector3 springDirection = tireTransform.up;

                    //Velocity de esta rueda en world space.
                    Vector3 tireWorldVelocity = rb.GetPointVelocity(tireTransform.position);

                    float offset = suspensionRestDistance - hit.distance;

                Debug.Log(offset);
                    float velocity = Vector3.Dot(springDirection, tireWorldVelocity);

                    float force = (offset * springStrength) - (velocity * springDamper);

                    Debug.Log(force);
                    rb.AddForceAtPosition(springDirection * force, tireTransform.position);
                }

            }
        
    }
}
