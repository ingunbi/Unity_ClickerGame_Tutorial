using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public DataController dataController;

    public Text upgradeDisplayer;
    public string upgradeName;

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    public int currentCost;
    public int startCurrentCost = 1;

    public int level = 1;

    public float upgradePow = 2.14f;
    public float costPow = 1.14f;

    // Start is called before the first frame update
    void Start()
    {
        dataController.LoadUpgradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()                          //OnClick �̺�Ʈ�� �۵�
    {
        if (dataController.GetGold() >= currentCost)
        {

            dataController.SubGold(currentCost);    //���׷��̵� Ŭ���� ��差 ����
            level += 1;
            dataController.AddGoldPerClick(goldByUpgrade);

            //Ŭ���� ��� ����� �κе� �����ϴ� �κ�
            UpdateUpgrade();
            UpdateUI();
            dataController.SaveUpgradeButton(this);
        }

    }    

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }


    public void UpdateUI()
    {
        upgradeDisplayer.text = "�����̸� : " + upgradeName + "\n" + "�ʿ� ��� : " + currentCost + "\n" + "���� : " + level + "\n" + "ȹ�� ���� ��� : " + goldByUpgrade;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
