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
		[SerializeField] private Button itemButton;
		[SerializeField] private Image itemImage;
		[SerializeField] private Image overlayImage;
		private Shop shop;

		public void SetItem(ItemSO item, Shop shop)
		{
			this.item = item;
			this.shop = shop;
		}

		public void BuyItem()
		{
			PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
			playerInventory.AddItem(item);
			playerInventory.SpendMoney(item.Price);
			shop.ShowMenu();
		}

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

			priceText.text = $"$ {item.Price}";

			PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
			bool playerContainsItem = playerInventory.UnlockedItems.Contains(item);
			bool canAffordItem = playerInventory.Money >= item.Price;

			overlayText.enabled = overlayImage.enabled = playerContainsItem;

			itemButton.interactable = !playerContainsItem && canAffordItem;

			itemButton.GetComponent<Image>().color = Color.white;

			if(playerContainsItem)
			{
				overlayText.text = adquired;
				itemButton.GetComponent<Image>().color = Color.clear;
			}
			else if (!canAffordItem) overlayText.text = dontHaveEnoughMoney;
			else overlayText.text = string.Empty;
		}
	}
}