using composition;
using System.Collections.Generic;
using UnityEngine;


public class PlayerItemManager : MonoBehaviour
{
    public List<ItemBase> currItems = new List<ItemBase>();
    [SerializeField] private Transform handPoint;
    private GameObject currWeapon;
    [SerializeField] private PlayerMechanics playerMech;

    private void Start()
    {
        playerMech = GetComponent<PlayerMechanics>();
    }

    private void Update()
    {
        
    }

    public void AddNewItem(ItemBase item)
    {
        currItems.Add(item);
        if(item.Type == ItemType.weapon)
        {
            currWeapon = Instantiate(item.itemMesh, handPoint);
            playerMech.currWeapon = item;
        }
    }
}
