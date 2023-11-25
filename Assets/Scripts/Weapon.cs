using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private ParticleSystem shootPar;
    private GameObject shootPoint;
    private Rigidbody2D rb;
    public float coolDown;
    public float damage;
    public float spread;
    public int bulletAmount;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootPoint = transform.GetChild(0).transform.GetChild(0).gameObject;
        shootPar = transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();

    }

    public void Shoot() 
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            float dir = Random.Range(-spread, spread); 
            GameObject newBullet = Instantiate(bullet, shootPoint.transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().rotation = rb.rotation + dir;
            newBullet.name = "Bullet";
        }
    }
}

class Handgun : Weapon
{
    void Awake()
    {

    }
}