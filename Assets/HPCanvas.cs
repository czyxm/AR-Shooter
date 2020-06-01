using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCanvas : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = GameObject.Find("AR Camera").transform.rotation;
    }
}
