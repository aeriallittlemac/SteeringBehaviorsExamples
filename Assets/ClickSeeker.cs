using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSeeker : MonoBehaviour
{
    // Start is called before the first frame update
    private Seeker seeker;
    private Breaker breaker;
    public float breakingForce = 0;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        SteeringObject so = GetComponent<SteeringObject>();
        seeker = new Seeker(rb);
        so.AddSteeringBehavior(seeker);
        if (breakingForce > 0)
        {
            breaker = new Breaker(rb, breakingForce);
            so.AddSteeringBehavior(breaker);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(
                Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                seeker.SetSeekPosition(hit.point);
            }
        }
        
    }
}
