using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "new Consumables", menuName = "Items/Consumables")]
public class Consumables : Item
{
    
    [SerializeField]
    private float heal = 0f;

    [SerializeField]
    public int _cost;



    public override void Use()
    {
        GameObject player = Inventory.instance.player;
        TankHealth tankHealth = player.GetComponent<TankHealth>();

        tankHealth.Heal(heal);
        Inventory.instance.Remove(this);
    }

    public override void Buy()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("Game Manager is NULL");
        }
        gameManager.RemoveCoin(_cost);
        Inventory.instance.Add(this);
        Store.instance.Remove(this);
        


    }

}
