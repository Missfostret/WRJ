using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    bool hasPlayerEntered = false;
    float healing = 1f;
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
            StartCoroutine(Heal());
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

    IEnumerator Heal()
    {
        while (hasPlayerEntered == true)
        {
            foreach (var statSystem in statSystems)
            {
                statSystem.IncreaseHealth(healing);
            }
            yield return new WaitForSeconds(AoETickRate);
        }
    }

    public float Healing
    {
        get { return healing; }
        set { healing = value; }
    }

    public float TickRate
    {
        get { return AoETickRate; }
        set { AoETickRate = value; }
    }
}
