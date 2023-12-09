using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float y;
    [SerializeField] float speed;
    [SerializeField] int baseHealth;
    [SerializeField] int id;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        y = Random.Range(-1, 2);
    }

    void Update()
    {
        if (transform.position.y > 3.8 || transform.position.y < -3.8)
        {
            y *= -1;
        }
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, y);
        rb.MovePosition(rb.position + movement.normalized * speed);
    }
}
