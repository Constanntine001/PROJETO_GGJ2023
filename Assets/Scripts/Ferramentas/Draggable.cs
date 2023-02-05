using UnityEngine;

public class Draggable : MonoBehaviour
{

	private static readonly Quaternion DEFAULT_ROT = Quaternion.Euler(0, 0, 180);
	private static readonly Quaternion HOLDING_ROT = Quaternion.Euler(0, 0, -90);

	private Camera myCam;
    
    private float startXPos;
    private float startYPos;

    private bool isDragging = false;

	private Vector3 ogPos;

	private void Start()
    {
        myCam = Camera.main;
        ogPos = transform.position;
    }

	private void Update()
	{
		if (!isDragging) return;
		DragObject();
	}

	private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic) mousePos.z = 10;

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;

        transform.rotation = HOLDING_ROT;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        transform.SetPositionAndRotation(ogPos, DEFAULT_ROT);
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if(!myCam.orthographic)  mousePos.z = 10;

        mousePos = myCam.ScreenToWorldPoint(mousePos);
        Vector2 pos = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos);
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 5);
    }
}