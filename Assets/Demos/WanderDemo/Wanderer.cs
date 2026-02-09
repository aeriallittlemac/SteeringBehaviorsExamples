using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        SteeringObject so = GetComponent<SteeringObject>();
        Wander wander = new Wander(gameObject);
        so.AddSteeringBehavior(wander);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
