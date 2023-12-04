using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int initialHealth;
    [SerializeField] float speed;
    private int health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void OnEnable()
    {
        health = initialHealth;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    private void Update()
    {
        if (health < 1 || !GetComponent<SpriteRenderer>().isVisible)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("D");
        health -= amount;
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        sr.color = Color.grey;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
