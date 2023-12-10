using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] Gradient bossBarGradient;
    [SerializeField] GameObject bossUI;
    [SerializeField] GameObject bossBar;
    [SerializeField] TextMeshProUGUI bossText;
    [SerializeField] EnemyPool ep;
    public bool isGameActive;
    public float time;
    public int lives;
    public int coins;
    void Start()
    {
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
    }

    private void Update()
    {
        if (bos != null)
        {
            health = bos.health;
        }
        moneyText.text = "Money: " + coins + "$";
        bossText.text = health + "/" + maxHealth;
        time += Time.deltaTime;
        if (lives < 1)
        {
            isGameActive = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            KillYourself();
        }
        if (Input.GetKeyDown(KeyCode.H))
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
        maxHealth = bos.maxHealth;
        health = bos.maxHealth;
        ep.isBossSpawned = true;
        bos.opening();
    }

    public void EndBoss()
    {
        bossUI.SetActive(false);
        ep.isBossSpawned = false;
        ep.StartCoroutine("spawnEnemies");
    }
}
