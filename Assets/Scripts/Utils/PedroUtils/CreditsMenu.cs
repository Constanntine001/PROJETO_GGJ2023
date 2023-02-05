// Maded by Pedro M Marangon
using PedroUtils;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
	[SerializeField] private CanvasGroup creditCanvas;

	private void Awake() => HideCredits();

	public void ShowCredits() => creditCanvas.SetValues(1, true);

	public void HideCredits() => creditCanvas.SetValues(0, false);
}