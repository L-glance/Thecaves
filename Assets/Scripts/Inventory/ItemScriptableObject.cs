using UnityEngine;

public enum ItemType
{
    Default,
    Tool,
    Weapon,
    Food,
    Construction,
}

public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string description;
    public ItemType itemType;
    public int maxAmountInStack;
    public int amount = 1;
    [SerializeField] private int _id;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Sprite _spriteIcon;
    public int id => _id;
    public GameObject prefab => _prefab;
    public Sprite spriteIcon => _spriteIcon;

}
