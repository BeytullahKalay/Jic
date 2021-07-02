using UnityEngine;

public class CoinLoot : MonoBehaviour
{
    public CoinScritableObject coinHolderObject;
    public AudioSource takeCoinsSound;

    [SerializeField] private int increaseValue = 5;

    ParticleSystem takeGoldParticleEffect;

    private void Start()
    {
        takeGoldParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("Coin detected!!");
            coinHolderObject.IncreaseCoin(increaseValue);
            Destroy(collision.gameObject);

            takeGoldParticleEffect.Play();
            takeCoinsSound.Play();
        }
    }
}
