using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CoinHolder")]
public class CoinScritableObject : ScriptableObject
{
    [SerializeField] private int coin = 0;

    public void IncreaseCoin(int increaseValue)
    {
        coin += increaseValue;
    }

    public void DecreaseCoin(int decreaseValue)
    {
        coin -= decreaseValue;
    }

    public int getCoinAsInt()
    {
        return coin;
    }

}
