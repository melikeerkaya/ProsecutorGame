using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // Şu anda açık olan paneli takip eder
    public static GameObject activePanel;

    // Paneli açar
    public static void OpenPanel(GameObject panelToOpen)
    {
        if (panelToOpen == null) return;

        // Eğer başka bir panel açıksa ve o panel farklıysa, açma
        if (activePanel != null && activePanel != panelToOpen)
        {
            Debug.Log("Başka bir panel zaten açık, yeni panel açılamaz.");
            return;
        }

        panelToOpen.SetActive(true);

        var controller = panelToOpen.GetComponent<PanelController>();
        if (controller != null)
            controller.Open();

        activePanel = panelToOpen;
    }

    // Paneli kapatır
    public static void ClosePanel(GameObject panelToClose)
    {
        if (panelToClose == null) return;

        var controller = panelToClose.GetComponent<PanelController>();
        if (controller != null)
            controller.Close(); // animasyonlu kapanış
        else
            panelToClose.SetActive(false); // animasyonsuz direkt kapat

        // Eğer kapatılan panel aktif panelse, sıfırla
        if (panelToClose == activePanel)
            activePanel = null;
    }
}
