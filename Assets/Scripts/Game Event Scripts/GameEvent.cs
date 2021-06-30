using UnityEngine;
using System;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action onPlayerDead;

    public void PlayerDead()
    {
        if (onPlayerDead != null)
        {
            onPlayerDead();
        }
    }
}
