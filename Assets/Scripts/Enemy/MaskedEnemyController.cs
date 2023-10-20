using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedEnemyController : EnemyController
{
    // Start is called before the first frame update
    private float MEHealth = 100f;
    private float MEDamage = 100f;

    // Raycast Stuff
    public Vector2 boxSize;
    RaycastHit2D hitPlayer;

    // Position
    private Vector3 startPosition;
    private bool facingRight = true;
    private float maxOffset = 2.0f;

    // Components
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject CactusSpike;

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (!alive)
        {
            // Play death animation
            animator.SetBool("die", true);
        }
        else
        {
            if (PlayerCheck())
            {
                rb.MovePosition(rb.position + (hitPlayer.point - rb.position) * Time.fixedDeltaTime);
                if (Random.Range(1,100) % 7 == 0)
                {
                    Shoot();
                }
            }
            else if (Mathf.Abs(rb.position.x - startPosition.x) < maxOffset)
            {
                rb.MovePosition(rb.position + new Vector2(facingRight ? 1: -1,0) * Time.fixedDeltaTime);
            }
            else
            {
                if ((rb.position.x - startPosition.x) > 0)
                {
                    facingRight = false;
                }
                else
                {
                    facingRight = true;
                }
                rb.MovePosition(rb.position + new Vector2(facingRight ? 1: -1,0) * Time.fixedDeltaTime);
            }
            GetComponent<SpriteRenderer>().flipX = !facingRight;
        }
    }

    public override float SetupDamage()
    {
        return MEDamage;
    }

    public override float SetupHealth()
    {
        return MEHealth;
    }

    public override float SetupHealthYPos()
    {
        return GetComponent<BoxCollider2D>().size.y / 2;
    }

    private bool PlayerCheck()
    {
        
        hitPlayer = Physics2D.BoxCast(transform.position, boxSize, 0, facingRight ? transform.right : -transform.right, boxSize.x / 2, LayerMask.GetMask("Player"));
        if (hitPlayer.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector2(transform.position.x + (facingRight ? 1 : -1) * boxSize.x/2, transform.position.y), boxSize);
    }

    public void Shoot()
    {
        GameObject cactus_projectile = Instantiate(CactusSpike, transform.position, Quaternion.identity);
        Rigidbody2D cactus_projectileRB = cactus_projectile.GetComponent<Rigidbody2D>();
        if (cactus_projectileRB != null)
        {
            Vector2 velocity = new Vector2((facingRight == true ? 1 : -1) * 5, 0);
            cactus_projectileRB.velocity = velocity;
        }
        
    }

}
