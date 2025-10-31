using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public float respawnDelay = 2f;
    private PlayerController playerController;
    public int score;
    public GameEvent playerRespawnEvent;  // Add this line

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        playerController.transform.position = playerController.respawnPoint;
        playerController.gameObject.SetActive(true);
        playerRespawnEvent.Raise();  // Add this line
    }

    public void AddScore(int numberOfPoints)
    {
        score += numberOfPoints;
        scoreText.text = "Score: " + score;
    }
}