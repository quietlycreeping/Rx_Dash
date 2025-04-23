using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class OnHover : MonoBehaviour
{
    public GameObject infoCanvas;  // Assign in Inspector
    public string infoText = "This is object info"; // Custom info text
    public TextMeshProUGUI infoTextUI; // Assign in Inspector 
    public Transform canvasAnchor;             // Empty GameObject as anchor
    AudioSource soundEffect;
    Renderer hoverMaterial;
    private void Start()
    {
        hoverMaterial = GetComponent<Renderer>();
        soundEffect = GetComponent<AudioSource>();

        if (infoCanvas != null)
        infoCanvas.SetActive(false); // Hide canvas initially
    }
    void OnMouseOver()
    {
        hoverMaterial.material.SetFloat("_NotHover", 0);
        soundEffect.Play();

        if (infoCanvas != null && canvasAnchor != null)
        {
            infoCanvas.SetActive(true);
            infoCanvas.transform.position = canvasAnchor.position;

            if (infoTextUI != null)
                infoTextUI.text = infoText;
        }
    }

    void OnMouseExit()
    {
        hoverMaterial.material.SetFloat("_NotHover", 1);

        if (infoCanvas != null)
            infoCanvas.SetActive(false);
    }
}
