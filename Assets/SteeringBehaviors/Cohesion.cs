using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : GroupBehavior
{
    public float neighborhoodRadius;
    public float tweaker = 1.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
       //nop
        
    }

    public override Vector3 CalculateSteeringForce(float maxVelocity)
    {
        
        List<GameObject> gameObjects = GroupFindNeighors(neighborhoodRadius) ;
        Vector3 centerOfMass = new Vector3(0, 0, 0);
        foreach (GameObject go in gameObjects)
        {
            centerOfMass += go.transform.position;
        }
        centerOfMass /= (float) gameObjects.Count;
        Vector3 currentPosition = _rb.position;
        Vector3 desiredVelocity = (centerOfMass - currentPosition).normalized * tweaker;
        Vector3 steeringForce = desiredVelocity - _rb.velocity;
        return steeringForce;
    }
}
