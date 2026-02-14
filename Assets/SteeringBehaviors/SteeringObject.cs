using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringObject : MonoBehaviour
{
    public float maxForce = 1.0f;
    public float maxVelocity = 3.0f;
	[SerializeReference]
    public List<SteeringBehavior> steeringBehaviors = new List<SteeringBehavior>();
        
    // Start is called before the first frame update
    void Start()
    {
        //nop
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 steeringForce = new Vector3(0, 0, 0);
        foreach (SteeringBehavior steeringBehavior in 
                 GetComponentsInChildren<SteeringBehavior>())
        {
            steeringForce = steeringForce + steeringBehavior.CalculateSteeringForce(maxVelocity);
        }
        GetComponent<Rigidbody>().AddForce(steeringForce);
    }

    

}
