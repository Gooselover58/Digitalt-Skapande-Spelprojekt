using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canShoot;
    private bool isStunned;
    [SerializeField] int bulletsToSpawn;
    [SerializeField] BulletPool bp;
    [SerializeField] GameManager gm;
    [SerializeField] float moveSpeed;
    [SerializeField] Weapon startWeapon;
    public List<Weapon> weapons;
    public Weapon currentGun;

    void Start()
    {
        bp.CreateIBullet(bulletsToSpawn, false, 0, currentGun.transform.GetChild(0).gameObject.transform.position, 0, null, 0, false, false);
        isStunned = false;
        currentGun = startWeapon;
        weapons.Add(startWeapon);
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        DisableGuns();
        SwitchGun(1);
    }

    void FixedUpdate()
    {
        //GetAxisRaw innehåller ett värde som antingen är mellan -1 och 1
        //Värdet ökar när man trycker upp, och minskar när man trycker ner
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, y);
        if (!isStunned)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot && gm.isGameActive && !isStunned)
        {
            StartCoroutine("ShootAndCool");
        }
        if (weapons.Count > 9)
        {
            weapons.Remove(weapons[weapons.Count - 1]);
        }
        for (int i = 1; i < weapons.Count + 1; i++)
        {
            if (Input.GetKeyDown("" + i) && gm.isGameActive)
            {
                SwitchGun(i);
            }
        }
    }

    IEnumerator ShootAndCool()
    {
        canShoot = false;
        currentGun.Shoot();
        yield return new WaitForSeconds(currentGun.coolDown);
        canShoot = true;
    }
    
    void DisableGuns()
    {
        GameObject weap = currentGun.transform.parent.gameObject;
        for (int i = 0; i < weap.transform.childCount; i++)
        {
            weap.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SwitchGun(int whichGun)
    {
        foreach (Weapon w in weapons)
        {
            w.gameObject.SetActive(false);
        }
        weapons[whichGun - 1].gameObject.SetActive(true); 
        currentGun = weapons[whichGun - 1];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<CoinScript>() != null)
        {
            Destroy(col.gameObject);
            gm.coins++;
        }
    }

    public IEnumerator GetStunned()
    {
        isStunned = true;
        yield return new WaitForSeconds(2);
        isStunned = false;
    }
}
