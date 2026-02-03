using UnityEngine;

[System.Serializable]
public class Breaker:SteeringBehavior
{
    private Rigidbody rb;
    private float breakingForce;

    // Constructor used in your ClickSeeker: new breaker(rb, breakingForce)
    public Breaker(Rigidbody rigidbody, float force)
    {
        this.rb = rigidbody;
        this.breakingForce = force;
    }

    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        // 1. If we aren't moving, don't apply any force
        if (rb.velocity.magnitude < 0.01f)
        {
            return Vector3.zero;
        }

        // 2. Calculate a force that points exactly opposite to current velocity
        // We normalize the velocity to get the direction, then scale by breakingForce
        Vector3 reverseForce = -rb.velocity.normalized * breakingForce;

        // 3. Return the force
        return reverseForce;
    }
}