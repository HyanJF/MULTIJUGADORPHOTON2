using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorNetworked : NetworkBehaviour
{
    [Networked, OnChangedRenderAttribute(nameof(ColorChanged))]
    public Color NetworColor {  get; set; }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            NetworColor = Color.red;
        }
    }

    public void ColorChanged()
    {
        Debug.Log("Color Stuff");
    }
}
