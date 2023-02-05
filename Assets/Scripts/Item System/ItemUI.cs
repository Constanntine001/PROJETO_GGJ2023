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

			if(nameText != null) nameText.text = item.name;
			
			if (itemImage != null)
			{
				itemImage.sprite = item.Sprite;
				itemImage.color = Color.white;
			}
		}
	}
}