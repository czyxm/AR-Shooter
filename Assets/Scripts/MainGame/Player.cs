using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int healthMax = 100;
    public int attackPower = 50;
    public int score = 0;
    public string playerName;
    public Text healthText;
    public Text scoreText;
    public Image healthBar;
    public GameObject wave;

    void Awake()
    {
        FindObjectOfType<Devdog.General.AudioManager>().Play("MainBackground");
    }

    // Start is called before the first frame update
    void Start()
    {
        //healthText = GameObject.Find("Health").GetComponent<Text>();
        //healthBar = GetComponent<Image>();
        //healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = (health >= 0 ? health.ToString() : "0") + "/" + healthMax.ToString();
        scoreText.text = score.ToString("D4");
        //health = health - 1;
        Debug.Log(health);
        healthBar.fillAmount = (float)health / (float)healthMax;
        if (health <= 0)
        {
            FindObjectOfType<Devdog.General.AudioManager>().Stop("MainBackground");
            FindObjectOfType<ScoreManager>().addEntry(playerName, score);
            SceneManager.LoadScene("Fail");
        }
    }
}
