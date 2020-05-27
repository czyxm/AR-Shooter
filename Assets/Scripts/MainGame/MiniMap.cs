using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    private RectTransform rect;
    private Transform player;
    private static Image item;
    private static Image itemforEnemy;
    private Image playerImage;
    private Image[] enemyImage=new Image[100];
    private Component[] enemys;
    private GameObject container;
    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("EnemyContainer");
        enemys = container.GetComponentsInChildren(typeof(Component));
        item = Resources.Load<Image>("Player");
        itemforEnemy = Resources.Load<Image>("enemy");
        rect = GetComponent<RectTransform>();
        Debug.Log(item == null);
        player = GameObject.Find("AR Camera").transform;
        Debug.Log(item == null);
        if (player != null)
            playerImage = Instantiate(item);
        for (int i = 0; i < 100; i++)
        {
            enemyImage[i]= Instantiate(itemforEnemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowPlayer();
        ShowEnemy();
    }

    private void ShowPlayer()
    {
        playerImage.rectTransform.sizeDelta = new Vector2(80, 80);
        playerImage.rectTransform.anchoredPosition = new Vector2(0, 0);
        playerImage.rectTransform.eulerAngles = new Vector3(0,0,-player.transform.eulerAngles.y);
        playerImage.sprite = Resources.Load<Sprite>("Texture/logo");
        playerImage.transform.SetParent(transform, false);
    }

    private void ShowEnemy()
    {
        Debug.Log(player.transform.position);
        enemys = container.GetComponentsInChildren(typeof(Component));
        Debug.Log(enemys);
        for (int i = 0; i < enemys.Length; i++)
        {
            enemyImage[i].rectTransform.sizeDelta = new Vector2(20, 20);
            enemyImage[i].rectTransform.anchoredPosition = new Vector2((enemys[i].transform.position.x- player.transform.position.x) *50, (enemys[i].transform.position.z- player.transform.position.z) *50);
            enemyImage[i].sprite = Resources.Load<Sprite>("Texture/dot");
            enemyImage[i].transform.SetParent(transform, false);
            Debug.Log(enemyImage[i].transform.position);
        }
    }
}
