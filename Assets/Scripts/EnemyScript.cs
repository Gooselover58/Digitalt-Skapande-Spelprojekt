using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int initialHealth;
    [SerializeField] float speed;
    private int health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject player;
    public GameObject coinOb;
    public AudioSource deathSound;
    public GameManager gm;

    void OnEnable()
    {
        health = initialHealth;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    void Update()
    {
        if (health < 1)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float amount)
    {
        health -= (int)amount;
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        sr.color = Color.grey;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    void Die()
    {
        int coinAmount = Random.Range(coins, coins + 3);
        for (int i = 0; i < coinAmount; i++)
        {
            GameObject newCoin = Instantiate(coinOb, transform.position, Quaternion.identity);
            newCoin.GetComponent<CoinScript>().player = player;
        }
        deathSound.PlayOneShot(deathSound.clip);
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<BulletScript>() != null)
        {
            BulletScript bs2 = col.gameObject.GetComponent<BulletScript>();
            TakeDamage(bs2.damage);
            if (!bs2.piercing)
            {
                bs2.Deactivate();
            }
        }
        if (col.gameObject.CompareTag("Death"))
        {
            gm.lives--;
            gameObject.SetActive(false);
        }
    }
}
