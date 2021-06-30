using UnityEngine;

public class CoinLoot : MonoBehaviour
{
    public CoinScritableObject coinHolderObject;

    [SerializeField] private int increaseValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("Coin detected!!");
            coinHolderObject.IncreaseCoin(increaseValue);
            Destroy(collision.gameObject);
        }
    }
}
