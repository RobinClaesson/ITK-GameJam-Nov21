using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public int lifeSpan = 100;
    int tick;

    // Start is called before the first frame update
    void Start()
    {
        tick = lifeSpan;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        tick--;
        if (tick <= 0)
            Destroy(gameObject);
    }
}
