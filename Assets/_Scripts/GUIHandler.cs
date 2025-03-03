
using System.Collections;
using UnityEngine;

public class GUIHandler : MonoBehaviour
{
    
    [SerializeField] private TMPro.TextMeshProUGUI bulletsFiredText;
    [SerializeField] private TMPro.TextMeshProUGUI enemiesKilledText;
    [SerializeField] private TMPro.TextMeshProUGUI healthText;
    [SerializeField] private TMPro.TextMeshProUGUI timeScale;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Update the bullets fired text
        var player = GameObject.FindGameObjectWithTag("Player");
        int bulletsFired = player.GetComponent<TurretShoot>().GetNumberOfShellsFired();
        bulletsFiredText.text = "Bullets fired: " + bulletsFired;
        
        //Update the health text
        int health = player.GetComponent<PlayerHealth>().GetHealth();
        healthText.text = "Health: " + health;
        
        //Update the enemies killed text
        var manager = FindObjectOfType<EnemyManager>();
        int enemiesKilled = manager.EnemiesKilled();
        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled;

        timeScale.text = string.Format("Time Scale: {0:0.00}", Time.timeScale);
    }
}
