using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int health = 100;
    
    [SerializeField] private GameObject mainGUI;
    [SerializeField] private GameObject gameOverGUI;
    
    //Function for handling damage 
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //When health is zero display game over display 
            mainGUI.SetActive(false);
            gameOverGUI.SetActive(true);
        }
    }

    //Returns health
    public int GetHealth()
    {
        return health;
    }

    
}
