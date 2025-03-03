using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    //The enemy prefab to spawn
    [SerializeField] private GameObject enemyToSpawn;
    //How many enemies to spawn = wavenumber * enemyMultiplier
    private int numberOfEnemiesToSpawn;
    //How far from the spawner can an enemy spawn
    [SerializeField] private Vector2 spawnRange;
    //Used to calculate the number of enemies per wave
    [SerializeField] private int enemyMultiplier;
    private EnemyManager manager;
    
  
    
    //Called in the Enemy manager to intialise the spawner
    public void Init(EnemyManager manager)
    {
        
        this.manager = manager;
        numberOfEnemiesToSpawn = manager.waveNumber * enemyMultiplier;
    }

    public void Update()
    {
        //Update the number of enemies to spawn based on the wave number
        numberOfEnemiesToSpawn = manager.waveNumber * 2;
    }
    
    public GameObject[] SpawnEnemiesForWave()
    {
        //Intialise an array to store the number of enemies spawned this call
        GameObject[] enemiesSpawned = new GameObject[numberOfEnemiesToSpawn];
        
        //Spawn each of the enemies
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            //Calculate the position to spawn
            Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(spawnRange.x, spawnRange.y), 0, transform.position.z + Random.Range(spawnRange.x, spawnRange.y));
            //Get the enemy from the object pool
            GameObject newEnemy = ObjectPool.Get().GetObject();
            //Add it to the array 
            enemiesSpawned[i] = newEnemy;
            //Move the enemy into position
            newEnemy.transform.position = spawnPosition;
            newEnemy.SetActive(true);
        }
        return enemiesSpawned;
    }


    //Draws the spawn zone for the particular spawner
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(gameObject.transform.position, new Vector3(spawnRange.x, 10, spawnRange.y));
    }
}
