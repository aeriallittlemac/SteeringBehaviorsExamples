using UnityEngine;
using System.Collections;

public class Seeker : SteeringBehavior {
    Vector3 targetPosition;
    bool unset = true;
    Rigidbody rb;
    public float tweaker = 1.0f;

	
    public Seeker(Rigidbody rb)
    {
        this.rb = rb;
    }

    public void SetSeekPosition(Vector3 targetPosition)
    {
            this.targetPosition = targetPosition;
            unset = false;
    }

    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        if (!unset)
        {
            Vector3 currentPosition = rb.position;
            Vector3 desiredVelocity =
                (targetPosition - currentPosition).normalized * maxVelocity;
            Vector3 result = (desiredVelocity - rb.velocity)*tweaker;
            return result;
        }
        else
        {
            //no force}
            return new Vector3(0, 0, 0);
        }
    }

}