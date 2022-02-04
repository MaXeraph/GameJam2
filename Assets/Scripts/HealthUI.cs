using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject gameOverText;
    public float currentHealth;
    public HealthBar healthBar;
    public Stats stat;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        currentHealth = stat.maxHealth;
        healthBar.setMaxHealth(stat.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(currentHealth);
        currentHealth = stat.currentHealth;

        if (currentHealth == 0){
            gameOverText.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P)) { Time.timeScale = 1f; gameOverText.SetActive(false); stat.currentHealth = stat.maxHealth;
            SpeedManager.updateSpeeds(stat.currentHealth / stat.maxHealth);
        }
    }
}
