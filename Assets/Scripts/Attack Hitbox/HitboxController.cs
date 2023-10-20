using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Punch,
    Kick,
    Power_projectile,
    Power_projectile_dark
}

public class HitboxController : MonoBehaviour
{
    public AttackType attackType;
    public BoolVariable facingRight;
    public Vector2 originalOffset;
    
    Dictionary<AttackType, float> damageValues = new Dictionary<AttackType, float>
        {
            {AttackType.Punch, 50f},
            {AttackType.Kick, 100f},
            {AttackType.Power_projectile, 500f},
            {AttackType.Power_projectile_dark, 800f}
        };

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.GetComponentInParent<Movement>().attack)
        {
            if (col.gameObject.layer == 6)
            {
                col.gameObject.GetComponent<DestructableController>().Hit();
            }

            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<EnemyController>().TakeDamage(damageValues[attackType]);
            }
        }
    }

}
