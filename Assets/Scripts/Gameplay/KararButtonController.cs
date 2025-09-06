using UnityEngine;
using UnityEngine.UI;

public class KararButonlariController : MonoBehaviour
{
    [Header("Butonlar")]
    public Button takipsizlikKarariButton;
    public Button sorusturmaBaslatButton;

    [Header("Paneller")]
    public UISlideController kararBelgesiSlide;
    public GameObject sorusturmaPanel;

    void Start()
    {
        if (takipsizlikKarariButton != null)
            takipsizlikKarariButton.onClick.AddListener(OnTakipsizlikKarariClicked);

        if (sorusturmaBaslatButton != null)
            sorusturmaBaslatButton.onClick.AddListener(OnSorusturmaBaslatClicked);
    }

    private bool isKararBelgesiAcik = false;

    void OnTakipsizlikKarariClicked()
    {
        if (kararBelgesiSlide == null || isKararBelgesiAcik) return;

        // Paneli aktif hale getir
        kararBelgesiSlide.gameObject.SetActive(true);

        // Slide efekti ba�lat
        kararBelgesiSlide.SlideInStepByStep();

        isKararBelgesiAcik = true;
    }



    void OnSorusturmaBaslatClicked()
    {
        Debug.Log("Soru�turma Ba�lat butonuna t�kland�.");

        if (sorusturmaPanel != null)
            sorusturmaPanel.SetActive(true);

        if (kararBelgesiSlide != null)
            kararBelgesiSlide.gameObject.SetActive(false); // Karar belgesi paneli kapan�r
    }

}
