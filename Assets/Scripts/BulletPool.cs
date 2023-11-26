using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    [SerializeField] GameObject bulletOb;
    [SerializeField] int bulletAmount;

    void Start()
    {
        CreateIBullet(bulletAmount, false);
    }

    //false = Bullet won't activate
    //true = Bullet will be activated
    public void CreateIBullet(int amount, bool active)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newBullet = Instantiate(bulletOb, bulletOb.transform.position, Quaternion.identity, transform);
            newBullet.SetActive(active);
            bullets.Add(newBullet);
        }
    }
}
