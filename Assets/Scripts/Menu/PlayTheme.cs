using UnityEngine;
using UnityEngine.UI;

public class PlayTheme : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<Devdog.General.AudioManager>().Play("Theme");
        GameObject.Find("scoreText").GetComponent<Text>().text = FindObjectOfType<ScoreManager>().CurrentScore.ToString("D4");
    }
}
