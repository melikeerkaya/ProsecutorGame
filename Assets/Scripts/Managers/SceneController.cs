using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Bu fonksiyon sahne geçiþi yapar ve Console'a bilgi yazar
    public void LoadSceneByName(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.Log("Sahne yükleniyor: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Sahne bulunamadý: " + sceneName);
        }
    }

}
