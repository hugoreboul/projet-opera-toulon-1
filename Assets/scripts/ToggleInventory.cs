using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInventory : MonoBehaviour
{

    public bool enable = false;
    public RectTransform inventoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(showInventory);
        inventoryPanel.gameObject.SetActive(enable);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void showInventory()
    {
        enable = !enable;
        inventoryPanel.gameObject.SetActive(enable);
    }
}
