using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : GroupBehavior
{
    public float neighborhoodRadius;
    public float tweaker = 1.0f;

    private Rigidbody rb;

// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

// Update is called once per frame
    void Update()
    {
        //nop

    }

    public override Vector3 CalculateSteeringForce(float maxVelocity)
    {
        List<GameObject> gameObjects = GroupFindNeighors(neighborhoodRadius);
        Vector3 avgHeading = new Vector3(0, 0, 0);
        foreach (GameObject go in gameObjects)
        {
            if (go != gameObject) // not us
            {
                Vector3 v = go.GetComponent<Rigidbody>().velocity;
                avgHeading += v;
            }
        }

        avgHeading /= (float)gameObjects.Count;
        return avgHeading;
    }
}

