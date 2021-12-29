using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // Start is called before the first frame update

    private static DataController instance;
    public static DataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();

            if(instance == null)
            {
                GameObject container = new GameObject("DataController");

                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }

    private ItemButton[] itemButtons;


    private int m_gold = 0;
    private int m_goldPerClick = 0;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        m_gold = PlayerPrefs.GetInt("Gold");                         //playerprefs 에 Gold라고 정의되어 있는 데이터를 로드
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);         //playerprefs 에 GoldPerClick라고 정의되어 있는 데이터를 로드, 기본값 1 설정

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    // 골드량을 레지스트리에 저장하는 메소드
    public void SetGold(int newGold)                                 
    {     
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }
    
    // 골드량 증가 감소를 처리하는 메소드
    public void AddGold(int newGold)
    {    
        //m_gold = m_gold + newGold;
        m_gold += newGold;
        SetGold(m_gold);
    }
    public void SubGold(int newGold)
    {
        //m_gold = m_gold - newGold;
        m_gold -= newGold;
        SetGold(m_gold);
    }
    //

    public int GetGold()
    {
        return m_gold;
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
    }
    
    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);

        if(PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            itemButton.isPurchased = true; 
        }    
        else
        {
            itemButton.isPurchased = false;
        }

    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);

        if(itemButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }

    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for(int i = 0; i < itemButtons.Length;i++)
        {
            goldPerSec += itemButtons[i].goldPerSec;
        }
        return goldPerSec;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
