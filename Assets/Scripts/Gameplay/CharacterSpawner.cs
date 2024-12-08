using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject characterPrefab; // Prefab karakter
    public Transform spawnPoint; // Lokasi spawn

    private GameObject currentCharacter;

    void Start()
    {
        var existingCharacter = GameObject.FindWithTag("Player");
        if (existingCharacter != null)
        {
            Destroy(existingCharacter); // Hapus karakter lama
        }

        SpawnCharacter();

        SpawnCharacter(); // Spawn karakter saat scene dimulai
    }

    public void SpawnCharacter()
    {
        if (currentCharacter == null && characterPrefab != null && spawnPoint != null)
        {
            currentCharacter = Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
