using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *************   INHERITANCE    *************
// CHILD CLASS -> EnemyShip

public class EnemyShip : SpaceObjects
{

    private float startDelay = 1f;
    private float spawnInterval = 2f;
    public GameObject enemyMissile;
    public Vector3 missileOffset;


    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemyMissile", startDelay, spawnInterval);
       
    }

    // Update is called once per frame
    void Update()
    {
        // ****** POLYMORPHISM ******
        base.Travel(-4);
    }

    void SpawnEnemyMissile()
    {
        if (!GameManager.gameManagerInstance.levelComplete && GameManager.gameManagerInstance.isGameActive)
        {
            Instantiate(enemyMissile, transform.position - missileOffset, enemyMissile.transform.rotation);
        }
    }


}
