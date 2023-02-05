//Maded by Pedro M Marangon
using Economy;
using PedroUtils;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
	public class AvailableItemsHolder : MonoBehaviour
	{
		[SerializeField] private ItemUI prefab;
		[SerializeField] private Transform parent;

		private void Start() => RebuildUI(FindObjectOfType<PlayerInventory>().UnlockedItems);


		public void RebuildUI(List<ItemSO> items)
		{
			parent.Clear();

			foreach (ItemSO item in items)
			{
				ItemUI instance = Instantiate(prefab, parent);
				instance.SetItem(item);
				instance.UpdateUI();
			}
		}

	}
}