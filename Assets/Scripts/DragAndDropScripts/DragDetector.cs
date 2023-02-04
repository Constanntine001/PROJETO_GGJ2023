using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Items;

public class DragDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool mouseEmCima = false;
    bool arrastando = false;

    [SerializeField] ItemSO infoItem;

    GameObject dragCanvas;
    GameObject DragAndDropGhost;

    public void Start()
    {
        // Acha o canvas que será utilizado para arrastar o objeto sobre a UI
        dragCanvas = GameObject.Find("CANVAS_DRAG_DROP");
    }

    public void DragAndDropInformation(ItemSO input_infoItem)
    {
        infoItem = input_infoItem;
    }

    // Update is called once per frame
    void Update()
    {
        // Caso o mouse esteja em cima do item e o jogador clicar nele
        if(mouseEmCima && Input.GetMouseButtonDown(0))
        {
            if(dragCanvas.transform.childCount <= 0)
            {
                // Flag arrastando ativa
                arrastando = true;
                DragAndDropGhost = new GameObject("ItemDragDrop", typeof(RectTransform), typeof(Image));
                DragAndDropGhost.transform.SetParent(dragCanvas.transform);
                var imageComponent = DragAndDropGhost.GetComponent<Image>();
                imageComponent.sprite = infoItem.Sprite;
                imageComponent.color = new Color(1f, 1f, 1f, 0.4f);
            }

        }

        // Se estiver arrastando e o mouse estiver ainda clicado
        if(arrastando && Input.GetMouseButton(0))
        {
            DragAndDropGhost.transform.position = Input.mousePosition;
        }
        // SE ESTIVER ARRASTANDO MAS BTN NAO CLICADO
        else if(arrastando)
        {
            //ARRASTE ACABOU
            arrastando = false;
            Destroy(DragAndDropGhost);

            //... codigo de colliders talvez?
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Caso o mouse estiver em cima do item na ui
        mouseEmCima = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Caso o mouse não estiver em cima do item na ui
        mouseEmCima = false;
    }
}
