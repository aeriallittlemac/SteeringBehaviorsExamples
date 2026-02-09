using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : SteeringBehavior
{
    public float boundingRadius;
    private GameObject gameObj;
    private Rigidbody rb;
    private Transform objXform;
    private Renderer renderer;
    
    public ObstacleAvoider(GameObject myGameObject)
    {
        gameObj = myGameObject;
        rb = gameObj.GetComponent<Rigidbody>();
        objXform = gameObj.GetComponent<Transform>();
        renderer = gameObj.GetComponent<Renderer>();
        // find the largest dimentsion of the GameObject
        boundingRadius = (renderer.bounds.size.x > renderer.bounds.size.y) ?
            renderer.bounds.size.x : renderer.bounds.size.y;
        boundingRadius = (boundingRadius > renderer.bounds.size.z) ? 
            boundingRadius : renderer.bounds.size.z;
        boundingRadius /= 2;
    }

    public float velocityMult = 2.0f;
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 CalculateSteeringForce(float maxVelocity)
    {
        RaycastHit rayHit = new RaycastHit();
        int castMask = ~(
            (1 << LayerMask.NameToLayer("Terrain")) |
            (1 << LayerMask.NameToLayer("Player"))
        );
        Vector2 castPos = objXform.position;
        if (Physics.SphereCast(renderer.bounds.center,
                renderer.bounds.extents.x*2, rb.velocity,out rayHit,
                rb.velocity.magnitude*velocityMult,castMask))
        {
            BoundingSphere bs = new BoundingSphere(rayHit.collider.bounds.center,rayHit.collider.bounds.extents.magnitude);
            Vector3 collisionDirection = (rayHit.point - bs.position).normalized;
            return collisionDirection * maxVelocity;
        }

        return Vector3.zero;
    }
}
