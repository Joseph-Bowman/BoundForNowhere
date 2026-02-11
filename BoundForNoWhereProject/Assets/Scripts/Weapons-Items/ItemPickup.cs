using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Item Data")] // Holds the data for the item to pick up, its mesh and rotation
    [SerializeField] private ItemBase item;
    [SerializeField] private Vector3 rotation;
    private GameObject itemMesh;

    private PlayerItemManager playerManager;

    //Creates the mesh for the item at the pickups location
    private void Start() { itemMesh = Instantiate(item.itemMesh, transform); }

    private void Update() { ItemRotate(); }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the player is on the item and if so adds an item to the player item manager set at the start then destroys the pickup
        if (other.CompareTag("Player"))
        {
            playerManager = other.GetComponentInParent<PlayerItemManager>();
            playerManager.AddNewItem(item);
            Destroy(this.gameObject);
        }
    }

    //Rotates the item based on the rotation vector
    void ItemRotate() { itemMesh.transform.Rotate(rotation * Time.deltaTime); }
    
}