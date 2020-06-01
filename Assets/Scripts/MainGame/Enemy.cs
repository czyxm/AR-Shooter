using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int type;
    public int health;
    public int healthMax;
    public Slider healthBar;
    public int exp;
    public float init_time;
    public float speed;
    public float radis;
    public float hateRadis;
    public int attackPower;
    public GameObject explosionEffect;
    public static int finish = 0;

    private Player player;
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
        player = GameObject.Find("AR Camera").GetComponent<Player>();
        //init_dest = new Vector3(0.0f, 10.0f, 0.0f);
        //Debug.Log(init_dest);
        if (type > 0)
        {
            target_dest = new Vector3(Random.Range(-radis, radis), Random.Range(radis, radis / 10), Random.Range(-radis, radis));
            transform.LookAt(target_dest);
            StartCoroutine(UpdateMode());
        }
    }

    void Awake()
    {
        if (type == 0)
        {
            finish = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 || finish == 1)
        {
            if (type == 0)
            {
                FindObjectOfType<Devdog.General.AudioManager>().Play("TurretDeath");
            }
            else
            {
                FindObjectOfType<Devdog.General.AudioManager>().Play("EnemyDeath");
            }
            Instantiate(explosionEffect, transform.position, transform.rotation);
            player.score = (player.score + exp >= 10000) ? 9999 : player.score + exp;
            if (type == 0 && finish == 0)
            {
                finish = 1;
                FindObjectOfType<Devdog.General.AudioManager>().Stop("MainBackground");
                FindObjectOfType<ScoreManager>().addEntry(player.playerName, player.score);
                SceneManager.LoadScene("Fail");
            }
            Destroy(gameObject);
        }

        if (player.attackPower == 50 && (player.score >= 1200 || (type == 0 && health < healthMax / 2f)))
        {
            gameObject.GetComponent<SpawnObject>().SpawnRound2();
            player.attackPower = 100;
        }
        if (player.attackPower == 100 && (player.score >= 2500 || (type == 0 && health < healthMax / 4f)))
        {
            gameObject.GetComponent<SpawnObject>().SpawnRound3();
            player.attackPower = 200;
        }

        if (type == 0)
        {
            return;
        }

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
                    player.health = player.health - attackPower;
                    FindObjectOfType<Devdog.General.AudioManager>().Play("PlayerDamage" + (type == 1 ? "2" : "0"));
                    Instantiate(player.wave, player.transform.position + player.transform.forward * 0.5f, player.transform.rotation);
                    Destroy(gameObject);
                }
                break;
        }
    }

    IEnumerator UpdateMode()
    {
        yield return new WaitForSeconds(init_time);
        mode = EnemyMode.PEACE;
        yield return new WaitForSeconds(30.0f);
        mode = EnemyMode.ATTACK;
    }
}
