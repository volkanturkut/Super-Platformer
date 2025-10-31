using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite blueFlag;
    public Sprite whiteFlag;
    public SpriteRenderer checkPointRenderer;
    public bool checkPointReached = false;

    void Start()
    {
        checkPointRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkPointRenderer.sprite = whiteFlag;
            checkPointReached = true;

            // Oyuncu durumunu Idle (veya uygun başka bir durum) olarak değiştir
            PlayerStateMachine playerStateMachine = other.GetComponent<PlayerStateMachine>();
            if (playerStateMachine != null)
            {
                playerStateMachine.ChangeState(new IdleState(Object.FindFirstObjectByType<GameManager>()));
            }
        }
    }
}