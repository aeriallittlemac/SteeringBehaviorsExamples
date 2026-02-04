using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehavior
{
    private Rigidbody rb;
    private bool unset = true;
    private Vector3 targetPosition;
    public Flee(Rigidbody rb)
    {
        this.rb = rb;
    }

    public void setFearedPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        this.unset = false;
    }

    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        if (!unset)
        {
            Vector3 currentPosition = rb.position;
            Vector3 desiredVelocity=
                (currentPosition - targetPosition).normalized*maxVelocity;
            Vector3 result = desiredVelocity - rb.velocity;
            return result;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public void deactivate()
    {
        unset = true;
    }
}
