using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Fungsi untuk memulai dari level pertama
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Ganti dengan nama scene level pertama Anda
        PlayerPrefs.SetString("LastLevel", "Level1"); // Simpan progress awal
        PlayerPrefs.Save();
    }

    // Fungsi untuk melanjutkan permainan (Continue)
    public void ContinueGame()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "Level1"); // Default ke Level1 jika belum ada progress
        SceneManager.LoadScene(lastLevel);
    }

    // Fungsi untuk memuat level tertentu
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        PlayerPrefs.SetString("LastLevel", levelName); // Simpan progress
        PlayerPrefs.Save();
    }

    // Fungsi untuk kembali ke menu utama (lobby)
    public void GoToLobby()
    {
        SceneManager.LoadScene("MainMenu"); // Ganti dengan nama scene lobby/menu utama Anda
    }

    // Fungsi untuk keluar dari game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); // Hanya terlihat di Editor
    }
}
