using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameManager gameManager;
    float expDelay = 0.5f;
    public AudioSource bombSound;
    private Animator expAnimation;

    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
        expAnimation = GetComponent<Animator>();
    }

    IEnumerator ExpAndWait()
    {
        yield return new WaitForSeconds(expDelay);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            StartCoroutine(ExpAndWait());
            Destroy(this.gameObject, 0.5f);
            gameManager.RespawnPlayer();
            bombSound.Play();
            expAnimation.SetTrigger("EnemyDeath");

            // Oyuncu durumunu Dead olarak değiştir
            PlayerStateMachine playerStateMachine = other.GetComponent<PlayerStateMachine>();
            if (playerStateMachine != null)
            {
                playerStateMachine.Die();
            }
        }
    }
}