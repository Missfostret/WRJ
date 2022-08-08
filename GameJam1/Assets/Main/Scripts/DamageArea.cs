using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    bool hasEntityEntered = false;
    bool isTicking = false;

    float damage = 1f;
    float AoETickRate = 1f;

    List<StatSystem> statSystems;
    Enums.EntityState entityState = Enums.EntityState.Player;

    void Start()
    {
        statSystems = new List<StatSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            var latestHit = collision.gameObject.GetComponent<StatSystem>();
            var isFriendly = latestHit.GetEntityState == entityState;
            if (!isFriendly)
            {
                statSystems.Add(latestHit);
                hasEntityEntered = latestHit != null;
            }

            if (statSystems.Count == 1 && !isTicking)
            {
                StartCoroutine(DealDamage());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        statSystems.Remove(collision.gameObject.GetComponent<StatSystem>());
        if (statSystems.Count <= 0)
        {
            hasEntityEntered = false;
        }
    }

    IEnumerator DealDamage()
    {
        isTicking = true;
        while (hasEntityEntered == true)
        {
            foreach (var statSystem in statSystems)
            {
                statSystem.DecreaseHealth(damage);
            }
            yield return new WaitForSeconds(AoETickRate);
        }
        isTicking = false;
    }
}
