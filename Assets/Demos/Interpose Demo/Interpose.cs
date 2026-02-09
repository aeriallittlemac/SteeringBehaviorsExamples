using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpose : MonoBehaviour
{
    public GameObject target1;
    private Rigidbody rb;
    public GameObject target2;
    private Rigidbody target1Rb;
    private Rigidbody target2Rb;
    private Transform target1Transform;
    private Transform target2Transform;
    public float velocityTweak = 1.0f;
    public int decelerationConstant = 1;

    private Arriver arriver; 
    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        arriver = new Arriver(rb,decelerationConstant);
        arriver.tweaker = velocityTweak;
        GetComponent<SteeringObject>().AddSteeringBehavior(arriver);
        target1Rb = target1.GetComponent<Rigidbody>();
        target2Rb = target2.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 initialTargetPoint = (target1Rb.position + target2Rb.position) / 2.0f;
        float d = (initialTargetPoint - rb.position).magnitude;
        float t = d / GetComponent<SteeringObject>().maxVelocity;
        Vector3 newtarget1pos = target1Rb.position + (target1Rb.velocity * t * velocityTweak);
        Vector3 newtarget2pos = target2Rb.position + (target2Rb.velocity * t * velocityTweak);
        Vector3 finalTarget = (newtarget1pos + newtarget2pos) / 2.0f;
        arriver.SetArrivalPosition(finalTarget);
    }
}
