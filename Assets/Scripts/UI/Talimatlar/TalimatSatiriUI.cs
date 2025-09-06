// TalimatSatiriUI.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalimatSatiriUI : MonoBehaviour
{
    [Header("UI Referanslar� (opsiyonel, otomatik bulunur)")]
    [SerializeField] private TextMeshProUGUI talimatTextTMP; // varsa TMP
    [SerializeField] private Text talimatTextUGUI;            // klasik Text kulland�ysan
    [SerializeField] private Toggle toggle;                   // opsiyonel

    void Awake()
    {
        // Otomatik ba�lama (prefab i�inde unuttuysan)
        if (toggle == null) toggle = GetComponentInChildren<Toggle>(true);

        // E�er toggle varsa, �nce Toggle/Label (TMP veya Text) arayal�m
        if (toggle != null)
        {
            if (talimatTextTMP == null) talimatTextTMP = toggle.GetComponentInChildren<TextMeshProUGUI>(true);
            if (talimatTextUGUI == null) talimatTextUGUI = toggle.GetComponentInChildren<Text>(true);
        }

        // Yine de bulamad�ysak k�kte ara
        if (talimatTextTMP == null) talimatTextTMP = GetComponentInChildren<TextMeshProUGUI>(true);
        if (talimatTextUGUI == null) talimatTextUGUI = GetComponentInChildren<Text>(true);
    }

    public void Ayarla(string talimat)
    {
        if (talimatTextTMP != null)
        {
            talimatTextTMP.text = talimat ?? "-";
            talimatTextTMP.color = new Color(0f, 0f, 0f, 1f); // g�r�n�r olsun
        }
        if (talimatTextUGUI != null)
        {
            talimatTextUGUI.text = talimat ?? "-";
            talimatTextUGUI.color = Color.black; // g�r�n�r olsun
        }

        if (toggle != null)
        {
            toggle.onValueChanged.RemoveAllListeners();
            toggle.isOn = false; // ba�lang��
        }
    }
}
