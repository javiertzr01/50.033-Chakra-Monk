using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyController : MonoBehaviour
{
    public GameObject healthbarPrefab;

    private float totalHealth;
    private float health;
    private float damage;
    private float healthYPos;

    private bool interacted;
    public bool alive;
    public Animator animator;
   
    private bool healthbarActive;
    private GameObject healthbar;

    public UnityEvent<float> playerTakesDamage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        alive = true;
        healthbarActive = false;
        interacted = false;
        health = SetupHealth();
        totalHealth = health;
        damage = SetupDamage();
        healthYPos = SetupHealthYPos();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (alive)
        {
            if (!healthbarActive && interacted)
            {
                InstantiateHealthbar();
            }
            if (healthbarActive)
            {
                healthbar.GetComponent<EnemyHealthBar>().UpdateHealthbar(health/totalHealth);
            }
        }
    }

    public void TakeDamage(float value)
    {
        if (alive)
        {
            interacted = true;
            health -= value;
            animator.SetTrigger("hit");
            if (health <= 0)
            {
                health = 0;
                alive = false;
            }
        }
    }

    private void InstantiateHealthbar()
    {
        GameObject gameObject = Instantiate(healthbarPrefab, transform);
        gameObject.transform.localPosition = new Vector3 (0, healthYPos + 0.01f, 0);
        healthbar = gameObject;
        healthbarActive = true;
    }

    public float getHealth()
    {
        return health;
    }

    public void increaseHealth(float value)
    {
        health += value;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 7)
        {
            playerTakesDamage.Invoke(damage);
        }
    }

    public abstract float SetupDamage();
    public abstract float SetupHealth();
    public abstract float SetupHealthYPos();
}
