using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Fungsi untuk restart game (reload level saat ini)
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset waktu ke normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Muat ulang scene saat ini
    }

    // Fungsi untuk kembali ke lobby
    public void GoToLobby()
    {
        Time.timeScale = 1f; // Reset waktu ke normal
        SceneManager.LoadScene("MainMenu"); // Ganti dengan nama scene lobby Anda
    }

    // Fungsi untuk keluar dari game
    public void QuitGame()
    {
        Application.Quit(); // Keluar dari game (tidak berlaku di editor)
        Debug.Log("Game exited"); // Debug log untuk memastikan fungsi dipanggil (hanya untuk editor)
    }
}
