using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed = 40;
    public float maxPos = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed*Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x > maxPos)
            Destroy(gameObject);
    }
}
