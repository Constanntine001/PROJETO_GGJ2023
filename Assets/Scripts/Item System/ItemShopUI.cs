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

		public void SetItem(ItemSO item) => this.item = item;

		public void BuyItem()
		{
			PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
			this.Log("TESTE");
			playerInventory.AddItem(item);
			playerInventory.SpendMoney(item.Price);
			UpdateUI();
		}

		public void UpdateUI()
		{
			if (item == null)
			{
				this.LogError("ItemSO is null");
				return;
			}

			nameText.text = item.Name;
			this.Log("!@#)%R@I#");

			itemImage.sprite = item.Sprite;
			itemImage.color = Color.white;

			priceText.text = $"<sprite=1> {item.Price}";

			PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
			bool playerContainsItem = playerInventory.UnlockedItems.Contains(item);
			bool canAffordItem = playerInventory.Money >= item.Price;



			this.Log($"Can Afford Item (having {playerInventory.Money} at {item.Price}): {canAffordItem}",
						$"Player contains item {item.Name}: {playerContainsItem}");


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