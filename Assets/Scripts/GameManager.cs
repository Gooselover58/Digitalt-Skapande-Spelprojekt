using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int maxHealth;
    private int health;
    private BossScript bos;
    [SerializeField] GameObject shopUI;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] List<Weapon> weaponsForSale;
    [SerializeField] List<Button> buttons;
    [SerializeField] PlayerController pc;
    [SerializeField] GameObject bossOb;
    [SerializeField] GameObject bossUI;
    [SerializeField] Slider bossBar;
    [SerializeField] TextMeshProUGUI bossText;
    [SerializeField] TextMeshProUGUI bossHealthText;
    [SerializeField] EnemyPool ep;
    [SerializeField] GameObject GameOverUI;
    public bool isGameActive;
    public float time;
    public int lives;
    public int coins;
    void Start()
    {
        bossOb.SetActive(false);
        GameOverUI.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i < weaponsForSale.Count; i++)
        {
            SetUpGuns(i);
        }
        shopUI.SetActive(false);
        bossUI.SetActive(false);
        isGameActive = true;
        lives = 3;
        coins = 0;
        StartCoroutine("WaitToSpawnBoss");
    }

    private void Update()
    {
        if (bos != null)
        {
            health = bos.health;
            bossBar.value = health;
        }
        moneyText.text = "Money: " + coins + "$";
        bossHealthText.text = health + "/" + maxHealth;
        time += Time.deltaTime;
        if (lives < 1)
        {
            isGameActive = false;
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            KillYourself();
        }
        if (Input.GetKeyDown(KeyCode.H) && isGameActive)
        {
            OpenShop();
        }
    }

    void KillYourself()
    {
        lives = 0;
    }

    void SetUpGuns(int num)
    {
        buttons[num].onClick.AddListener(() => BuyGun(weaponsForSale[num], weaponsForSale[num].price));
    }

    public void BuyGun(Weapon GunToBuy, int price)
    {
        if (coins >= price)
        {
            coins -= price;
            pc.weapons.Add(GunToBuy);
            pc.SwitchGun(pc.weapons.Count - 1);
        }
    }

    public void OpenShop()
    {
        isGameActive = false;
        Time.timeScale = 0;
        shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        isGameActive = true;
        Time.timeScale = 1;
        shopUI.SetActive(false);
    }

    public void StartBoss(BossScript boss, string name)
    {
        bos = boss;
        bossUI.SetActive(true);
        bossText.text = name;
        maxHealth = bos.baseHealth + (int)(time / 2);
        bos.health = maxHealth;
        health = maxHealth;
        bossBar.maxValue = maxHealth;
        ep.isBossSpawned = true;
        bos.opening();
    }

    public void EndBoss()
    {
        bossUI.SetActive(false);
        bossOb.SetActive(false);
        ep.isBossSpawned = false;
        ep.StartCoroutine("spawnEnemies");
        StartCoroutine("WaitToSpawnBoss");
    }

    IEnumerator WaitToSpawnBoss()
    {
        yield return new WaitForSeconds(Random.Range(30, 50));
        bossOb.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void EndGame()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
