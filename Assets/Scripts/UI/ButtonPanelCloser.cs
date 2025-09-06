using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelCloser : MonoBehaviour
{
    public GameObject panelToClose;

    void Start()
    {
        var button = GetComponent<Button>();
        if (button != null && panelToClose != null)
        {
            button.onClick.AddListener(() => PanelManager.ClosePanel(panelToClose));
        }
    }
}
