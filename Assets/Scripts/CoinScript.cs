using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] Vector2 dir;
    private bool isMoving;
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float force;
    public GameObject player;

    void Start()
    {
        isMoving = false;
        rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        StartCoroutine("GoToPlayer");
    }

    void Update()
    {
        if (isMoving)
        {
            dir = player.transform.position - transform.position;
            transform.Translate(-dir.normalized * speed * Time.deltaTime);
        }
    }

    IEnumerator GoToPlayer()
    {
        yield return new WaitForSeconds(2);
        dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        isMoving = true;
    }
}
