using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persuer : MonoBehaviour
{
    public GameObject persued;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        SteeringObject so = GetComponent<SteeringObject>();
        Persue persuer = new Persue(gameObject);
        persuer.target = persued;
        so.AddSteeringBehavior(persuer);
        
    }

   
}
