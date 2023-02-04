//Maded by Pedro M Marangon
using UnityEngine;

namespace Items
{
	[CreateAssetMenu(menuName = "Game/ItemSO")]
	public class ItemSO : ScriptableObject
	{
		[field: SerializeField] public string Name { get; private set; } = "Item SO";
		[field: SerializeField] public Sprite Sprite { get; private set; }
		[field: SerializeField] public ItemSO Dependencies { get; private set; }
		[field: SerializeField] public int Price { get; private set; } = 5;
		[field: SerializeField] public float Scale { get; private set; } = 1f;
	}
}