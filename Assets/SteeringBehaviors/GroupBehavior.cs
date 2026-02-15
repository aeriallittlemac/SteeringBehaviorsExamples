using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[RequireComponent(typeof(Rigidbody))]
public abstract class GroupBehavior : SteeringBehavior
{
    
    internal GameObject _gameObject;
    internal Rigidbody _rb;
    public string  flockTag="";

    public void Awake()
    {
        
    }
    
    public void Init()
    {
        _gameObject = gameObject; 
        _rb = _gameObject.GetComponent<Rigidbody>();
        Debug.Log("Game Object set to "+_gameObject);
    }

    public SteeringObject[] FindSteeringObjects()
    {
        if ((_gameObject == null) || (_rb == null))
        {
            Debug.Log("Not ready "+_gameObject+" "+_rb);
            return Array.Empty<SteeringObject>();
        }
        List<SteeringObject> finalList = new List<SteeringObject>();
        SteeringObject[] steeringObjects = Object.FindObjectsOfType<SteeringObject>();
        foreach (var steeringObject in steeringObjects)
        {
            if ((flockTag == "") || (steeringObject.gameObject.tag == flockTag))
            {
                finalList.Add(steeringObject);
            }
        }

        return finalList.ToArray();
    }


    internal List<GameObject> GroupFindNeighors(float radius){
    
        List<GameObject> neighbors = new List<GameObject>();
        SteeringObject[] steeringObjects = FindSteeringObjects();
        Rigidbody myRB = _gameObject.GetComponent<Rigidbody>();
        // easier to calculate then sqrt and has the virtue of always being positive
        float sqRadius = radius*radius;
        
        foreach (var steeringObject in steeringObjects)
        {
            GameObject otherGO = steeringObject.gameObject;
            Rigidbody otherRigidbody = otherGO.GetComponent<Rigidbody>();
            if ((otherRigidbody != null)&&(otherRigidbody!=myRB))
            {
                if ((otherRigidbody.position - myRB.position).sqrMagnitude >= sqRadius)
                {
                    neighbors.Add(otherGO);
                }
            }
        }

        return neighbors;
    }

    public abstract override Vector3 CalculateSteeringForce(float maxVelocity);

}