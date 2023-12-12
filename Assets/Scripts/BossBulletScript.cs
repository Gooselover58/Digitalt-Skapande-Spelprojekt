using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
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
        rb.MovePosition(rb.position + -(Vector2)transform.right * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>() != null)
        {
            col.gameObject.GetComponent<PlayerController>().StartCoroutine("GetStunned");
            Deactivate();
        }
    }

    void Deactivate()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    IEnumerator lifeSpan()
    {
        yield return new WaitForSeconds(2);
        Deactivate();
    }
}
