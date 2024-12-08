using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Referensi ke objek yang berisi menu utama dan menu level
    public GameObject mainMenu;
    public GameObject levelMenu;

    // Fungsi untuk menampilkan menu level
    public void ShowLevelMenu()
    {
        mainMenu.SetActive(false);  // Menyembunyikan menu utama
        levelMenu.SetActive(true);  // Menampilkan menu level
    }

    // Fungsi untuk kembali ke menu utama
    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);  // Menampilkan menu utama
        levelMenu.SetActive(false); // Menyembunyikan menu level
    }

    // Fungsi untuk memulai level
    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); // Memuat scene level berdasarkan nama yang diberikan
    }

    // Fungsi untuk keluar dari game
    public void ExitGame()
    {
        Application.Quit(); // Keluar dari aplikasi
        Debug.Log("Exiting game..."); // Pesan debug ketika tombol exit ditekan
    }
}
