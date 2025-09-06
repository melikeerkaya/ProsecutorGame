using DG.Tweening;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UISlideController : MonoBehaviour
{
    public RectTransform panel;

    [Header("Slide Ayarları")]
    public Vector2 slideInPosition;     // Panelin kaydıktan sonra geleceği konum
    public Vector2 slideOutPosition;    // Panelin gizliyken durduğu konum
    public float duration = 0.5f;
    public Ease easeIn = Ease.OutBack;
    public Ease easeOut = Ease.InBack;

    void Awake()
    {
        if (panel == null)
        {
            panel = GetComponent<RectTransform>();
            if (panel == null)
            {
                Debug.LogWarning($"{name}: UISlideController için RectTransform atanmadı!");
                return;
            }
        }

        // Başta panel gizli olsun
        panel.anchoredPosition = slideOutPosition;
    }

    public void SlideIn()
    {
        if (panel == null) return;
        panel.DOAnchorPos(slideInPosition, duration).SetEase(easeIn);
    }

    public void SlideOut()
    {
        if (panel == null) return;
        panel.DOAnchorPos(slideOutPosition, duration).SetEase(easeOut);
    }

    private bool isSliding = false;

    public void SlideInStepByStep()
    {
        if (panel == null || isSliding) return;

        isSliding = true;

        // Başlangıç pozisyonu (dışarıda)
        panel.anchoredPosition = slideOutPosition;

        Sequence slideSequence = DOTween.Sequence();

        // Adım 1: İlk kafa kısmı görünsün
        slideSequence.Append(panel.DOAnchorPos(new Vector2(0, -696), 0.7f).SetEase(Ease.Linear));

        // 0.2 saniye duraksama
        slideSequence.AppendInterval(0.2f);

        // Adım 2: Biraz daha insin
        slideSequence.Append(panel.DOAnchorPos(new Vector2(0, -595), 0.7f).SetEase(Ease.Linear));

        // 0.2 saniye duraksama
        slideSequence.AppendInterval(0.2f);

        // Adım 3: Tam ortaya insin
        slideSequence.Append(panel.DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.Linear));

        // Minik titreşim efekti
        slideSequence.Append(panel.DOShakeAnchorPos(0.2f, new Vector2(5, 5), 20));

        // Bitince kilidi kaldır
        slideSequence.OnComplete(() =>
        {
            isSliding = false;
        });
    }


}
