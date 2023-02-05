//Maded by Pedro M Marangon
using Economy;
using PedroUtils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
	public class ItemShopUI : MonoBehaviour
	{
		[Header("Item SO")]
		[SerializeField] private ItemSO item;

		[Header("Strings")]
		[SerializeField] private string adquired = "Adquired";
		[SerializeField] private string dontHaveEnoughMoney = "Not enough cash";

		[Header("Connections")]
		[SerializeField] private TMP_Text nameText;
		[SerializeField] private TMP_Text priceText;
		[SerializeField] private TMP_Text overlayText;
		[SerializeField] private Image itemImage;
		[SerializeField] private Image overlayImage;

		public void SetItem(ItemSO item) => this.item = item;

		public void UpdateUI()
		{
			if (item == null)
			{
				this.LogError("ItemSO is null");
				return;
			}

			nameText.text = item.Name;

			itemImage.sprite = item.Sprite;
			itemImage.color = Color.white;

			priceText.text = $"<sprite=1> {item.Price}";

			PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
			bool playerContainsItem = playerInventory.UnlockedItems.Contains(item);

			overlayImage.enabled = playerContainsItem;

			if (playerContainsItem) overlayText.text = adquired;
			else if (playerInventory.Money < item.Price) overlayText.text = dontHaveEnoughMoney;
			else overlayText.text = string.Empty;
		}
	}
}