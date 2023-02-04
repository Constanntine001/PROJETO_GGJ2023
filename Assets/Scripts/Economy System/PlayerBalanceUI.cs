// Maded by Pedro M Marangon
using TMPro;
using UnityEngine;

namespace Economy
{
	public class PlayerBalanceUI : MonoBehaviour
	{
		[SerializeField] private TMP_Text balanceText;

		private PlayerBalance playerBalance;

		private void Awake() => playerBalance = FindObjectOfType<PlayerBalance>();

		private void OnEnable() => playerBalance.OnMoneyChanged += UpdateMoney;
		private void OnDisable() => playerBalance.OnMoneyChanged -= UpdateMoney;

		private void UpdateMoney() => balanceText.text = $"<sprite=1>$ {playerBalance.Money}";
	}
}