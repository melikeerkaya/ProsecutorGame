using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject panelToOpen;
    private PanelController panelController;

    private void Start()
    {
        if (panelToOpen == null)
        {
            Debug.LogWarning($"[Interaction] '{gameObject.name}' objesine panelToOpen atanmamış!");
            return;
        }

        panelController = panelToOpen.GetComponent<PanelController>();

        if (panelController == null)
        {
            Debug.LogWarning($"[Interaction] '{panelToOpen.name}' panelinde PanelController eksik!");
        }
    }

    private void OnMouseDown()
    {
        // 🔒 Eğer açık bir panel varsa ve bu panel bizim panel değilse, hiçbir şey yapma
        if (PanelManager.activePanel != null && PanelManager.activePanel != panelToOpen)
        {
            Debug.Log("Zaten açık bir panel var, yeni panel açılamaz.");
            return;
        }

        // Normal panel açma işlemi
        if (panelToOpen == null || panelController == null) return;

        PanelManager.OpenPanel(panelToOpen);
        panelController.Open();
    }
}
