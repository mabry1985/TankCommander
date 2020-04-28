using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour    
{
    public GameObject player;
    public GameObject inventoryPanel;

    public static Inventory instance;
    
    public List<Item> inventoryList = new List<Item>();



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdatePanelSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePanelSlots()
    {
        int index = 0;
        foreach(Transform child in inventoryPanel.transform)
        {
            inventoryScriptController slot = child.GetComponent<inventoryScriptController>();

            if (index < inventoryList.Count)
            {
                slot.item = inventoryList[index];
            }
            else
            {
                slot.item = null;
            }


            slot.updateInfo();
            index++;
        }
    }

    public void Add(Item item)
    {
        if (inventoryList.Count < 3)
        {
            inventoryList.Add(item);
        }
        UpdatePanelSlots();
    }

    public void Remove(Item item)
    {
        inventoryList.Remove(item);
        UpdatePanelSlots();
    }


}
