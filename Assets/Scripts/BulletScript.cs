using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool piercing;
    public float speed;
    public Vector2 startPos;
    public float initAngle;
    public float angle;
    public float damage;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startPos;
        rb.rotation = initAngle + Random.Range(-angle, angle);
        StartCoroutine("lifeSpan");
    }

    void FixedUpdate()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Deactivate();
        }
        rb.MovePosition(rb.position + (Vector2)transform.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyScript>() != null)
        {
            col.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            if (!piercing)
            {
                Deactivate();
            }
        }
        if (col.gameObject.GetComponent<BossScript>() != null)
        {
            col.gameObject.GetComponent<BossScript>().TakeDamage(damage);
            if (!piercing)
            {
                Deactivate();
            }
        }

    }

    void Deactivate()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    IEnumerator lifeSpan()
    {
        yield return new WaitForSeconds(5);
        Deactivate();
    }
}
