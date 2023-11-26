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
    [SerializeField] float damage;
    [SerializeField] float spread;
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
            float dir = Random.Range(-spread, spread);
            foreach (GameObject b in bPool.bullets)
            {
                if (!b.activeSelf)
                {
                    foundBullet = true;
                    b.GetComponent<BulletScript>().angle = dir;
                    b.SetActive(true);
                    ShotEffects();
                    break;
                }
            }
            if (!foundBullet)
            {
                bPool.CreateIBullet(1, true, dir);
                ShotEffects();
            }
        }
    }

    void ShotEffects()
    {
        shootPar.Play();
        shootAnim.SetTrigger("ShootAnim");
    }
}