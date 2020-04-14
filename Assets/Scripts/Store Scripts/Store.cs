using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject storePanel;

    [SerializeField]
    public GameObject coinManager;

    public static Store instance;

    public List<Item> list = new List<Item>();
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
        foreach (Transform child in storePanel.transform)
        {
            StoreScriptController slot = child.GetComponent<StoreScriptController>();

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
