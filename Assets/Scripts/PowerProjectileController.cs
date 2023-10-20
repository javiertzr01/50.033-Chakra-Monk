using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerProjectileController : HitboxController
{
    Dictionary<AttackType, float> damageValues = new Dictionary<AttackType, float>
        {
            {AttackType.Punch, 50f},
            {AttackType.Kick, 100f},
            {AttackType.Power_projectile, 500f},
            {AttackType.Power_projectile_dark, 800f}
        };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6)
            {
                col.gameObject.GetComponent<DestructableController>().Hit();
            }

            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<EnemyController>().TakeDamage(damageValues[attackType]);
                Destroy(gameObject);
            }
    }
}
