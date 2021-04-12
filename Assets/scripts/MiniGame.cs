using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;
    public Text debug;

    // Start is called before the first frame update
    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject objectHit = hit.transform.gameObject;
                    debug.text = "Object tag : "+ objectHit.tag;
                    if (objectHit.tag == "Collectable")
                    {
                        slots[objectHit.GetComponent<ItemPickup>().inventoryPosition].ItemCollected();
                        objectHit.GetComponent<Item>().Enable(false);
                    }
                }
            }
        }

    }
}
