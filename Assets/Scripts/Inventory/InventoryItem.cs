using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemScriptableObject itemScriptableObject;
    public int maxItemsInInventorySlot => itemScriptableObject.maxAmountInStack;
    public int id => itemScriptableObject.id;

    public int amount;
    public InventoryItem Clone()
    {
        var clone = new InventoryItem();
        clone.itemScriptableObject = itemScriptableObject;
        clone.amount = amount;
        return clone;
    }
    public override bool Equals(object other)
    {
        if (other is not InventoryItem item) return false;
        return this.id.Equals(item.id);
    }
}
