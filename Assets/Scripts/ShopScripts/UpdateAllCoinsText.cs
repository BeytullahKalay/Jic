using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAllCoinsText : MonoBehaviour
{
    public CoinScritableObject CoinObject;

    [SerializeField] Text[] CoinsText;


    void Start()
    {
        for (int i = 0; i < CoinsText.Length; i++)
        {
            CoinsText[i].text = CoinObject.getCoinAsInt().ToString();
        }
    }

    void Update()
    {
        for (int i = 0; i < CoinsText.Length; i++)
        {
            CoinsText[i].text = CoinObject.getCoinAsInt().ToString();
        }
    }
}
