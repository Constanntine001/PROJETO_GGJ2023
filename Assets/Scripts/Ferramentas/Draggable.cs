using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Camera myCam;
    
    private float startXPos;
    private float startYPos;

    private bool isDragging = false;

    private void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
    }

    private void OnMouseDown()
    {

        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if(!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);
        Vector3 pos = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos, transform.localPosition.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 5);
    }
}