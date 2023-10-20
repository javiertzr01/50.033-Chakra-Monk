using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private SpriteRenderer health;

    void Start()
    {
        health = gameObject.GetComponentsInChildren<SpriteRenderer>()[1];
        Debug.Log(health.gameObject.name);
    }
    public void UpdateHealthbar(float value)
    {
        health.gameObject.transform.localScale = new Vector3(value, 1, 1);
        if (value >= 0.7f)
        {
            health.color = Color.green;
        }
        else if (value >= 0.3f && value < 0.7f)
        {
            health.color = new Color(1f, 0.4f, 0f, 1f);
        }
        else{
            health.color = Color.red;
        }
    }
}
