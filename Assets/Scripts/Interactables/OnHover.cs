using UnityEngine;

public class OnHover : MonoBehaviour
{
    Renderer hoverMaterial;
    private void Start()
    {
        hoverMaterial = GetComponent<Renderer>();
    }
    void OnMouseOver()
    {
        hoverMaterial.material.SetFloat("_NotHover", 0);
    }

    void OnMouseExit()
    {
        hoverMaterial.material.SetFloat("_NotHover", 1);
    }
}
