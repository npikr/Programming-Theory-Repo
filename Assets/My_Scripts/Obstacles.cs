using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************   INHERITANCE    *************
// CHILD CLASS -> Obstacles

public class Obstacles : SpaceObjects
{
    private float rotateSpeed=60;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Travel();
    }

    // ****** POLYMORPHISM ******
    public override void Travel()
    {
        base.Travel();
        Spining();
    }

    public void Spining()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }

}
