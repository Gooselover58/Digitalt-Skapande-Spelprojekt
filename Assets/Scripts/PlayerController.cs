using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canShoot;
    [SerializeField] float moveSpeed;
    [SerializeField] Weapon startWeapon;
    public List<Weapon> weapons;
    public Weapon currentGun;

    void Start()
    {
        currentGun = startWeapon;
        weapons.Add(startWeapon);
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        SwitchGun(1);
    }

    void FixedUpdate()
    {
        //GetAxisRaw inneh�ller ett v�rde som antingen �r mellan -1 och 1
        //V�rdet �kar n�r man trycker upp, och minskar n�r man trycker ner
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
        for (int i = 1; i < weapons.Count + 1; i++)
        {
            if (Input.GetKeyDown("" + i))
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
    
    void SwitchGun(int whichGun)
    {
        foreach (Weapon w in weapons)
        {
            w.gameObject.SetActive(false);
        }
        weapons[whichGun - 1].gameObject.SetActive(true); 
        currentGun = weapons[whichGun - 1];
    }
}
