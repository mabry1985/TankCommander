using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "new Consumables", menuName = "Items/Consumables")]
public class Consumables : Item
{
    
    public float heal = 0f;

    public override void Use()
    {
        GameObject player = Inventory.instance.player;
        TankHealth tankHealth = player.GetComponent<TankHealth>();

        tankHealth.Heal(heal);
        Inventory.instance.Remove(this);
    }


}
