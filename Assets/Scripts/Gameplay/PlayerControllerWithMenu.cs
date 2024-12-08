using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerWithMenu : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 5f;       // Kecepatan karakter
    public float jumpForce = 10f;     // Kekuatan lompatan
    public Rigidbody2D rb;            // Referensi Rigidbody2D untuk kontrol fisik
    public Transform groundCheck;     // Titik untuk memeriksa tanah
    public LayerMask groundLayer;     // Layer tanah untuk deteksi lompatan

    [Header("Menu Settings")]
    public GameObject menuPanel;      // Panel menu
    public GameObject continueButton; // Tombol Continue

    private bool isGrounded;          // Apakah karakter berada di tanah

    private void Start()
    {
        // Nonaktifkan menu saat permainan dimulai
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }

        // Periksa apakah ada data tersimpan untuk Continue
        if (PlayerPrefs.HasKey("PlayerPosX"))
        {
            continueButton.SetActive(true); // Tampilkan tombol Continue
        }
        else
        {
            continueButton.SetActive(false); // Sembunyikan tombol Continue
        }
    }

    private void Update()
    {
        // Gerakan horizontal
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Deteksi tanah untuk lompatan
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Lompatan
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Buka atau tutup menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void NewGame()
    {
        // Hapus data progress lama
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.SetInt("ContinueGame", 0);
        PlayerPrefs.Save();

        // Mulai ulang level dari awal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueGame()
    {
        // Ambil posisi terakhir dari PlayerPrefs
        float savedPosX = PlayerPrefs.GetFloat("PlayerPosX", transform.position.x);
        float savedPosY = PlayerPrefs.GetFloat("PlayerPosY", transform.position.y);
        transform.position = new Vector3(savedPosX, savedPosY, 0);

        // Tutup menu
        menuPanel.SetActive(false);
    }

    public void SaveGame()
    {
        // Simpan posisi karakter
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetInt("ContinueGame", 1);
        PlayerPrefs.Save();
    }

    public void ToggleMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(!menuPanel.activeSelf); // Tampilkan atau sembunyikan menu
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited.");
    }
}
