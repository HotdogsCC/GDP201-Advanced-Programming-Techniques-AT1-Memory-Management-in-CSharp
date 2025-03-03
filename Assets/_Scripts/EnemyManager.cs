using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Holds a reference to all enemies in the scene. Used for tracking waves
    private List<GameObject> enemiesInScene = new List<GameObject>();
    //Holds reference to all spawners.
    private List<EnemySpawner> spawners = new List<EnemySpawner>();

    //Number of waves. Starts at 1
    public int waveNumber;

    //Time between waves after all enemies killed
    [SerializeField] private float spawnDelay;
    //Timer for handling spawn time
    [SerializeField] private float spawnDelayTimer = 0;

    //When false will tick timer. When true will spawn the next wave
    private bool spawn = false;
    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        spawners.AddRange(FindObjectsByType<EnemySpawner>(FindObjectsInactive.Include, FindObjectsSortMode.None));
        for (int i = 0; i < spawners.Count; i++)
        {
            spawners[i].Init(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn)
        {
            //Tick timer up 
            spawnDelayTimer += Time.deltaTime;
            //If timer above spawn delay timer spawn wave. 
            if (spawnDelayTimer >= spawnDelay)
            {
                spawn = true;
                spawnDelayTimer = 0;
                for (int i = 0; i < spawners.Count; i++)
                {
                    //Adds all spawned enemis to the list of enemies in the scene
                    enemiesInScene.AddRange(spawners[i].SpawnEnemiesForWave());
                }
            }
        }
        else
        {
            int activeCount = 0;
            //Count the active enemies in the scene
            for (int i = 0; i < enemiesInScene.Count; i++)
            {
                if(enemiesInScene[i].activeInHierarchy)
                    activeCount++;
            }

            //If there are no active enemies in the scene start the new wave. 
            if (activeCount == 0)
            {
                spawn = false;
                waveNumber++;
            }
        }
    }

    //Function used to count the amount of enemies player has killed.  
    public int EnemiesKilled()
    {
        int count = 0;
        for (int i = 0; i < enemiesInScene.Count; i++)
        {
            if (!enemiesInScene[i].activeInHierarchy) //if the enemy is not active in the scene its dead. 
            {
                count++;
            }
        }

        return count;
    }
}
