
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotItemImage;

    // Start is called before the first frame update
    void Start()
    {
        slotItemImage.color = new Color32(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableIcon()
    {

    }

    public void ItemCollected()
    {
        slotItemImage.color = new Color32(255, 255, 225, 255);
    }
}
