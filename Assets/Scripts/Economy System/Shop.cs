// Maded by Pedro M Marangon
using Items;
using PedroUtils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace Economy
{
	public class Shop : MonoBehaviour
	{
		[SerializeField] private List<ItemSO> itemsToBuy = new List<ItemSO>();
		[SerializeField] private Button itemButtonPrefab;
		[SerializeField] private Transform parent;
		private PlayerInventory playerInventory;

		private void Awake()
		{
			playerInventory = FindObjectOfType<PlayerInventory>();
		}

		private void Clear()
		{
			for (int i = parent.transform.childCount - 1; i >= 0; i--)
			{
				parent.transform.GetChild(i).Suicide();
			}
		}

		[ContextMenu("Test Item List")]
		public void ShowMenu()
		{
			Clear();

			foreach (ItemSO item in itemsToBuy)
			{
				Button instance = Instantiate(itemButtonPrefab, parent);
				instance.interactable = playerInventory.UnlockedItems.Contains(item);
			}
		}

	}
}