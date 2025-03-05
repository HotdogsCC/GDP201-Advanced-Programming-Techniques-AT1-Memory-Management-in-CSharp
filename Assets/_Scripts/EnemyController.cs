using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("Movement Speed of Enemy")]
    [SerializeField] private float moveSpeed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        //Find the players position
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //Get the direction to the player
        Vector3 directionToPlayer = playerPosition - transform.position;
        //Normalise it
        directionToPlayer.Normalize();
        //Move the enemy towards the player
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime, Space.World);
        transform.LookAt(playerPosition, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If we hit the target 
        if (other.CompareTag("Player"))
        {
            //Player takes 1 damage
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            //Return the enemy to the pool
            ObjectPool.Get().ReturnToPool(gameObject);
        }
    }

}
