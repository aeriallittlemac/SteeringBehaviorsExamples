using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPath : MonoBehaviour
{
    private SteeringObject steeringObject;

    private PathFollower pathBehavior;
    // Start is called before the first frame update
    void Start()
    {
        steeringObject = GetComponent<SteeringObject>();
        pathBehavior = GetComponent<PathFollower>();
        if (pathBehavior == null)
        {
            pathBehavior = gameObject.AddComponent<PathFollower>();
            pathBehavior.rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                pathBehavior.AddDestination(hit.point);
            }
        }
        
    }
}
