using UnityEngine;

public class PanelController : MonoBehaviour
{
    public float closeDelay = 0.5f;

    public void Open()
    {
        foreach (var slide in GetComponentsInChildren<UISlideController>())
            slide.SlideIn();

        foreach (var fade in GetComponentsInChildren<FadeController>())
            fade.FadeIn();
    }

    public void Close()
    {
        foreach (var slide in GetComponentsInChildren<UISlideController>())
            slide.SlideOut(); // slideOutPosition'a animasyonla çýkar

        foreach (var fade in GetComponentsInChildren<FadeController>())
            fade.FadeOut();

        StartCoroutine(DelayedClose());
    }

    private System.Collections.IEnumerator DelayedClose()
    {
        yield return new WaitForSeconds(closeDelay);
        gameObject.SetActive(false); // Paneli kapat
        Debug.Log($"{gameObject.name} paneli kapatýldý.");
    }
}
