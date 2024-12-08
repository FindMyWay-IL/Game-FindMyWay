using UnityEngine;
using UnityEngine.UI; // Untuk UI
using UnityEngine.SceneManagement; // Untuk memuat scene baru

public class DoorInteraction : MonoBehaviour
{
    public GameObject uiPanel; // Panel UI yang berisi tombol
    public Button lobbyButton; // Tombol Lobby
    public Button nextLevelButton; // Tombol Next Level
    //public string nextLevelSceneName = "NextLevel"; // Nama scene level berikutnya

    private bool isNearDoor = false; // Menandakan apakah pemain dekat pintu

    void Start()
    {
        // Menyembunyikan UI Panel saat game dimulai
        uiPanel.SetActive(false);

        // Menambahkan listener untuk tombol
        lobbyButton.onClick.AddListener(GoToLobby);
        nextLevelButton.onClick.AddListener(GoToNextLevel);
    }

    void Update()
    {
        // Memunculkan UI saat pemain berada di dekat pintu dan menekan tombol interaksi
        if (isNearDoor && Input.GetKeyDown(KeyCode.E)) // Gunakan E sebagai tombol interaksi
        {
            ShowUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = true;
            Debug.Log("Pemain dekat pintu. Tekan E untuk melanjutkan.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = false;
            Debug.Log("Pemain menjauh dari pintu.");
        }
    }

    private void ShowUI()
    {
        // Menampilkan UI saat pemain mendekati pintu
        uiPanel.SetActive(true);
    }

    private void GoToLobby()
    {
        // Logika untuk kembali ke lobby, misalnya memuat scene lobby
        Debug.Log("Menuju ke Lobby...");
        SceneManager.LoadScene("MainMenu"); // Ganti "LobbyScene" dengan nama scene lobby yang sesuai
    }

    //private void GoToNextLevel()
    //{
    //    // Logika untuk melanjutkan ke level berikutnya
    //    Debug.Log("Melanjutkan ke level berikutnya...");
    //    SceneManager.LoadScene(nextLevelSceneName); // Ganti dengan nama scene level berikutnya
    //}
    private void GoToNextLevel()
    {
        // Logika untuk melanjutkan ke level berikutnya
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Melanjutkan ke level berikutnya: " + nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex); // Memuat level berikutnya berdasarkan build index
        }
        else
        {
            Debug.Log("Tidak ada level berikutnya. Kembali ke lobby.");
            SceneManager.LoadScene("MainMenu"); // Atur kembali ke MainMenu jika level habis
        }
    }
}
