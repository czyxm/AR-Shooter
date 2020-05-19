using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float init_time = 3.0f;
    public float speed = 1.0f;
    public float radis = 2.0f;
    public float hateRadis = 1.0f;

    private GameObject player;
    private enum EnemyMode {
        INIT,
        PEACE,
        ATTACK
    };
    private EnemyMode mode = EnemyMode.INIT;
    private Vector3 target_dest;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("AR Camera");
        target_dest = new Vector3(Random.Range(-radis, radis), Random.Range(radis, radis / 10), Random.Range(-radis, radis));
        transform.LookAt(target_dest);
        //init_dest = new Vector3(0.0f, 10.0f, 0.0f);
        //Debug.Log(init_dest);
        StartCoroutine(UpdateMode());
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        switch (mode)
        {
            case EnemyMode.INIT:
                if(Vector3.Distance(transform.position, target_dest) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target_dest, step);
                } else
                {
                    mode = EnemyMode.PEACE;
                }
                break;
            case EnemyMode.PEACE:
                if (Vector3.Distance(transform.position, target_dest) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target_dest, step);
                } else
                {
                    target_dest = new Vector3(Random.Range(-radis * 2, radis * 2), Random.Range(radis * 2, radis / 10), Random.Range(-radis * 2, radis * 2));
                    transform.LookAt(target_dest);
                }
                if(Vector3.Distance(player.transform.position, transform.position) < hateRadis)
                {
                    mode = EnemyMode.ATTACK;
                }
                break;
            case EnemyMode.ATTACK:
                target_dest = player.transform.position;
                transform.LookAt(target_dest);
                if (Vector3.Distance(transform.position, target_dest) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target_dest, step);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;
        }
    }

    IEnumerator UpdateMode()
    {
        yield return new WaitForSeconds(init_time);
        mode = EnemyMode.PEACE;
    }
}
