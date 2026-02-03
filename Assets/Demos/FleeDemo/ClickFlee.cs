using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFlee : MonoBehaviour
{
    // Start is called before the first frame update
    private Flee fleeBehavior;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        SteeringObject so = GetComponent<SteeringObject>();
        fleeBehavior = new Flee(rb);
        so.AddSteeringBehavior(fleeBehavior);
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
                fleeBehavior.setFearedPosition(hit.point);
            }
        }
        
    }
}