using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public KeyDisplay keyDisplay; // Referensi ke KeyDisplay untuk memperbarui UI
    public DoorManager doorManager; // Referensi ke DoorManager untuk mengelola pintu

    public int keysCollected = 0; // Jumlah kunci yang dikump lkan     
    public int totalKeys = 3;  // Misalnya total kunci yang diperlukan

    private AudioManager audioManager; // Audio manager reference

    private void Awake()
    {
        // Find AudioManager in the scene
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); // Hapus kunci dari scene
            keysCollected++; // Tambah jumlah kunci yang dikumpulkan

            Debug.Log($"Kunci dikumpulkan: {keysCollected}");

            //SFX
            if (audioManager != null && audioManager.pickkey != null)
            {
                audioManager.PlaySFX(audioManager.pickkey);
            }

            // Perbarui UI KeyDisplay
            if (keyDisplay != null)
            {
                keyDisplay.UpdateKeyDisplay(keysCollected);
            }

            // Cek apakah pintu harus terbuka
            if (doorManager != null)
            {
                doorManager.CheckDoor(keysCollected);
            }
        }
    }
}
