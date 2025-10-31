using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    public float movement;
    public float speed = 5f;
    public float jumpSpeed = 7f;

    [Header("GroundCheck")]
    public Transform groundCheckPoint;
    public float groundcheckRadius;
    public LayerMask groundLayer;

    public bool isTouchingGround = false;

    public Vector3 respawnPoint;

    private GameManager gameManager;

    public Animator playerAnimation;

    public AudioSource jumpSound;
   
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
          playerAnimation = GetComponent<Animator>();
          respawnPoint = transform.position;
          gameManager = FindAnyObjectByType <GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundcheckRadius, groundLayer);

        if (movement < 0)
        {
            rb2d.linearVelocity = new Vector2(movement * speed, rb2d.linearVelocity.y);
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        else if (movement > 0)
        {
            rb2d.linearVelocity = new Vector2(movement * speed, rb2d.linearVelocity.y);
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
        else
        {
            rb2d.linearVelocity = new Vector2(0,rb2d.linearVelocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpSpeed);

            jumpSound.Play();
        }

        playerAnimation.SetFloat("isRunning", Mathf.Abs(rb2d.linearVelocity.x));
        playerAnimation.SetBool("isTouchingGround", isTouchingGround);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("FallDetector"))
        {
            gameManager.RespawnPlayer();
        }
       if (other.CompareTag("CheckPoint"))
       {
            respawnPoint = other.transform.position;
       }
        if (other.tag == "EndTrigger")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
    