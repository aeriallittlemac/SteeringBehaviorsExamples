using UnityEngine;
using System.Collections;

public class Arriver: SteeringBehavior {
    Vector3 targetPosition;
    bool unset = true;
    Rigidbody rb;
    int decelerationConstant;
    public float tweaker = 1.7f;
	
    public Arriver(Rigidbody rb,int decelerationConstant,float tweaker = 1.7f )
    {
        this.rb = rb;
        this.decelerationConstant = decelerationConstant;
        this.tweaker = tweaker;
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