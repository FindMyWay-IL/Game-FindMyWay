using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHearth;
    public Image[] hearts;

    public PlayerHealth playerHealth;

    public GameObject uiWindow; // Referensi ke UI window

    // Start is called before the first frame update
    void Start()
    {
        if (uiWindow != null)
        {
            uiWindow.SetActive(false); // Pastikan UI window tidak aktif di awal
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        // Update hearts display
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHearth;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }

        // Tampilkan UI window jika health mencapai 0
        if (health <= 0)
        {
            ShowUIWindow();
        }
    }

    void ShowUIWindow()
    {
        if (uiWindow != null)
        {
            uiWindow.SetActive(true); // Aktifkan UI window
            Time.timeScale = 0f; // Pause waktu (opsional)
        }
    }
}
