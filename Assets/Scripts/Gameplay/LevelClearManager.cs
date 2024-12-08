using UnityEngine;

public class LevelClearManager : MonoBehaviour
{
    public GameObject levelClearMenu;  // UI menu untuk level clear
    public KeyCollector keyCollector;  // Referensi ke KeyCollector untuk memeriksa jumlah kunci

    private void Start()
    {
        // Pastikan Level Clear Menu tidak muncul di awal
        if (levelClearMenu != null)
        {
            levelClearMenu.SetActive(false);
        }
    }

    private void Update()
    {
        // Periksa jika kunci sudah terkumpul sebanyak 3
        if (keyCollector.keysCollected >= 3)
        {
            ShowLevelClearMenu();  // Tampilkan menu level clear jika kunci sudah cukup
        }
    }

    // Fungsi untuk menampilkan menu Level Clear
    public void ShowLevelClearMenu()
    {
        if (levelClearMenu != null)
        {
            Debug.Log("Menampilkan menu level clear...");
            levelClearMenu.SetActive(true);  // Menampilkan menu
            Time.timeScale = 0f;  // Menghentikan permainan (pause) agar pemain bisa memilih
        }
    }

    // Fungsi untuk kembali ke lobby
    public void GoToLobby()
    {
        Time.timeScale = 1f;  // Kembalikan waktu ke normal
        UnityEngine.SceneManagement.SceneManager.LoadScene("LobbyScene");  // Ganti dengan nama scene lobby Anda
    }

    // Fungsi untuk melanjutkan ke level berikutnya
    //public void NextLevel()
    //{
    //    Time.timeScale = 1f;  // Kembalikan waktu ke normal
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("NextLevelScene");  // Ganti dengan nama scene level berikutnya
    //}
    public void NextLevel()
    {
        Time.timeScale = 1f;

        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        Debug.Log("Current Scene Index: " + currentSceneIndex);
        Debug.Log("Next Scene Index: " + nextSceneIndex);

        if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Loading next level: " + nextSceneIndex);
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels to load! Returning to lobby.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("LobbyScene");
        }
    }

}
