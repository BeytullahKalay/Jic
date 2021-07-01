using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "CoinHolder")]
public class CoinScritableObject : ScriptableObject
{
    [SerializeField] private int coin = 0;

    public List<int> PurchasedItemNumsList;

    private Sprite playerSprite;

    public void IncreaseCoin(int increaseValue)
    {
        coin += increaseValue;
    }

    public void UseCoins(int decreaseValue)
    {
        coin -= decreaseValue;
    }

    public int getCoinAsInt()
    {
        return coin;
    }

    public bool HasEnoughCoins(int amount)
    {
        return coin >= amount;
    }


    // -----------------------------Menu Character selection Scripts----------------------

    public void AddPurchasedItem(int PurchasedItemNum)
    {
        PurchasedItemNumsList.Add(PurchasedItemNum);
    }

    public List<int> GetPurchasedItemNumsList()
    {
        return PurchasedItemNumsList;
    }

    public void SetPlayerSprite(Sprite newSprite)
    {
        playerSprite = newSprite;
    }

    public Sprite GetPlayerSprite()
    {
        return playerSprite;
    }
}
