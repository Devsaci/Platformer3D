﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfos : MonoBehaviour
{
    public static PlayerInfos pi;

    public int playerHealth = 3;
    public int nbCoins = 0;
    public Image[] hearts;
    public Text coinTxt;
    public Text scoreTxt;
    public CheckpointMgr chkp;

    private void Awake()
    {
        pi = this;
    }

    public void SetHealth(int val)
    {
        playerHealth += val;
        if (playerHealth > 3)
            playerHealth = 3;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            chkp.Respawn();
        }

        SetHealthBar();
    }

    public void GetCoin()
    {
        nbCoins++;
        coinTxt.text = nbCoins.ToString(); // ou ""+nbCoins ... idem
    }

    public void SetHealthBar()
    {
        // On vide la barre de vie
        foreach(Image img in hearts)
        {
            img.enabled = false;
        }
        // On met le bon nb de coeurs
        for(int i=0 ; i<playerHealth; i++)
        {
            hearts[i].enabled = true;
        }
    }

    public int GetScore()
    {
        int scoreFinal = (nbCoins * 5) + (playerHealth * 10);

        scoreTxt.text = "Score = " + scoreFinal;

        return scoreFinal;
    }
}
