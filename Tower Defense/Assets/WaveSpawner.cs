using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] Text waveCountdownText;

    private string gameOver = "Game Over";
    private float waitForSpawn = 1f;
    private float countdown = 2f;
    private int waveNumber = 1;


    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Life>().getLives() <= 0)
        {
            waveCountdownText.text = gameOver;
            GetComponent<Life>().setLives(0);
        }
        else
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }

            countdown -= Time.deltaTime;
            waveCountdownText.text = Mathf.Round(countdown).ToString();
        }
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
           SpawnEnemy();
           yield return new WaitForSeconds(waitForSpawn);
        }

        
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
