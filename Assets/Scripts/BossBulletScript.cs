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
            Deactivate();
        }
        rb.MovePosition(rb.position + -(Vector2)transform.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>() != null)
        {
            col.gameObject.GetComponent<PlayerController>().StartCoroutine("GetStunned");
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
