using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject door; // Referensi ke pintu yang akan dibuka

    public void CheckDoor(int keysCollected)
    {
        if (keysCollected >= 3) // Atau sesuaikan dengan jumlah kunci yang diperlukan
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Pastikan pintu diaktifkan jika awalnya dinonaktifkan
        if (door != null)
        {
            door.SetActive(true); // Aktifkan objek pintu
            Debug.Log("Pintu terbuka!");
        }
    }

}
