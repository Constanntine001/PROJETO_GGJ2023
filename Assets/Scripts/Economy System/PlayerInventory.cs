// Maded by Pedro M Marangon
using Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Economy
{
	public class PlayerInventory : MonoBehaviour
	{
		[SerializeField] private int money;
		[field: SerializeField] public List<ItemSO> UnlockedItems { get; private set; } = new List<ItemSO>();
		private AvailableItemsHolder availableItemsHolder;

		public event Action OnMoneyChanged;

		public int Money
		{
			get => money;
			set
			{
				money = value;
				OnMoneyChanged?.Invoke();
			}
		}

		public void AddMoney(int amount) => Money += amount;
		public void SpendMoney(int amount) => Money -= amount;

		public void AddItem(ItemSO item)
		{
			UnlockedItems.Add(item);
			availableItemsHolder.RebuildUI(UnlockedItems);
		}

		[ContextMenu("Add 100 money")]
		private void Add100Money() => AddMoney(100);

	}
}