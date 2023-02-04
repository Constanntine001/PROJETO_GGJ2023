using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool mouseEmCima = false;
    bool arrastando = false;

    [SerializeField] GameObject pqp; // Objeto teste

    // Update is called once per frame
    void Update()
    {
        // Caso o mouse esteja em cima do item e o jogador clicar nele
        if(mouseEmCima && Input.GetMouseButtonDown(0))
        {
            // Flag arrastando ativa
            arrastando = true;
        }

        // Se estiver arrastando e o mouse estiver ainda clicado
        if(arrastando && Input.GetMouseButton(0))
        {
            // CÓDIGO DE ARRASTE DE ITEM AQUI

                var posicaoMouse = Input.mousePosition;
                pqp.transform.position = Camera.main.ScreenToWorldPoint(posicaoMouse);

            // -------------------------------

        }
        // SE ESTIVER ARRASTANDO MAS BTN NAO CLICADO
        else if(arrastando)
        {
            //ARRASTE ACABOU
            arrastando = false;
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
