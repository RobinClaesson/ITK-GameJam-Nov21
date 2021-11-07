using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserChargeScript : MonoBehaviour
{
    public float growSpeed = 5;
    public float endSize = 100;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale += new Vector3(growSpeed, growSpeed, growSpeed);
        if(transform.localScale.x >= endSize)
        {
            GameObject.Instantiate(laser, transform.parent);
            Destroy(gameObject);
        }
    }
}
