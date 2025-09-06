// TalimatSatiriUI.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalimatSatiriUI : MonoBehaviour
{
    [Header("UI Referanslarý (opsiyonel, otomatik bulunur)")]
    [SerializeField] private TextMeshProUGUI talimatTextTMP; // varsa TMP
    [SerializeField] private Text talimatTextUGUI;            // klasik Text kullandýysan
    [SerializeField] private Toggle toggle;                   // opsiyonel

    void Awake()
    {
        // Otomatik baðlama (prefab içinde unuttuysan)
        if (toggle == null) toggle = GetComponentInChildren<Toggle>(true);

        // Eðer toggle varsa, önce Toggle/Label (TMP veya Text) arayalým
        if (toggle != null)
        {
            if (talimatTextTMP == null) talimatTextTMP = toggle.GetComponentInChildren<TextMeshProUGUI>(true);
            if (talimatTextUGUI == null) talimatTextUGUI = toggle.GetComponentInChildren<Text>(true);
        }

        // Yine de bulamadýysak kökte ara
        if (talimatTextTMP == null) talimatTextTMP = GetComponentInChildren<TextMeshProUGUI>(true);
        if (talimatTextUGUI == null) talimatTextUGUI = GetComponentInChildren<Text>(true);
    }

    public void Ayarla(string talimat)
    {
        if (talimatTextTMP != null)
        {
            talimatTextTMP.text = talimat ?? "-";
            talimatTextTMP.color = new Color(0f, 0f, 0f, 1f); // görünür olsun
        }
        if (talimatTextUGUI != null)
        {
            talimatTextUGUI.text = talimat ?? "-";
            talimatTextUGUI.color = Color.black; // görünür olsun
        }

        if (toggle != null)
        {
            toggle.onValueChanged.RemoveAllListeners();
            toggle.isOn = false; // baþlangýç
        }
    }
}
