
using System.Collections;
using System.Text;
using UnityEngine;

public class GUIHandler : MonoBehaviour
{
    
    [SerializeField] private TMPro.TextMeshProUGUI bulletsFiredText;
    [SerializeField] private TMPro.TextMeshProUGUI enemiesKilledText;
    [SerializeField] private TMPro.TextMeshProUGUI healthText;
    [SerializeField] private TMPro.TextMeshProUGUI timeScale;

    private EnemyManager manager;
    private StringBuilder stringBuilder = new StringBuilder();
    
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        
        //Update the bullets fired text
        int bulletsFired = player.GetComponent<TurretShoot>().GetNumberOfShellsFired();

        stringBuilder.Append("Bullet fired: ");
        stringBuilder.Append(bulletsFired);
        bulletsFiredText.text = stringBuilder.ToString();
        stringBuilder.Clear();
        
        //Update the health text
        int health = player.GetComponent<PlayerHealth>().GetHealth();
        stringBuilder.Append("Health: ");
        stringBuilder.Append(health);
        healthText.text = stringBuilder.ToString();
        stringBuilder.Clear();
        
        //Update the enemies killed text
        int enemiesKilled = manager.EnemiesKilled();
        stringBuilder.Append("Enemies Killed: ");
        stringBuilder.Append(enemiesKilled);
        enemiesKilledText.text = stringBuilder.ToString();
        stringBuilder.Clear();

        timeScale.text = string.Format("Time Scale: {0:0.00}", Time.timeScale);
    }
}
