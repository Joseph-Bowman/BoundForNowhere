using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemBase", order = 1)]
public class ItemBase : ScriptableObject
{
    public ItemType Type;
    public string itemName;
    public int itemID;
    public GameObject itemMesh;
}
