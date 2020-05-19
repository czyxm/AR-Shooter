using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToShoot : MonoBehaviour
{
    public float fillingTime = 0.3f;
    private bool isRightGun = true;
    private float lastFillingTime = 999.0f;
    private ParticleSystem right;
    private ParticleSystem left;
    private RaycastHit hit;
    private AudioSource shootAudio;
    // Start is called before the first frame update
    void Start()
    {
        right = GameObject.Find("GunFire_R").GetComponentInChildren<ParticleSystem>();
        left = GameObject.Find("GunFire_L").GetComponentInChildren<ParticleSystem>();
        shootAudio = GetComponent<AudioSource>();
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
                right.Play();
            }
            else
            {
                left.Play();
            }
            shootAudio.Play();
            isRightGun = !isRightGun;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)), out hit, 100.0f)) {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                enemy.health -= 100;
            }
        }
    }
}
