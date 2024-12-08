using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce; // Kekuatan lompatan
    public Animator Anime;

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private bool isGrounded; // Mengecek apakah player berada di tanah
    private bool isPlayingFootsteps; // Prevents overlapping footstep sounds

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Log status input
        Debug.Log("Horizontal Input: " + horizontalInput);

        // Mengatur status animasi lari
        bool isRunning = horizontalInput != 0;
        Anime.SetBool("lari", isRunning);

        // SFX
        if (isRunning && isGrounded && !isPlayingFootsteps)
        {
            StartCoroutine(PlayFootstepsSound());
        }

        // Log status animasi
        Debug.Log("Is Running: " + isRunning);

        // Mengatur arah sprite
        sprite.flipX = horizontalInput < 0;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Mengatur isGrounded ke false setelah melompat

            // SFX
            audioManager.PlaySFX(audioManager.jump);
        }
    }

    private IEnumerator PlayFootstepsSound()
    {
        isPlayingFootsteps = true;
        audioManager.PlaySFX(audioManager.footsteps);
        yield return new WaitForSeconds(0.5f);
        isPlayingFootsteps = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mengecek apakah player menyentuh tanah atau musuh
        //if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        //{
        //    isGrounded = true;
        //    Debug.Log("Player menyentuh: " + collision.gameObject.tag);
        //}

        // Check if player touches the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player menyentuh: Ground");
        }
        // Check if player touches an enemy
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // SFX
            audioManager.PlaySFX(audioManager.damage);
            Debug.Log("Player terkena musuh!");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Mengecek apakah player meninggalkan tanah atau musuh
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            isGrounded = false;
            Debug.Log("Player meninggalkan: " + collision.gameObject.tag);
        }
    }
}
