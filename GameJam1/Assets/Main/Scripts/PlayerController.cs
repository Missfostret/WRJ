using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 15f;
    [SerializeField]
    GameObject reticle;
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    CombatScript combatScript;

    float moveRight;
    float moveUp;

    void Update()
    {
        moveRight = Input.GetAxisRaw("Horizontal");
        moveUp = Input.GetAxisRaw("Vertical");

        if (Input.inputString != "")
        {
            var number = 0;
            var isNumber = int.TryParse(Input.inputString, out number);
            if (isNumber & number >= 0 && number < 10)
            {
                combatScript.SpawnAttack(number);
            }
        }
    }

    private void FixedUpdate()
    {
        if (moveRight != 0f || moveUp != 0f)
        {
            if (moveRight != 0f && moveUp != 0f)
            {
                var movement = new Vector2(moveRight, moveUp);
                rb.AddForce(movement * (moveSpeed / Mathf.Sqrt(2)));
            }
            else
            {
                var movement = new Vector2(moveRight, moveUp);
                rb.AddForce(movement * moveSpeed);
            }
        }
    }
}
