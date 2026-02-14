using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour, SteeringBehavior
{
    public Seeker seeker;
    public Arriver arriver;
    public Rigidbody rb;
    public float targetDistance = 1.0f;
    private Queue<Vector3> pathQueue = new Queue<Vector3>();
    private Vector3 currentTarget;
    
    private SteeringBehavior currentBehavior=null;
    // Start is called before the first frame update
    public void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (seeker == null) seeker = GetComponent<Seeker>();
        if (seeker == null) seeker = gameObject.AddComponent<Seeker>();
        seeker.tweaker = 3.0f;
        
        if (arriver == null) arriver = GetComponent<Arriver>();
        if (arriver == null) arriver = gameObject.AddComponent<Arriver>();
        arriver.decelerationConstant = 3;
    }

    public void AddDestination(Vector3 destination)
    {
        Debug.Log("Adding destination");
        if (currentBehavior == null)
        {
            Debug.Log("First destination");
            seeker.SetSeekPosition(destination);
            currentTarget = destination;
            currentBehavior = seeker;   
        }
        else
        {
            pathQueue.Enqueue(destination);
        }
        
    }

    public void nextBehavior()
    {
        
        if (pathQueue.Count > 0)
        {
            currentTarget = pathQueue.Dequeue();
            if (pathQueue.Count > 0)
            {
                //have more after dequeue
                currentBehavior = seeker;
                seeker.SetSeekPosition(currentTarget);
                Debug.Log($"Seeking to {currentTarget}");
            }
            else
            {
               
                //last point, use arrival
                currentBehavior = arriver;
                arriver.SetArrivalPosition(currentTarget);
                Debug.Log($"arriving at S {currentTarget}");
            }
        }
    }

    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        Vector3 result;
        if (currentBehavior != null)
        {
            result = currentBehavior.CalculateSteeringForce(maxVelocity);
        }
        else
        {
            result = Vector3.zero;
        }

        if ((rb.position - currentTarget).magnitude <= targetDistance)
        {
            nextBehavior();
        }

        return result;
    }
}
