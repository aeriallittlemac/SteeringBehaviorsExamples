using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAndEvade : MonoBehaviour
{
    private Vector3 wanderTarget = Vector3.zero;
    public float wanderRadius = 8f;
    private Rigidbody rb;
    public float wanderDistance = 5f;
    public float wanderJitter = 25f;
    public float startingVelocity = 1.0f;
    public GameObject evaded;
    // Start is called before the first frame update
    void Start()
    {
        //Evade setup
        Rigidbody rb = GetComponent<Rigidbody>();
        SteeringObject so = GetComponent<SteeringObject>();
        Evade evader = new Evade(gameObject);
        evader.target = evaded;
        so.AddSteeringBehavior(evader);
        // wander setup
       
        Wander wander = new Wander(gameObject);
        so.AddSteeringBehavior(wander);
    }

    public WanderAndEvade()
    {
        
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