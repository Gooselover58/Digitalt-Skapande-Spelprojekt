using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField] GameObject enemyOb;
    [SerializeField] GameManager gm;
    [SerializeField] int amount;
    [SerializeField] float spawnInterval;
    [SerializeField] float timeBonus;
    [SerializeField] float x;
    [SerializeField] float y;
    private float newY;

    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            CreateEnemy(false);
        }
        StartCoroutine("spawnEnemies");
    }

    void CreateEnemy(bool state)
    {
        newY = Random.Range(-y, y);
        GameObject newEnemy = Instantiate(enemyOb, new Vector3(x, newY, 0), Quaternion.identity, transform);
        enemies.Add(newEnemy);
        newEnemy.SetActive(state);
        newEnemy.name = "Enemy";
        newEnemy.GetComponent<EnemyScript>().deathSound = GetComponent<AudioSource>();
        newEnemy.GetComponent<EnemyScript>().gm = gm;
    }

    void spawnEnemy()
    {
        bool foundEnemy = false;
        foreach (GameObject en in enemies)
        {
            if (!en.activeSelf)
            {
                foundEnemy = true;
                en.SetActive(true);
                newY = Random.Range(-y, y);
                en.gameObject.transform.position = new Vector3(x, newY, 0);
                break;
            }
        }
        if (!foundEnemy)
        {
            CreateEnemy(true);
        }
    }

    IEnumerator spawnEnemies()
    {
        while (gm.isGameActive)
        {
            float rand = Random.Range(spawnInterval, spawnInterval + (timeBonus - (gm.time / 100)));
            yield return new WaitForSeconds(rand);
            spawnEnemy();
        }
    }
}
