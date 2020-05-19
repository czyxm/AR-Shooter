using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToShoot : MonoBehaviour
{
    public GameObject bullet;
    public float fillingTime = 0.5f;
    private bool isRightGun = true;
    private Transform rightGun;
    private Transform leftGun;
    private Transform player;
    private float lastFillingTime = 999.0f;
    // Start is called before the first frame update
    void Start()
    {
        rightGun = GameObject.Find("GUN_R").transform;
        leftGun = GameObject.Find("GUN_L").transform;
        player = GameObject.Find("AR Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        lastFillingTime += Time.deltaTime;
        if(Input.touchCount > 0 && lastFillingTime > fillingTime)
        {
            Debug.Log("Fire!");
            lastFillingTime = 0.0f;
            if(isRightGun)
            {
                Instantiate(bullet, rightGun.transform.position, rightGun.transform.rotation);
            }
            else
            {
                Instantiate(bullet, leftGun.transform.position, leftGun.transform.rotation);
            }
            isRightGun = !isRightGun;
        }
    }
}
