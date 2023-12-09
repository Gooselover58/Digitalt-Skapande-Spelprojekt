using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float force;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        StartCoroutine("GoToPlayer");
    }

    IEnumerator GoToPlayer()
    {
        yield return new WaitForSeconds(2);
        Vector2 dir = transform.position - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        rb.MovePosition(dir * speed * Time.fixedDeltaTime);
    }
}
