using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Vector2 startPos;
    public float initAngle;
    public float angle;
    public int damage;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPos;
        rb.rotation = initAngle + Random.Range(-angle, angle);
    }

    void FixedUpdate()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            gameObject.SetActive(false);
        }
        rb.MovePosition(rb.position + (Vector2)transform.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyScript>() != null)
        {
            col.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
        }
    }
}
