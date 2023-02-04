// Maded by Pedro M Marangon
using System;
using UnityEngine;

namespace Economy
{
	public class PlayerBalance : MonoBehaviour
	{
		[SerializeField] private int money;

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
	}
}