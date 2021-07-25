using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// *************   INHERITANCE    *************
// PARENT CLASS -> SpaceObjects


public class SpaceObjects : MonoBehaviour
{
    
    private float speed = 4;

    // ********** ENCAPSULATION **********
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public AudioSource explosionAudio;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();
    }

    // ****** POLYMORPHISM ******

    public virtual void Travel() {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    public virtual void Travel(float unitSpeed)
    {
        transform.Translate(Vector3.back * Time.deltaTime * unitSpeed);
    }


    //Collision events on space objects
    public void OnCollisionEnter(Collision collision)
    {
        //Play explosion particle and sound on collision
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        explosionAudio.Play();

        //Decativate meshes and collider and destroy the gameobject after 2 sec
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 2);

    }

}
