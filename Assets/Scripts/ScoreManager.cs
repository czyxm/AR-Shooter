using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int currentScore;
    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
        }
    }

    private Dictionary<string, int> history;

    public void addEntry(string name, int score)
    {
        currentScore = score;
        history.Add(name, score);
    }

    public int findEntry(string name)
    {
        return history[name];
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
