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
        Persue persuer = GetComponent<Persue>();
        if (persuer == null)
        {
            persuer = gameObject.AddComponent<Persue>();
            persuer.rb = rb;
            persuer.xform = transform;
        }
        persuer.target = persued;
        
    }

   
}
