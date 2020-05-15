using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject storePanel;

    public static Store instance;

    public List<Item> storeList = new List<Item>();
    void Start()
    {
        
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePanelSlots();
    }

    void UpdatePanelSlots()
    {
        int index = 0;
        foreach (Transform child in storePanel.transform)
        {
            StoreScriptController slot = child.GetComponent<StoreScriptController>();

            if (index < storeList.Count && child.tag == "Store_Slot")
            {
                slot.item = storeList[index];
            }
            else
            {
                if (slot !=  null) slot.item = null;
            }


            if (slot != null) slot.updateInfo();
            index++;
        }
    }

    public void Add(Item item)
    {
        if (storeList.Count < 6)
        {
            storeList.Add(item);
        }
        UpdatePanelSlots();
    }
    public void Remove(Item item)
    {
        
        storeList.Remove(item);
        
        UpdatePanelSlots();
        
    }

}
