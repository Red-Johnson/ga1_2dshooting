using System;
using UnityEngine;

public class BackgroundScroll1 : MonoBehaviour
{
    public Material BgMaterial;

    public float ScrollSpeed = 0.2f;

    private void Update()
    {
        Vector2 direction = Vector2.up;

        BgMaterial.mainTextureOffset += direction * ScrollSpeed * Time.deltaTime;
    }
}