using UnityEngine;
using UnityEngine.UI;

public class CameraFollowWithBackground : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public Image backgroundImage; // Referensi ke background UI Image

    void Update()
    {
        if (target != null)
        {
            // Kamera mengikuti target
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }

        // Background image tetap berada di layar (UI Image tidak perlu gerakan tambahan)
    }
}
