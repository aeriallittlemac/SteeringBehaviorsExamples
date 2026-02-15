using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPlayer : MonoBehaviour
{
    public Material it_material;

    public Material notit_material;

    public bool isIt = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        TagPlayer other = collision.gameObject.GetComponent<TagPlayer>();
        if (other != null)
        {
            if (isIt)
            {
                isIt = false;
                GetComponent<Renderer>().material = notit_material;
                other.GetComponent<Renderer>().material = it_material;
                other.isIt = false;
            }
        }
    }
}
