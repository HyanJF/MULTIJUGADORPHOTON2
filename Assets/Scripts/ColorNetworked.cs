using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorNetworked : NetworkBehaviour
{
    private MeshRenderer mr;
    [Networked, OnChangedRenderAttribute(nameof(ShainBrightLaikDaimond))]
    public Color color { get; set; }

    private void Start()
    {
        gameObject.TryGetComponent(out mr);

    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("NEGRO MI HIJO ES NE#");
            color = Random.ColorHSV();
        }
    }

    private void ShainBrightLaikDaimond()
    {
        mr.material.color = color;
    }

    [Networked, OnChangedRenderAttribute(nameof(ColorChanged))]
    public Color NetworkColor {  get; set; }

    public void ColorChanged()
    {
        Debug.Log("Color Stuff");
    }
}
