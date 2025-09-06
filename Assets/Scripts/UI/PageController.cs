using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public GameObject[] pages; // Sayfalar burada sýralý olacak: Sayfa1, Sayfa2, KararSayfasi
    public Button oncekiButton;
    public Button sonrakiButton;

    private int currentPageIndex = 0;

    void Start()
    {
        UpdatePage();

        oncekiButton.onClick.AddListener(PreviousPage);
        sonrakiButton.onClick.AddListener(NextPage);
    }

    void UpdatePage()
    {
        for (int i = 0; i < pages.Length; i++)
            pages[i].SetActive(i == currentPageIndex);

        // Butonlarý devre dýþý býrak
        oncekiButton.interactable = currentPageIndex > 0;
        sonrakiButton.interactable = currentPageIndex < pages.Length - 1;
    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Length - 1)
        {
            currentPageIndex++;
            UpdatePage();
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePage();
        }
    }
}
