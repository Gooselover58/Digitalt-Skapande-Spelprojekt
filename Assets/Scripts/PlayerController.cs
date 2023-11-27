using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canShoot;
    [SerializeField] float moveSpeed;
    [SerializeField] float coolDown;
    public Weapon currentGun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
    }

    void FixedUpdate()
    {
        //GetAxisRaw innehåller ett värde som antingen är mellan -1 och 1
        //Värdet ökar när man trycker upp, och minskar när man trycker ner
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, y);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine("ShootAndCool");
        }
    }

    IEnumerator ShootAndCool()
    {
        canShoot = false;
        currentGun.Shoot();
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
