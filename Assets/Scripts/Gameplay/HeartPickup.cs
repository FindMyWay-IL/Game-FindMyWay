using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healthIncrease = 1; // Jumlah health yang bertambah ketika mengambil heart
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika pemain menyentuh objek dengan tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ambil komponen PlayerHealth dari pemain
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Tambahkan health hingga maksimal
                playerHealth.health += healthIncrease;
                if (playerHealth.health > playerHealth.maxHealth)
                {
                    playerHealth.health = playerHealth.maxHealth; // Batasi agar tidak melebihi maxHealth
                }

                // SFX
                if (audioManager != null && audioManager.pickheart != null)
                {
                    audioManager.PlaySFX(audioManager.pickheart);
                }

                // Hancurkan objek heart setelah diambil
                Destroy(gameObject);
            }
        }
    }
}
