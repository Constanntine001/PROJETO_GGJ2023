// Maded by Pedro M Marangon
using TMPro;
using UnityEngine;

namespace Economy
{
	public class PlayerBalanceUI : MonoBehaviour
	{
		[SerializeField] private TMP_Text balanceText;

		private PlayerInventory playerBalance;

		private void Awake() => playerBalance = FindObjectOfType<PlayerInventory>();

		private void OnEnable() => playerBalance.OnMoneyChanged += UpdateMoney;
		private void OnDisable() => playerBalance.OnMoneyChanged -= UpdateMoney;

		private void UpdateMoney() => balanceText.text = $"$ {playerBalance.Money}";
	}
}