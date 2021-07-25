using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************   INHERITANCE    *************
// CHILD CLASS -> Mines

public class Mines : SpaceObjects
{
    private float scaleSpeed=0.0007f;
    Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
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
        Scaling();
    }

    void Scaling()
    {
        transform.localScale += scaleChange;

    }

}
