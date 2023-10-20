using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableController : MonoBehaviour
{
    private int health = 3;
    private bool broken = false;
    public GameObject chakra;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken && health <= 0)
        {
            animator.SetTrigger("broken");
            broken = true;
        }
    }

    public void Hit()
    {
            health -= 1;
            animator.SetTrigger("hit");
    }

    public void SpawnLoot()
    {
        Instantiate(chakra, transform.position, Quaternion.identity);
    }

}
