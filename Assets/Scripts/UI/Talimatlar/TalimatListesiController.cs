// TalimatListesiController.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // LayoutRebuilder için
using UnityEngine.EventSystems;

public class TalimatListesiController : MonoBehaviour
{
    [SerializeField] private GameObject talimatSatiriPrefab;   // ← TalimatSatiri_NEW.prefab
    [SerializeField] private Transform contentParent;           // ← Talimatları koyacağın dikey container (ScrollView yoksa düz RT)

    public void Temizle()
    {
        var children = new List<Transform>();
        foreach (Transform c in contentParent) children.Add(c);
        foreach (var c in children) Destroy(c.gameObject);
    }

    private void ListeyiDoldur(List<string> talimatlar)
    {
        Temizle();

        foreach (var t in talimatlar)
        {
            var go = Instantiate(talimatSatiriPrefab, contentParent);
            var ui = go.GetComponent<TalimatSatiriUI>();
            if (ui) ui.Ayarla(t);
        }

        // layout’ı hemen güncelle
        var rt = contentParent as RectTransform;
        if (rt) LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
    }

    public void Goster_KollukKuvvetleri()
    {
        ListeyiDoldur(new List<string>{
            "Olay yerinde araştırma yap",
            "Kamera görüntülerini topla",
            "Görgü tanıklarını tespit et",
            "Şüpheli hakkında genel bilgi topla",
            "Ev ve çevre araması yap"
        });
    }
}
