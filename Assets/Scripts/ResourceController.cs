using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceController : MonoBehaviour
{
    public float chakra = 3000f;
    public float heart = 0f;
    public float projectileSpeed = 6f;
    public GameObject PowerProjectile;
    public GameObject PowerProjectileDark;
    public BoolVariable facingRight;

    public UnityEvent<float> UpdateChakraUI;
    public UnityEvent<float> UpdateHeartUI;
    // Start is called before the first frame update
    void Start()
    {
        UpdateChakraUI.Invoke(chakra);
        UpdateHeartUI.Invoke(heart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float value)
    {
        chakra -= value;
        UpdateChakraUI.Invoke(chakra);
    }

    public void gainChakra()
    {
        chakra += 250;
        UpdateChakraUI.Invoke(chakra);
    }

    public void useChakra(float value)
    {
        chakra -= value;
        UpdateChakraUI.Invoke(chakra);
    }

    public void gainHeart()
    {
        heart += 1;
        UpdateHeartUI.Invoke(heart);
    }

    public void useHeart(float value)
    {
        heart -= value;
        UpdateHeartUI.Invoke(heart);
    }

    public void power_projectile()
    {
        // Costs Chakra
        if (chakra > 100)
        {
            useChakra(100);
            GameObject power_projectile = Instantiate(PowerProjectile, transform.position, Quaternion.identity);
            Rigidbody2D power_projectileRB = power_projectile.GetComponent<Rigidbody2D>();
            if (power_projectileRB != null)
            {
                Vector2 velocity = new Vector2((facingRight.value == true ? 1 : -1) * projectileSpeed, 0);
                power_projectileRB.velocity = velocity;
            }
        }
    }
    public void power_projectile_dark()
    {
        // Costs chakra and 1 heart
        if (chakra > 200 && heart > 0)
        {   
            useChakra(100);
            useHeart(1);
            GameObject power_projectile_dark = Instantiate(PowerProjectileDark, transform.position, Quaternion.identity);
            Rigidbody2D power_projectile_darkRB = power_projectile_dark.GetComponent<Rigidbody2D>();
            if (power_projectile_darkRB != null)
            {
                Vector2 velocity = new Vector2((facingRight.value == true ? 1 : -1) * projectileSpeed, 0);
                power_projectile_darkRB.velocity = velocity;
            }
        }
    }

    public void GameRestart()
    {
        chakra = 3000;
        heart = 0;
        UpdateChakraUI.Invoke(chakra);
        UpdateHeartUI.Invoke(heart);
    }
}
