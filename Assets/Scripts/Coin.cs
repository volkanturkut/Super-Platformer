using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreValue;
    public AudioSource coinSound;

    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            gameManager.AddScore(scoreValue);
            Destroy(gameObject);
            coinSound.Play();

            // Oyuncu durumunu Idle (veya uygun başka bir durum) olarak değiştir
            PlayerStateMachine playerStateMachine = other.GetComponent<PlayerStateMachine>();
            if (playerStateMachine != null)
            {
                playerStateMachine.ChangeState(new IdleState(Object.FindFirstObjectByType<GameManager>()));
            }
        }
    }
}