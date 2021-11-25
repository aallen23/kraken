using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject[] shipPrefabs;
    
    private float startDelay = 2;
    private float spawnRate = 2;
    private float spawnRangeX;
    private float spawnRangeY;

    private int playerScore;
    private bool gameOver;

    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        InitiateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameOver = false;
        playerScore = 0;
        //add time delay and control overlay
        StartCoroutine(SpawnEnemy());
    }


    public void InitiateUI()
    {
        scoreText.text = "Score: " + playerScore;
    }

    //change spawn position to always outside the screen
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }

    //update spawnrate as difficulty progresses
    IEnumerator SpawnEnemy()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, shipPrefabs.Length);
            Instantiate(shipPrefabs[index], GenerateSpawnPosition(), shipPrefabs[index].transform.rotation);
        }
    }

    public void UpdateScore()
    {
        playerScore += 10;
        scoreText.text = "Score: " + playerScore;
    }

    public void UpdateHealth()
    {

    }

    public void GameOver()
    {

    }

}
