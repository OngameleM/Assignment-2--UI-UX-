using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManger : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public shopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    

    void Start()
    {
        coins = 100;
        coinsUI.text = "Coins:  " + coins.ToString();
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        coinsUI.text = "Coins:  " + coins.ToString();


        LoadPanels();
        CheckPurchaseable();

    }


    public void CheckPurchaseable()
    {
        for ( int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >=  shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
                
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
               
        }
    }

    public void PurchasItem( int btnNo)
    {
        if ( coins >= shopItemsSO[btnNo].baseCost)
        {
            coins = coins - shopItemsSO[btnNo].baseCost;
            coinsUI.text = "Coins:  " + coins.ToString();
            CheckPurchaseable();
           
        } 
    }

    public void AddCoins()
    {
        coins++;
        coinsUI.text = "Coins:  " + coins.ToString();
        CheckPurchaseable();

            

    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins:  " + shopItemsSO[i].baseCost.ToString();

        }
    }
}

