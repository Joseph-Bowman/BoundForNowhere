using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemBase", order = 1)]
public class ItemBase : ScriptableObject
{
    [Header("Item Data")]
    //Item data including the type, name, id, and mesh/sprite
    public ItemType Type;
    public string itemName;
    public int itemID;
    public GameObject itemMesh;
    public Sprite itemSprite;
}
