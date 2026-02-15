using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : GroupBehavior
{
    public float neighborhoodRadius;
    public float tweaker = 1.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    { 
        Init();
        rb = GetComponent<Rigidbody>();  

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public override Vector3 CalculateSteeringForce(float maxVelocity)
    {
        List<GameObject> gameObjects = GroupFindNeighors(neighborhoodRadius) ;
        Vector3 steeringForce = new Vector3(0, 0, 0);
        foreach (GameObject go in  gameObjects)
        {
            if (go != gameObject){ // not us
                Vector3 vectorToUs = rb.position - go.transform.position;
                float distance = vectorToUs.magnitude;
                steeringForce += vectorToUs.normalized / distance;
            }
        }
        return steeringForce*tweaker;
    }
}
