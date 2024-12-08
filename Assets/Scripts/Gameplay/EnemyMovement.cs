using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Kecepatan gerak musuh
    public float moveDistance = 5f; // Jarak maksimal musuh bergerak ke kiri dan ke kanan

    private float startingPosition; // Posisi awal musuh
    private bool movingRight = true; // Arah gerakan musuh

    void Start()
    {
        // Menyimpan posisi awal musuh
        startingPosition = transform.position.x;
    }

    void Update()
    {
        // Gerakkan musuh ke kiri atau ke kanan
        float movement = speed * Time.deltaTime * (movingRight ? 1 : -1);
        transform.Translate(movement, 0, 0);

        // Cek apakah musuh mencapai batas kiri atau kanan
        if (movingRight && transform.position.x >= startingPosition + moveDistance)
        {
            Flip();
        }
        else if (!movingRight && transform.position.x <= startingPosition - moveDistance)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Balik arah gerakan
        movingRight = !movingRight;

        // Membalik arah sprite (opsional)
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
