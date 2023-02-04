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
    GameObject CanvasDropGhost;
    GameObject WorldDropGhost;
    GameObject Bonsai_Bowl;

    public void Start()
    {
        // Acha o canvas que será utilizado para arrastar o objeto sobre a UI
        dragCanvas = GameObject.Find("CANVAS_DRAG_DROP");
        Bonsai_Bowl = GameObject.Find("BONSAI_BOWL");
    }

    public void DragAndDropInformation(ItemSO input_infoItem)
    {
        infoItem = input_infoItem;
    }

    void CriarCanvasDropGhost()
    {
        CanvasDropGhost = new GameObject("ItemDragDrop", typeof(RectTransform), typeof(Image));
        CanvasDropGhost.transform.SetParent(dragCanvas.transform);
        var imageComponent = CanvasDropGhost.GetComponent<Image>();
        imageComponent.sprite = infoItem.Sprite;
        CanvasDropGhost.transform.localScale = CanvasDropGhost.transform.localScale * infoItem.Scale * infoItem.UIScale;
        imageComponent.color = new Color(1f, 0.4f, 0.4f, 0.7f);
    }

    void CriarWorldDropGhost()
    {
        WorldDropGhost = CreateSpriteRenderer("ItemDragDropGhost", typeof(SpriteRenderer)).gameObject;
        SetTransform(WorldDropGhost.transform);
    }

    void CriarItemBonsai()
    {
        var NovoItemBonsai = CreateSpriteRenderer("ItemDragDropBonsai", typeof(SpriteRenderer));
        SetTransform(NovoItemBonsai);
    }


	private Transform CreateSpriteRenderer(string name, params Type[] components)
	{
        Transform obj = new GameObject(name, components).transform;
        obj.localScale = Vector3.one;
		return obj;
	}

	private void SetTransform(Transform obj)
    {
		obj.localScale = new Vector3(1, 1, 1);
		var itemRenderer = obj.GetComponent<SpriteRenderer>();
		itemRenderer.sprite = infoItem.Sprite;
		obj.localScale *= infoItem.Scale;
		obj.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		obj.SetParent(Bonsai_Bowl.transform);
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
                CriarCanvasDropGhost();
               // CriarWorldDropGhost();
            }

        }

        // Se estiver arrastando e o mouse estiver ainda clicado
        if(arrastando && Input.GetMouseButton(0))
        {
            CanvasDropGhost.transform.position = Input.mousePosition;

        }
        // SE ESTIVER ARRASTANDO MAS BTN NAO CLICADO
        else if(arrastando)
        {
            //ARRASTE ACABOU
            arrastando = false;
            Destroy(CanvasDropGhost);

            CriarItemBonsai();

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
