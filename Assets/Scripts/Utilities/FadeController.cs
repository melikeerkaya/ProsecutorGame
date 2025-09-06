using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public CanvasGroup canvasGroup; // veya Image üzerinden çalýþacaksan Image da olur
    public float fadeDuration = 0.5f;

    void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public void FadeIn()
    {
        canvasGroup.DOFade(1f, fadeDuration).SetEase(Ease.OutQuad);
    }

    public void FadeOut()
    {
        canvasGroup.DOFade(0f, fadeDuration).SetEase(Ease.InQuad);
    }
}
