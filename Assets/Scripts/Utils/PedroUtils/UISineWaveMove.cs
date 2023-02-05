// Maded by Pedro M Marangon
using UnityEngine;

public class UISineWaveMove : MonoBehaviour
{
	[SerializeField] float speed = 1.0f;
	[SerializeField] float height = 1.0f;
	private RectTransform rectTransform;
	private Vector2 ogPos;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		ogPos = rectTransform.anchoredPosition;
	}

	private void Update()
	{
		float yPos = ogPos.y + (height * Mathf.Sin(speed * Time.time));
		rectTransform.anchoredPosition = new Vector2(ogPos.x, yPos);
	}
}