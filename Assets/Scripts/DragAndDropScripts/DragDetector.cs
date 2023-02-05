using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Items;

public class DragDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Controles do drag
    bool mouseEmCima = false;
    bool arrastando = false;

    //Máximo de itens por bonsai
    int maxBonsaiItems = 5;

    //GameObjects que já são criados logo no ínicio
    GameManager gm;
    GameObject dragCanvas;
    GameObject Bonsai_Bowl;

    AudioSource putInBonsai;
    AudioSource itemPickup;

    //Itens instanciados
    [SerializeField] ItemSO infoItem;
    GameObject CanvasDropGhost;
    GameObject WorldDropGhost;
    // Para criar o collider automatico
    float colliderDiff = 0f;

    public void Start()
    {
        var gameManagerGO = GameObject.Find("GameManager");
        var putInBonsaiGO = GameObject.Find("putInBonsai");
        var itemPickupGO = GameObject.Find("itemPickup");

        if(gameManagerGO != null)
		{
			gm = gameManagerGO.GetComponent<GameManager>();
		    dragCanvas = gm.CANVAS_DRAG_DROP;
            Bonsai_Bowl = gm.ACTIVE_BONSAI;
		}

        if(putInBonsaiGO != null) putInBonsai = putInBonsaiGO.GetComponent<AudioSource>();
        if(itemPickupGO != null) itemPickup = itemPickupGO.GetComponent<AudioSource>();
    }

    public void DragAndDropInformation(ItemSO input_infoItem)
    {
        infoItem = input_infoItem;
        colliderDiff = 1f - (1f - infoItem.UIScale);
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
        WorldDropGhost = CreateSpriteRenderer("ItemDragDropGhost", typeof(SpriteRenderer), typeof(BoxCollider2D)).gameObject;
        var boxCollider = WorldDropGhost.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(colliderDiff,colliderDiff);
        boxCollider.isTrigger = true;
        WorldDropGhost.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        SetTransform(WorldDropGhost.transform, false);
    }

    void CriarItemBonsai()
    {
        var NovoItemBonsai = CreateSpriteRenderer("ItemDragDropBonsai", typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Rigidbody2D));

        NovoItemBonsai.gameObject.layer = LayerMask.NameToLayer("Item");

        var boxCollider = NovoItemBonsai.GetComponent<BoxCollider2D>();
        var rigidbody = NovoItemBonsai.GetComponent<Rigidbody2D>();

        boxCollider.size = new Vector2(colliderDiff, colliderDiff);
        boxCollider.isTrigger = false;
        rigidbody.gravityScale = 0;
        rigidbody.constraints =  RigidbodyConstraints2D.FreezeRotation;
        SetTransform(NovoItemBonsai);
    }


	private Transform CreateSpriteRenderer(string name, params Type[] components)
	{
        Transform obj = new GameObject(name, components).transform;
        obj.localScale = Vector3.one;
		return obj;
	}

	private void SetTransform(Transform obj, bool parent = true)
    {
		obj.localScale = new Vector3(1, 1, 1);
		var itemRenderer = obj.GetComponent<SpriteRenderer>();
		itemRenderer.sprite = infoItem.Sprite;
		obj.localScale *= infoItem.Scale;
		obj.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(parent)
        {
            Bonsai_Bowl = gm.ACTIVE_BONSAI;
            obj.SetParent(Bonsai_Bowl.transform);
        }
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

                //Audio
                itemPickup.Play();
                
                CriarCanvasDropGhost();
                CriarWorldDropGhost();
            }
        }

        // Se estiver arrastando e o mouse estiver ainda clicado
        if(arrastando && Input.GetMouseButton(0))
        {
            CanvasDropGhost.transform.position = Input.mousePosition;
            WorldDropGhost.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(CheckBonsaiCollisions())
            {
                var imageComponent = CanvasDropGhost.GetComponent<Image>();
                imageComponent.color = new Color(1f, 1f, 1f, 0.7f);
            }
            else
            {
                var imageComponent = CanvasDropGhost.GetComponent<Image>();
                imageComponent.color = new Color(1f, 0.4f, 0.4f, 0.7f);
            }
        }
        // SE ESTIVER ARRASTANDO MAS BTN NAO CLICADO
        else if(arrastando)
        {
            //ARRASTE ACABOU
            arrastando = false;

            if(CheckBonsaiCollisions())
            {
                CriarItemBonsai();
                putInBonsai.Play();
            }
            
            Destroy(CanvasDropGhost);
            Destroy(WorldDropGhost);
        }
    }

    bool CheckBonsaiCollisions()
    {
        Bonsai_Bowl = gm.ACTIVE_BONSAI;

        var dropGhostCollider = WorldDropGhost.GetComponent<Collider2D>();
        if(dropGhostCollider.IsTouching(Bonsai_Bowl.GetComponent<Collider2D>()))
        {
            int bonsaiChildCount = Bonsai_Bowl.transform.childCount;
            if(bonsaiChildCount < (Bonsai_Bowl.GetComponent<MaxBonsaiItems>().MaxItems))
            {
                return true;
            }
        }

        return false;
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
