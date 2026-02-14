using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phobic : MonoBehaviour
{
    public float fearRange = 7.0f;

    private Flee fleeBehavior;
    // Start is called before the first frame update
    void Start()
    {
        fleeBehavior = gameObject.AddComponent<Flee>();
        fleeBehavior.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float fearRangeSqaured = fearRange*fearRange;
        GameObject[] fearedObjects = GameObject.FindGameObjectsWithTag("Feared");
        Rigidbody closestRb = null;
        float closestDistanceSquared = 0;
        foreach (var fearedObject in fearedObjects) // find the closest scary object
        {
            if (closestRb == null)
            {
                closestRb = fearedObject.GetComponent<Rigidbody>();
                closestDistanceSquared = (rb.position - closestRb.position).sqrMagnitude;
            }
            else
            {
                Rigidbody currentRb = fearedObject.GetComponent<Rigidbody>();
                float currentDistanceSquared = (rb.position - currentRb.position).sqrMagnitude;
                if (currentDistanceSquared < closestDistanceSquared)
                {
                    closestRb = currentRb;
                    closestDistanceSquared = currentDistanceSquared;
                }
            }
        }

        if ((closestRb != null) && (closestDistanceSquared < fearRangeSqaured))
        {
            fleeBehavior.setFearedPosition(closestRb.position);
        }
        else
        {
            fleeBehavior.deactivate();
        }
    }
}
