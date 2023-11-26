using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject shootPoint;
    private ParticleSystem shootPar;
    [SerializeField] Rigidbody2D pivotRb;
    [SerializeField] float coolDown;
    [SerializeField] float damage;
    [SerializeField] float spread;
    [SerializeField] int bulletAmount;
    [SerializeField] GameObject bullet;

    void Start()
    {
        shootPoint = transform.GetChild(0).gameObject;
        shootPar = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    public void Shoot() 
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            float dir = Random.Range(-spread, spread); 
            GameObject newBullet = Instantiate(bullet, shootPoint.transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().rotation = pivotRb.rotation + dir;
            newBullet.name = "Bullet";
        }
    }
}