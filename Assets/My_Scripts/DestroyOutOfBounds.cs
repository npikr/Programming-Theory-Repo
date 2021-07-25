using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBounds = 10.0f;
    private float bottomBounds = -30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBounds)
        {
            Destroy(gameObject);
        }

    }
}
