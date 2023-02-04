//Maded by Pedro M Marangon
using PedroUtils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
	public class ItemUI : MonoBehaviour
	{
		[Header("Item SO")]
		[SerializeField] private ItemSO item;
		
		[Header("Connections")]
		[SerializeField] private TMP_Text nameText;
		[SerializeField] private Image itemImage;
		[SerializeField] private TMP_Text priceText;


		private void Start()
		{
			if (TryGetComponent(out DragDetector dragDetector))
			{
				dragDetector.DragAndDropInformation(item);
			}
		}

		public void SetItem(ItemSO item) => this.item = item;

		public void UpdateUI()
		{
			if(item == null)
			{
				this.LogError("ItemSO is null");
				return;
			}

			if(nameText != null) nameText.text = item.Name;
			
			if (itemImage != null)
			{
				itemImage.sprite = item.Sprite;
				itemImage.color = Color.white;
			}

			if(priceText != null) priceText.text = $"<sprite=1> {item.Price}";
		}
	}


	public class ItemShopUI : MonoBehaviour
	{
		[Header("Item SO")]
		[SerializeField] private ItemSO item;

		[Header("Connections")]
		[SerializeField] private TMP_Text nameText;
		[SerializeField] private Image itemImage;
		[SerializeField] private TMP_Text priceText;

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
		}
	}
}