// SekmeKopru.cs (ikinci týklamayý engelle)
using UnityEngine;
using UnityEngine.UI;

public class SekmeKopru : MonoBehaviour
{
    [SerializeField] private TalimatListesiController listeController;
    [SerializeField] private Button button;
    private bool zatenAcik;

    void Awake()
    {
        if (button) button.onClick.AddListener(() =>
        {
            if (zatenAcik) return;
            if (listeController) listeController.Goster_KollukKuvvetleri();
            zatenAcik = true;
            // button.interactable = false; // istersen
        });
    }
}
