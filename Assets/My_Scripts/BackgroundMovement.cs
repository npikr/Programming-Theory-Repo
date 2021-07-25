using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float bgSpeed;
    private Vector3 startPos;
    private float repeatWidth;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManagerInstance.isGameActive) { 

            transform.Translate(Vector3.back * Time.deltaTime * bgSpeed);

            if (transform.position.z < startPos.z - repeatWidth)
            {
                transform.position = startPos;
            }
        }
    }
}
