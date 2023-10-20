using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarecrowController : EnemyController
{
    private float SCHealth = 500f;
    private float SCDamage = 0f;
    private bool refillHPStarted = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if (getHealth() <= 0.1f*SCHealth && !refillHPStarted)
        {
            StartCoroutine(RefillHP());
        }
    }

    private IEnumerator RefillHP()
    {
        refillHPStarted = true;
        for (int i = 0; i < (SCHealth - getHealth())/10; i++)
        {
            increaseHealth(10);
            yield return null;
        }
        if (getHealth() != 500)
        {
            increaseHealth(500 - getHealth());
        }

        refillHPStarted = false;
    }

    public override float SetupHealth()
    {
        return SCHealth;
    }

    public override float SetupDamage()
    {
        return SCDamage;
    }

    public override float SetupHealthYPos()
    {
        return GameObject.Find("Top").GetComponent<EdgeCollider2D>().points[0].y;
    }
}
