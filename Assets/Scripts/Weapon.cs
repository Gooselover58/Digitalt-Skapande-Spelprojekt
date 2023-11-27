using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject shootPoint;
    private ParticleSystem shootPar;
    [SerializeField] Rigidbody2D pivotRb;
    [SerializeField] Animator shootAnim;
    [SerializeField] float coolDown;
    [SerializeField] int damage;
    [SerializeField] float spread;
    [SerializeField] float bulletSpeed;
    [SerializeField] int bulletAmount;
    [SerializeField] BulletPool bPool;

    void Start()
    {
        shootPoint = transform.GetChild(0).gameObject;
        shootPar = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    public void Shoot() 
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            bool foundBullet = false;
            foreach (GameObject b in bPool.bullets)
            {
                if (!b.activeSelf)
                {
                    foundBullet = true;
                    BulletScript bs = b.GetComponent<BulletScript>();
                    bs.angle = spread;
                    bs.startPos = shootPoint.transform.position;
                    bs.speed = bulletSpeed;
                    bs.initAngle = pivotRb.rotation;
                    bs.damage = damage;
                    b.SetActive(true);
                    break;
                }
            }
            if (!foundBullet)
            {
                bPool.CreateIBullet(1, true, spread, shootPoint.transform.position, bulletSpeed, pivotRb, damage);
            }
        }
        ShotEffects();
    }

    void ShotEffects()
    {
        shootPar.Play();
        shootAnim.SetTrigger("ShootAnim");
    }
}