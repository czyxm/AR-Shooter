using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int number;

    private GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = GameObject.Find("EnemyContainer");
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.1f);
        if (number > 0) {
            GameObject gameObject = Instantiate(objectToSpawn, transform.position + new Vector3(0.0f, 0.05f, 0.0f), transform.rotation);
            gameObject.transform.parent = parentObject.transform;
            number -= 1;
        }
        StartCoroutine(Spawn());
    }
}
