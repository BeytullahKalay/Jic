using UnityEngine;

public class SetPlayerSprite : MonoBehaviour
{

    SpriteRenderer Sr;

    [SerializeField] CoinScritableObject Repo;

    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        Sr.sprite = Repo.GetPlayerSprite();
    }
    
}
