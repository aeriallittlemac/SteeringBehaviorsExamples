using UnityEngine;
using System.Collections;

public class Arriver: MonoBehaviour, SteeringBehavior {
    Vector3 targetPosition;
    bool unset = true;
    public Rigidbody rb;
    public int decelerationConstant = 3;
    public float tweaker = 1.7f;
	
    public void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    public void SetArrivalPosition(Vector3 targetPosition)
    {
            this.targetPosition = targetPosition;
            unset = false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        Debug.Log("Enter Calculating arrival force");
        if (!unset)
        {
            //Debug.Log("Calculating arrival force");
            Vector3 toTarget = targetPosition - rb.position;
            float distance = toTarget.magnitude;
            if (distance>0){
                float speed = distance/(decelerationConstant*tweaker);
                speed = speed>maxVelocity?maxVelocity:speed;
                Vector3 desiredVelocity = toTarget  * speed / distance;
                Vector3 result = desiredVelocity - rb.velocity;
                //Debug.Log("Force = " + result.ToString() + "");
                return result;
            } else {
                return new Vector3(0, 0, 0);
            }
        }
        else
        {
            //no force}
            return new Vector3(0, 0, 0);
        }
    }

}