using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour    
{
    public GameObject player;
    public GameObject inventoryPanel;

    public static Inventory instance;
    
    public List<Item> list = new List<Item>();



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

            if (index < list.Count)
            {
                slot.item = list[index];
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
        if (list.Count < 6)
        {
            list.Add(item);
        }
        UpdatePanelSlots();
    }

    public void Remove(Item item)
    {
        list.Remove(item);
        UpdatePanelSlots();
    }


}
