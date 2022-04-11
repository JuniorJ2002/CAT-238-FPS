using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject enemySpawner;

    [Header("UI")]
    public Text ammoText;
    public Text healthText;
    public Text enemyText;
    public Text infoText;

   

    // Start is called before the first frame update
    void Start()
    {
        infoText.gameObject.SetActive(false); // Disabling info text
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + player.Ammo;
        healthText.text = "Health: " + player.Health;
        

        int KilledEnemies = 0;
        foreach(Enemy enemy in enemySpawner.GetComponentsInChildren<Enemy>())
        {
            //We are going to iterate over every enemy
            if(enemy.Killed == false)
            {
                KilledEnemies++;
            }
        }
        enemyText.text = "Enemies: " + KilledEnemies;

        //Win Condition
        if(KilledEnemies == 0)
        {
            infoText.gameObject.SetActive(true);
            //infoText.text = "You Win!\n Good Job!";
        }
        //Lose Condition
        if (player.Killed == true)
        {
            infoText.gameObject.SetActive(true);
            infoText.text = "You Lose!";
        }
    }
}
