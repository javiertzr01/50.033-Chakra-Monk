using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CactusSpikeController : MonoBehaviour
{

    public UnityEvent<float> playerTakesDamage;

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

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            playerTakesDamage.Invoke(100);
        }
    }
}
