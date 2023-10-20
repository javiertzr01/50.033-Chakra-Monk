using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeartController : LootController
{
    public UnityEvent gainHeart;
    public override void PlayerPickup()
    {
        // Give player chakra
        gainHeart.Invoke();
    }
}
