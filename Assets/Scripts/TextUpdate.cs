using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextUpdate : MonoBehaviour
{
    private AsyncOperation asy;

    public Text timeText;

    public float time;


    void Start()
    {
        timeText.text = "load";
        StartCoroutine("LoadScene");
        FindObjectOfType<Devdog.General.AudioManager>().Play("Tick");
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = time < 1f ? "1" : time.ToString("0");
    }

    IEnumerator LoadScene()
    {

        //u3d 5.3之后使用using UnityEngine.SceneManagement加载场景

        asy = SceneManager.LoadSceneAsync("MainGame");
        //不允许加载完毕自动切换场景，因为有时候加载太快了就看不到加载进度条UI效果了
        asy.allowSceneActivation = false;
        while (asy.progress < 0.9f || time >= 0.5f)
        {
            yield return new WaitForEndOfFrame();
        }

        Debug.Log(asy.progress);
        yield return new WaitForEndOfFrame();
        asy.allowSceneActivation = true;
    }

    //void Update()
    //{


    //    if (progressB)
    //    {
    //        progressB.value = 0;
    //    }
    //    StartCoroutine("LoadScene");

    //    if (time <= 0)
    //    {
    //        SceneManager.LoadScene("MainGame");
    //    }
    //    time -= Time.deltaTime;
    //    timeText.text = time.ToString("0");

    //}


}
