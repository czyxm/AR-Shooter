using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("Health").GetComponent<Text>();
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        if (health <= 0)
        {
            SceneManager.LoadScene("Failed");
        }
    }
}
