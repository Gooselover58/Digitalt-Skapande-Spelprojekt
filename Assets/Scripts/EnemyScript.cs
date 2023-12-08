using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int initialHealth;
    [SerializeField] float speed;
    private int health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AudioSource deathSound;

    void OnEnable()
    {
        health = initialHealth;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        deathSound = GetComponent<AudioSource>();
        sr.color = Color.white;
    }

    void Update()
    {
        if (health < 1)
        {
            health = 2;
            sr.enabled = false;
            StartCoroutine("Death");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
        deathSound.Play();
        health -= amount;
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        sr.color = Color.grey;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    IEnumerator Death()
    {
        deathSound.Play();
        yield return new WaitUntil(() => deathSound.isPlaying == false);
        gameObject.SetActive(false);
    }
}
