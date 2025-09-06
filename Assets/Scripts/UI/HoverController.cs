using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public GameObject hoverSprite;

    void Start()
    {
        if (hoverSprite != null)
            hoverSprite.SetActive(false); // Baþta görünmesin
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse hover baþladý: " + gameObject.name);

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
