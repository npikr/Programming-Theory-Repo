using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float speed;
    public float playerBoundries;

    public Vector3 offset;

    public GameObject projectilePrefab;

    // ********** ENCAPSULATION **********
    public static PlayerController playerControllerInstance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (playerControllerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        playerControllerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

        checkPlayerBoundries();

        LaunchProjectile();

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
 
    }

    //Checks the player boundries 
    void checkPlayerBoundries()
    {
        if (transform.position.x < -playerBoundries)
        {
            transform.position = new Vector3(-playerBoundries, transform.position.y, transform.position.z);
        }
        if (transform.position.x > playerBoundries)
        {
            transform.position = new Vector3(playerBoundries, transform.position.y, transform.position.z);
        }
    }

    //Launches a projectile instance
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from player
            Instantiate(projectilePrefab, transform.position + offset, projectilePrefab.transform.rotation);

        }

    }

    //Destroy player on collision with an object
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        GameManager.gameManagerInstance.GameOver();
    }

}
