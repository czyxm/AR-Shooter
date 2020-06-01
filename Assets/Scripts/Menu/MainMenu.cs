using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider BGMSlider;

    void Awake()
    {
        BGMSlider.value = 0.5f;
    }

    public void StartGame()
    {
        Debug.Log("Load!");
        SceneManager.LoadScene("Loading");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void ChangeVolume()
    {
        FindObjectOfType<Devdog.General.AudioManager>().GlobalVolume = BGMSlider.value;
    }
}
