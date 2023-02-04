//Maded by Pedro M Marangon
using PedroUtils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items
{
	public class AvailableItemsHolder : MonoBehaviour
	{
		[SerializeField] private ItemUI prefab;
		[SerializeField] private Transform parent;

		[SerializeField] private List<ItemSO> items;


		private void Start()
		{
			RebuildUI(items);
		}

		private void Clear()
		{
			for (int i = parent.transform.childCount - 1; i >= 0; i--)
			{
				parent.transform.GetChild(i).Suicide();
			}
		}

		[ContextMenu("Test Item List")]
		private void TestItemList()
		{
			if (!Application.isPlaying) return;
			RebuildUI(items);
		}

		public void RebuildUI(List<ItemSO> items)
		{
			Clear();

			foreach (ItemSO item in items)
			{
				ItemUI instance = Instantiate(prefab, parent);
				instance.SetItem(item);
				instance.UpdateUI();
			}
		}

	}
}