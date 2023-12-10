using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField] GameObject player;
    [SerializeField] GameObject coinOb;
    [SerializeField] GameObject enemyOb;
    [SerializeField] GameManager gm;
    [SerializeField] int amount;
    [SerializeField] float spawnInterval;
    [SerializeField] float timeBonus;
    [SerializeField] float x;
    [SerializeField] float y;
    private float newY;
    public bool isBossSpawned;

    private void Start()
    {
        isBossSpawned = false;
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
        EnemyScript es = newEnemy.GetComponent<EnemyScript>();
        es.deathSound = GetComponent<AudioSource>();
        es.coinOb = coinOb;
        es.gm = gm;
        es.player = player;
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

    public IEnumerator spawnEnemies()
    {
        yield return new WaitForSeconds(spawnInterval);
        while (gm.isGameActive && !isBossSpawned)
        {
            spawnEnemy();
            float rand = Random.Range(spawnInterval, spawnInterval + (timeBonus - (gm.time / 100)));
            yield return new WaitForSeconds(rand);
        }
    }
}
