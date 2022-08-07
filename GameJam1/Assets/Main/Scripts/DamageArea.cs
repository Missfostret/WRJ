using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    bool hasPlayerEntered = false;
    float damage = 1f;
    float AoETickRate = 1f;
    List<StatSystem> statSystems;

    void Start()
    {
        statSystems = new List<StatSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            var latestHit = collision.gameObject.GetComponent<StatSystem>();
            statSystems.Add(latestHit);
            hasPlayerEntered = latestHit != null;
            StartCoroutine(DealDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        statSystems.Remove(collision.gameObject.GetComponent<StatSystem>());
        if (statSystems.Count <= 0)
        {
            hasPlayerEntered = false;
        }
    }

    IEnumerator DealDamage()
    {
        while (hasPlayerEntered == true)
        {
            foreach (var statSystem in statSystems)
            {
                statSystem.DecreaseHealth(damage);
            }
            yield return new WaitForSeconds(AoETickRate);
        }
    }
}
