using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class OnHover : MonoBehaviour
{
    AudioSource soundEffect;
    Renderer hoverMaterial;
    private void Start()
    {
        hoverMaterial = GetComponent<Renderer>();
        soundEffect = GetComponent<AudioSource>();
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
