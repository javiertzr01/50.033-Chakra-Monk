using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootController : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 2.5f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerPickup();
            Destroy(this.gameObject);
        }
    }

    public abstract void PlayerPickup();
}
