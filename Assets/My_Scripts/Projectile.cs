using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************   INHERITANCE    *************
// CHILD CLASS -> Projectile

public class Projectile : SpaceObjects
{
    private float missileSpeed = 11.0f;

    // ********** ENCAPSULATION **********
    public float MissileSpeed
    {
        get
        {
            return missileSpeed;
        }
        set
        {
            missileSpeed = value;
        }
    }

    private AudioSource projectileAudio;
    public AudioClip explosionSound;
    public AudioClip missileSound;
    //public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        projectileAudio = GetComponent<AudioSource>();
        projectileAudio.PlayOneShot(missileSound, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // ****** POLYMORPHISM ******
        //Projectile Movement
        base.Travel(-missileSpeed);
    }


    // ****** POLYMORPHISM ******

    //Events that happen when a projectile collides with a space object
    public void OnCollisionEnter(Collision collision)
    {

        // ***** ABSTRACTION *****

            //call base OnCollisionEnter
            base.OnCollisionEnter(collision);
  
            //Check collisions by calling CheckCollisionObject method from game manager
            GameManager.gameManagerInstance.CheckCollisionObject(collision);

            //SoundAndParticleActions that happen on missile collision
            MissileSoundAndParticleActions();

            //Destroys the collision object
            Destroy(collision.gameObject);   
        
            //Destroys the actual missile after 2 secs so the audio can play
            Destroy(gameObject,1.5f);
    }


    //set of sound and particle actions

    // ***** ABSTRACTION *****
    private void MissileSoundAndParticleActions()
    {
        //Play explosion particle and sound on collision
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        projectileAudio.PlayOneShot(explosionSound, 0.4f);

        //Decativate meshes and collider of the  missile
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

}
