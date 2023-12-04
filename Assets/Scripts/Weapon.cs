using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject shootPoint;
<<<<<<< Updated upstream
    public float coolDown;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem shootPar;
    [SerializeField] Rigidbody2D pivotRb;
    [SerializeField] Animator shootAnim;
    [SerializeField] int damage;
=======
    private ParticleSystem shootPar;
    [SerializeField] Rigidbody2D pivotRb;
    [SerializeField] Animator shootAnim;
    [SerializeField] float coolDown;
    [SerializeField] float damage;
>>>>>>> Stashed changes
    [SerializeField] float spread;
    [SerializeField] float bulletSpeed;
    [SerializeField] int bulletAmount;
    [SerializeField] BulletPool bPool;

    void Start()
    {
<<<<<<< Updated upstream
        audioSource = GetComponent<AudioSource>();
        shootPoint = transform.GetChild(0).gameObject;
        shootPar = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
=======
        shootPoint = transform.GetChild(0).gameObject;
        shootPar = transform.GetChild(1).GetComponent<ParticleSystem>();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                    bs.damage = damage;
=======
>>>>>>> Stashed changes
                    b.SetActive(true);
                    break;
                }
            }
            if (!foundBullet)
            {
<<<<<<< Updated upstream
                bPool.CreateIBullet(1, true, spread, shootPoint.transform.position, bulletSpeed, pivotRb, damage);
=======
                bPool.CreateIBullet(1, true, spread, shootPoint.transform.position, bulletSpeed, pivotRb);
>>>>>>> Stashed changes
            }
        }
        ShotEffects();
    }

    void ShotEffects()
    {
<<<<<<< Updated upstream
        audioSource.Play();
=======
>>>>>>> Stashed changes
        shootPar.Play();
        shootAnim.SetTrigger("ShootAnim");
    }
}