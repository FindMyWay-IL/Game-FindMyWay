using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Referensi ke panel menu
    public GameObject menuPanel;
    public Transform playerTransform;

    private void Start()
    {
        // Pastikan panel tidak aktif saat memulai
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    // Fungsi untuk menampilkan panel menu
    //public void ShowMenu()
    //{
    //    if (menuPanel != null)
    //    {
    //        Debug.Log("ShowMenu called - Activating menuPanel");
    //        menuPanel.SetActive(true); // Menampilkan panel menu
    //    }
    //    else
    //    {
    //        Debug.LogError("menuPanel is not assigned in the Inspector!");
    //    }
    //}

    public void ShowMenu()
    {
        if (menuPanel != null)
        {
            // Save the player's position before pausing
            if (playerTransform != null)
            {
                PlayerPrefs.SetFloat("PlayerPosX", playerTransform.position.x);
                PlayerPrefs.SetFloat("PlayerPosY", playerTransform.position.y);
                PlayerPrefs.SetFloat("PlayerPosZ", playerTransform.position.z);
            }
            menuPanel.SetActive(true); // Show the menu
        }
    }

    // Fungsi untuk menyembunyikan panel menu
    public void HideMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false); // Menyembunyikan panel menu
        }
    }

    // Fungsi untuk membuka scene lobby
    public void GoToLobby()
    {
        SceneManager.LoadScene("MainMenu"); // Ganti "Lobby" dengan nama scene menu utama Anda
    }

    // Fungsi untuk melanjutkan game (continue)
    //public void ContinueGame()
    //{
    //    string lastLevel = PlayerPrefs.GetString("LastLevel", "Level01"); // Ambil nama level terakhir yang disimpan
    //    Debug.Log("Continuing to: " + lastLevel); // Debug: Memastikan level yang dilanjutkan
    //    SceneManager.LoadScene(lastLevel); // Memuat level yang disimpan
    //}
    public void ContinueGame()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false); // Hide the menu
        }

        // Restore the player's position
        if (playerTransform != null)
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX", playerTransform.position.x);
            float y = PlayerPrefs.GetFloat("PlayerPosY", playerTransform.position.y);
            float z = PlayerPrefs.GetFloat("PlayerPosZ", playerTransform.position.z);

            playerTransform.position = new Vector3(x, y, z);
        }
    }

    // Fungsi untuk keluar dari game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("MainMenu"); // Hanya terlihat di Editor
    }
}
