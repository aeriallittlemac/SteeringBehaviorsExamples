using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArriver : MonoBehaviour
{
    // Start is called before the first frame update
    private Arriver arriver;
    private Breaker breaker;
    public int decelerationConstant = 1;
    public float tweaker;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        SteeringObject so = GetComponent<SteeringObject>();
        arriver = GetComponent<Arriver>();
        if (arriver == null)
        {
            arriver = gameObject.AddComponent<Arriver>();
            arriver.rb = rb;
            arriver.decelerationConstant = decelerationConstant;
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
                arriver.SetArrivalPosition(hit.point);
            }
        }
        
    }
}
