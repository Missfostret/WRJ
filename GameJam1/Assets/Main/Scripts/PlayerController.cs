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

    float moveRight;
    float moveUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveRight = Input.GetAxisRaw("Horizontal");
        moveUp = Input.GetAxisRaw("Vertical");
        
    }
    private void FixedUpdate()
    {
        if (moveRight != 0f || moveUp != 0f)
        {
            if (moveRight != 0f && moveUp != 0f)
            {
                var movement = new Vector2(moveRight, moveUp);
                rb.AddForce(movement * (moveSpeed / Mathf.Sqrt (2)));
            }
            else
            {
                var movement = new Vector2(moveRight, moveUp);
                rb.AddForce(movement * moveSpeed);
            }
           
        }
        
    }
}
