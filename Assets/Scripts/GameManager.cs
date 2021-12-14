using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject[] shipPrefabs;
    public GameObject[] spawnPoints;
    
    //private float startDelay = 2;
    private float spawnRate = 2;
   // private float spawnRangeX = 8;
   // private float spawnRangeY = 4;

    private int playerScore;
    private bool gameOver;
    private int healthIndex = 4;

    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject gameScreen;
    public GameObject healthBar;
    public GameObject gameOverScreen;
    public TextMeshProUGUI finalScoreText;


    //public Button startButton;
    //public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPress()
    {
        
        StartGame();
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

    public void StartGame()
    {

        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        if (healthIndex < 4)
        {
            for (int i = 0; i < healthBar.transform.childCount; i++)
            {
                healthBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            healthIndex = 4;
        }

        gameOver = false;
        playerScore = 0;
        scoreText.text = "Score: " + playerScore;
        gameScreen.SetActive(true);
        StartCoroutine(SpawnEnemy());
    }



    //change spawn position to always outside the screen
    //private Vector3 GenerateSpawnPosition()
    //{
    //    float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
    //    float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
    //    Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
    //    return randomPos;
    //}

    //update spawnrate as difficulty progresses
    IEnumerator SpawnEnemy()
    {
        while (!gameOver)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, shipPrefabs.Length);
            Instantiate(shipPrefabs[index], spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore;
    }

    public void UpdateHealth()
    {
        Debug.Log("health updated");
        if (healthIndex > 0 && gameOver == false)
        {
            healthBar.transform.GetChild(healthIndex).gameObject.SetActive(false);
            healthIndex -= 1;
        }
        else
        {
            gameOver = true;
            GameOver();
        }

    }

    public void GameOver()
    {
        finalScoreText.text = "Final Score: " + playerScore;
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

}
