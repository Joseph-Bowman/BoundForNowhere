using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemBase item;
    private PlayerItemManager player;
    private GameObject itemMesh;
    [SerializeField] private Vector3 rotation;

    private void Start()
    {
        itemMesh = Instantiate(item.itemMesh, transform);
    }

    private void Update()
    {
        ItemRotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponentInParent<PlayerItemManager>();
            player.AddNewItem(item);
            Destroy(this.gameObject);
        }
    }

    void ItemRotate()
    {
        itemMesh.transform.Rotate(rotation * Time.deltaTime);
    }
}
