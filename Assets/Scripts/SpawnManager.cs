using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject powerupPrefabs;

    private float spawnRange = 9f;
    private int enemyCount;
    private int waveNum = 0;

    private GameManager gameManager;

    void Start()
    {
        gameManager = gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPosition(), transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemy()
    {
        if (gameManager.isGameActive)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0)
            {
                waveNum++;
                SpawnEnemyWave(waveNum);
                Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
            }
        }
    }
}
