using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
    public Sprite[] keySprites; // Array sprite untuk kunci
    public Image keyImage;      // Referensi ke UI Image

    public void UpdateKeyDisplay(int keysCollected)
    {
        if (keysCollected >= 0 && keysCollected < keySprites.Length)
        {
            keyImage.sprite = keySprites[keysCollected];
        }
    }
}
