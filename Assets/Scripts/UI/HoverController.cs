using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public GameObject hoverSprite;

    void Start()
    {
        if (hoverSprite != null)
            hoverSprite.SetActive(false); // Ba�ta g�r�nmesin
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse hover ba�lad�: " + gameObject.name);

        if (hoverSprite != null)
            hoverSprite.SetActive(true);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse hover bitti: " + gameObject.name);

        if (hoverSprite != null)
            hoverSprite.SetActive(false);
    }
}
