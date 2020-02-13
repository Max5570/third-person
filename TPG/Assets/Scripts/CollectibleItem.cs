using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    
    void OnTriggerEnter (Collider collider)
    {
        Managers.Inventory.AddItem(itemName);
        Destroy(this.gameObject);
    }
}
