using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManiMenu : MonoBehaviour
{
    public Slider BGMSlider;
    public AudioSource BGMSource;
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ChangeVolume()
    {
        Debug.Log("ChangeVolume");
        Debug.Log(BGMSlider.value);
        BGMSource.volume = BGMSlider.value;
    }
}
