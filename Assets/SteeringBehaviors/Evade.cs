using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : SteeringBehavior
{
    private GameObject _target;
    public GameObject target
    {
        set
        {
            _target = value;
            targetRB = value.GetComponent<Rigidbody>();
            targetTransform = value.GetComponent<Transform>();
            unset = false;
            
        }
        get
        {
            return _target;
        }
    }

    private Transform targetTransform;
    private Rigidbody targetRB;
    private Transform xform;
    public float velocityTweak=1.0f;
    public float predictionWindow = 5;
    private Rigidbody rb;
    private bool unset = true;
   

    // Start is called before the first frame update
    public Evade(GameObject obj)
    {
        rb = obj.GetComponent<Rigidbody>();
        xform = obj.GetComponent<Transform>();
    }

    
    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        if (!unset){
            Vector3 predictedPosition = targetTransform.position + (targetRB.velocity * predictionWindow);
            Vector3 ourPrediction = xform.position + (rb.velocity * predictionWindow);
            //Debug.Log($"{target.name} velocity: {targetRB.velocity} | Kinematic: {targetRB.isKinematic}");
            //Debug.Log(targetRB.gameObject.name + " ID: " + targetRB.GetInstanceID());
            Vector3 force = -1.0f * ((predictedPosition - ourPrediction).normalized * maxVelocity * velocityTweak);
            //SDebug.Log($"Evade force: {force}");
            return force;
            
        } else {
            return Vector3.zero;
        }
        
    }
}
