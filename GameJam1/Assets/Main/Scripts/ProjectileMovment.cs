using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovment : MonoBehaviour
{
    [SerializeField]
    float projectileSpeed = 15f;
    [SerializeField]
    int Damage = 1;
    [SerializeField]
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * projectileSpeed);        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
