
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsPanel : MonoBehaviour
{
    [SerializeField]private TMPro.TextMeshProUGUI bulletsFiredText;

    [SerializeField]private TMPro.TextMeshProUGUI enemiesKilledText;
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

        //Update the enemies killed display
        var manager = FindObjectOfType<EnemyManager>();
        int enemiesKilled = manager.EnemiesKilled();
        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled;
    }


    public void Reset()
    {
        //We reset the scene by reloading it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
