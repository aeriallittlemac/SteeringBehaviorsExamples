using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour, SteeringBehavior
{
    private Vector3 wanderTarget = Vector3.zero;
    public float wanderRadius = 8f;
    public Rigidbody rb;
    public float wanderDistance = 5f;
    public float wanderJitter = 25f;
    public float startingVelocity = 1.0f;

    public void Awake()
    {
        wanderTarget = new Vector3(0, 0, wanderRadius);
        if (rb == null) rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,0,startingVelocity));
    }

    private float NormalizedRandom()
    {
        return Random.Range(-1f, 1f);
    }

    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        Vector3 targetJitter = new Vector3(NormalizedRandom() * wanderJitter,
            0, NormalizedRandom() * wanderJitter);
        wanderTarget += targetJitter;
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;
        Vector3 localTarget = wanderTarget + (rb.velocity.normalized * wanderDistance);
        return localTarget;
    }
}
