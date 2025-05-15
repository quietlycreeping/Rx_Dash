/*=========================================================
 Author:     J. Orlando
 Date:       April 2025
 Description: Base class for other 
              interactable scripts to inherit from
==========================================================*/
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Material))]
public class Interactable : MonoBehaviour
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
