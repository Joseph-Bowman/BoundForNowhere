using composition;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerItemManager : MonoBehaviour
{
    [Header("Items")]
    public List<ItemBase> currItems = new List<ItemBase>();
    private GameObject currWeapon;

    [Header("Player Settings")]
    //Where the weapons are set to on the player
    [SerializeField] private Transform handPoint;
    [SerializeField] private PlayerMechanics playerMech;

    [Header("UI")]
    [SerializeField]private LevelUI levelUI;

    private void Start() { playerMech = GetComponent<PlayerMechanics>(); }
    
    public void AddNewItem(ItemBase item)
    {
        //adds an item then checks if the item is a weapon. //If so the weapon is added to the current weapon and the current weapon is set on the player mechanics
        currItems.Add(item);
        if(item.Type == ItemType.weapon)
        {
            currWeapon = Instantiate(item.itemMesh, handPoint);
            playerMech.currWeapon = item;
        }
        levelUI.SetUISpriteToItemSprite(item);
    }

}
