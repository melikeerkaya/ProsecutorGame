using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIRaycastDebugger : MonoBehaviour
{
    public Canvas canvas;                 // SoruþturmaPanel’in olduðu Canvas
    private GraphicRaycaster gr;
    private PointerEventData ped;
    private EventSystem es;

    void Awake()
    {
        if (canvas == null) canvas = FindObjectOfType<Canvas>();
        gr = canvas.GetComponent<GraphicRaycaster>();
        es = FindObjectOfType<EventSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gr == null || es == null) return;

            ped = new PointerEventData(es) { position = Input.mousePosition };
            var results = new List<RaycastResult>();
            gr.Raycast(ped, results);

            Debug.Log("---- UI Raycast Stack (top to bottom) ----");
            foreach (var r in results)
                Debug.Log(r.gameObject.name + "  (raycastTarget=" +
                          (r.gameObject.TryGetComponent(out MaskableGraphic g) ? g.raycastTarget : false) + ")");
        }
    }
}
