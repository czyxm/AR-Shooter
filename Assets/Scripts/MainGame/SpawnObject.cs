using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawnT1;
    public GameObject objectToSpawnT2;
    private int t1Number;
    private int t2Number;

    private GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = GameObject.Find("EnemyContainer");
        SpawnRound1();
    }

    public void SpawnRound1()
    {
        FindObjectOfType<Devdog.General.AudioManager>().Play("EnemySpawn");
        t1Number = 15;
        StartCoroutine(SpawnT1());
    }

    public void SpawnRound2()
    {
        FindObjectOfType<Devdog.General.AudioManager>().Play("EnemySpawn");
        t1Number = 10;
        StartCoroutine(SpawnT1());
        t2Number = 5;
        StartCoroutine(SpawnT2());
    }

    public void SpawnRound3()
    {
        FindObjectOfType<Devdog.General.AudioManager>().Play("EnemySpawn");
        t2Number = 10;
        StartCoroutine(SpawnT2());
    }

    IEnumerator SpawnT1()
    {
        yield return new WaitForSeconds(0.1f);
        if (t1Number > 0) {
            GameObject gameObject = Instantiate(objectToSpawnT1, transform.position + new Vector3(0.0f, 0.05f, 0.0f), transform.rotation);
            gameObject.transform.parent = parentObject.transform;
            t1Number -= 1;
        }
        StartCoroutine(SpawnT1());
    }

    IEnumerator SpawnT2()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        if (t2Number > 0)
        {
            GameObject gameObject = Instantiate(objectToSpawnT2, transform.position + new Vector3(0.0f, 0.05f, 0.0f), transform.rotation);
            gameObject.transform.parent = parentObject.transform;
            t2Number -= 1;
        }
        StartCoroutine(SpawnT2());
    }
}
