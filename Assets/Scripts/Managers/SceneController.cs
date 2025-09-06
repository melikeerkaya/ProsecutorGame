using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Bu fonksiyon sahne ge�i�i yapar ve Console'a bilgi yazar
    public void LoadSceneByName(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.Log("Sahne y�kleniyor: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Sahne bulunamad�: " + sceneName);
        }
    }

}
