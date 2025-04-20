using UnityEngine;


public class OnHover : MonoBehaviour
{
    public AudioSource soundEffect;
    Renderer hoverMaterial;
    private void Start()
    {
        hoverMaterial = GetComponent<Renderer>();
    }
    void OnMouseOver()
    {
        hoverMaterial.material.SetFloat("_NotHover", 0);
        soundEffect.Play();
    }

    void OnMouseExit()
    {
        hoverMaterial.material.SetFloat("_NotHover", 1);
    }
}
