using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChakraController : LootController
{
    public UnityEvent gainChakra;
    public override void PlayerPickup()
    {
        // Give player chakra
        gainChakra.Invoke();
    }
}
