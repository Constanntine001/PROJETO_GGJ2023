// Maded by Pedro M Marangon
using Items;
using PedroUtils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Economy
{
	public class Shop : MonoBehaviour
	{
		[Header("Items")]
		[SerializeField] private List<ItemSO> itemsToBuy = new List<ItemSO>();
		[Header("Instantiating items")]
		[SerializeField] private ItemShopUI itemButtonPrefab;
		[SerializeField] private Transform parent;
		[Header("Canvas")]
		[SerializeField] private Canvas canvas;
		[SerializeField] private GraphicRaycaster raycaster;

		private void Awake()
		{
			parent.Clear();
			HideMenu();
		}

		[ContextMenu("Show Shop Menu")]
		public void ShowMenu()
		{
			parent.Clear();

			foreach (ItemSO item in itemsToBuy)
			{
				ItemShopUI instance = Instantiate(itemButtonPrefab, parent);
				instance.SetItem(item, this);
				instance.UpdateUI();
			}
			SetCanvasEnabled(true);
		}

		[ContextMenu("Hide Shop Menu")]
		public void HideMenu() => SetCanvasEnabled(false);


		private void SetCanvasEnabled(bool enabled)
		{
			canvas.enabled = enabled;
			raycaster.enabled = enabled;
		}

	}
}