using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject uiWindow; // UI Game Over yang akan ditampilkan

    // Fungsi ini dipanggil ketika objek memasuki area trigger Dead Zone
    private void OnTriggerEnter(Collider other)
    {
        // Debugging: Menampilkan nama objek yang memasuki Dead Zone
        Debug.Log($"Object entered Dead Zone: {other.gameObject.name}");

        // Cek apakah objek yang masuk memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered Dead Zone.");
            ShowUIWindow();
        }
    }

    private void ShowUIWindow()
    {
        if (uiWindow != null)
        {
            uiWindow.SetActive(true); // Tampilkan UI Game Over
            Time.timeScale = 0f; // Hentikan waktu game
        }
    }
}
