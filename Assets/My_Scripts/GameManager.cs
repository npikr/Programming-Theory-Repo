using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 12;
    private float spawnRangeZ = 10;
    private float startDelay = 0.5f;
    private float spawnInterval = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public RectTransform endLevelPanel;
    private int score;

    // ********** ENCAPSULATION **********
    public static GameManager gameManagerInstance { get; private set; }

    public bool isGameActive;
    public bool levelComplete = false;
    private float timeLeft;
    private float defaultTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        gameManagerInstance = this;

        timeLeft = defaultTime;

        // ***** ABSTRACTION *****
        StartGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                // ***** ABSTRACTION *****
                LevelComplete();

                //avoid get killed when the game ended
                PlayerController.playerControllerInstance.GetComponent<MeshCollider>().enabled = false;

            }
        }
    }

    // ***** ABSTRACTION *****

    //Start game method
    public void StartGame()
    {   
          InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
          scoreText.text = "Score: " + 0;    
    }

    // ***** ABSTRACTION *****

    //Spawns a random space object
    void SpawnRandomObject()
    {
        if (isGameActive && !levelComplete)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, Random.Range(0, spawnRangeZ));
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }

    // ***** ABSTRACTION *****

    //GameOver method
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }

    // ***** ABSTRACTION *****

    //Level complete method
    public void LevelComplete()
    {
        levelComplete = true;
        endLevelPanel.gameObject.SetActive(true);  
    }

    // ***** ABSTRACTION *****

    //Restart game method
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ***** ABSTRACTION *****

    //Method that updates the current score
    public void UpdateScore(int scoreToAdd)
    {
        if (!levelComplete)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
    }

    // ***** ABSTRACTION *****

    //Method that checks what type of space object space object collides with the projectile prefab and updates the corresponding score
    public void CheckCollisionObject(Collision col)
    {
        if (col.gameObject.CompareTag("BlueAsteroid"))
        {
            UpdateScore(10);
        }
        else if (col.gameObject.CompareTag("LavaAsteroid"))
        {
            UpdateScore(10);
        }
        else if (col.gameObject.CompareTag("Mine"))
        {
            UpdateScore(15);
        }
        else if (col.gameObject.CompareTag("EnemyShip"))
        {
            UpdateScore(20);
        }
    }


}
