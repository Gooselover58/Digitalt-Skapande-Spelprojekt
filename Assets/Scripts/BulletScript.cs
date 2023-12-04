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
<<<<<<< Updated upstream
    public int damage;
=======
>>>>>>> Stashed changes
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPos;
        rb.rotation = initAngle + Random.Range(-angle, angle);
    }

<<<<<<< Updated upstream
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPos;
        rb.rotation = initAngle + Random.Range(-angle, angle);
    }

=======
>>>>>>> Stashed changes
    void FixedUpdate()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            gameObject.SetActive(false);
        }
        rb.MovePosition(rb.position + (Vector2)transform.right * speed * Time.fixedDeltaTime);
    }

<<<<<<< Updated upstream
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyScript>() != null)
        {
            col.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
        }
    }*/
=======
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<EnemyScript>() != null)
        {
            
        }
    }
>>>>>>> Stashed changes
}
