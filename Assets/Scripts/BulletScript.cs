using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine("die");
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(15);
        gameObject.SetActive(false);
    }
}
