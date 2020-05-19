using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    public float speed = 10.0f;
    public float flyDistance = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = speed * Time.deltaTime;
        transform.Translate(transform.forward * distance, transform);
        flyDistance -= distance;
        if (flyDistance <= 0)
            Destroy(gameObject);
    }
}