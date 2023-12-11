using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] Vector3 startPos;
    [SerializeField] GameManager gm;
    [SerializeField] GameObject bossGun;
    [SerializeField] BossWeapon actualGun;
    public bool isImmortal;
    public int baseHealth;
    public int maxHealth;
    public int health;

    void Start()
    {
        bossGun.SetActive(false);
    }
    void OnEnable()
    {
        isImmortal = true;
        transform.position = startPos;
        rb = GetComponent<Rigidbody2D>();
        gm.StartBoss(this, "Steve, Destroyer of ponds");
    }

    public void opening()
    {
        StartCoroutine("MoveIn");
    }

    public void TakeDamage(float amount)
    {
        if (!isImmortal)
        {
            health -= (int)amount;
            if (health <= 0)
            {
                die();
            }
        }
    }

    void die()
    {
        isImmortal = true;
        bossGun.SetActive(false);
        gm.EndBoss();
    }

    IEnumerator MoveIn()
    {
        while (transform.position.x > 6)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 3);
            yield return new WaitForSeconds(0.1f);
        }
        bossGun.SetActive(true);
        isImmortal = false;
        StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        while (!isImmortal)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            actualGun.Shoot();
        }
    }
}
