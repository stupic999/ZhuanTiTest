﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpController : MonoBehaviour
{
    float timer;

    public Image playerHealthbarRect;

    [System.Serializable]
    public class playerStats
    {
        public int maxHp = 30;
        int _currentHp;
        public int currentHp
        {
            get { return _currentHp; }
            set { _currentHp = Mathf.Clamp(value, 0, maxHp); }
        }

        public void FullHp()
        {
            currentHp = maxHp;
        }
    }

    public playerStats playerStat = new playerStats();

    [SerializeField]
    private PlayerHp playerHp;

    void Start()
    {
        playerStat.FullHp();
        playerHp.SetHealth(playerStat.currentHp, playerStat.maxHp);
    }

    void Update()
    {
        timer+= Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
            DamagePlayer(1);
            playerHp.SetHealth(playerStat.currentHp, playerStat.maxHp);
            ChangePlayerHpBarColor(playerStat.currentHp, playerHealthbarRect);
        }        
    }

    void FixedUpdate()
    {
        // 作弊
        if (Input.GetKey(KeyCode.F4))
        {
            playerStat.maxHp = 10000;
            playerStat.FullHp();
            playerHp.SetHealth(playerStat.currentHp, playerStat.maxHp);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStat.currentHp -= damage;
        if (playerStat.currentHp <= 0)
        {
            Debug.Log("GameOver");
            // GameOver
        }
        playerHp.SetHealth(playerStat.currentHp, playerStat.maxHp);
    }

    public void HealPlayer(int heal)
    {
        playerStat.currentHp += heal;
        playerHp.SetHealth(playerStat.currentHp, playerStat.maxHp);
    }

    public void ChangePlayerHpBarColor(int PlayerHp,Image playerHpBar)
    {
        if (PlayerHp > 15)
        {
            playerHpBar.color = Color.green;
        }
        else if (PlayerHp <= 15 && PlayerHp > 7)
        {
            playerHpBar.color = Color.yellow;
        }
        else
        {
            playerHpBar.color = Color.red;
        }
    }
}
