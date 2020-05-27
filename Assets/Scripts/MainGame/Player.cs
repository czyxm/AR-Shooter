using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int healthMax = 100;
    public Text healthText;
    public Image healthBar;
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
        healthText.text = health.ToString() + "/" + healthMax.ToString();
        //health = health - 1;
        Debug.Log(health);
        healthBar.fillAmount = (float)health / (float)healthMax;
        if (health <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
    }
}
