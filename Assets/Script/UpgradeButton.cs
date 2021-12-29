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

    public void PurchaseUpgrade()                          //OnClick 이벤트로 작동
    {
        if (dataController.GetGold() >= currentCost)
        {

            dataController.SubGold(currentCost);    //업그레이드 클릭시 골드량 감소
            level += 1;
            dataController.AddGoldPerClick(goldByUpgrade);

            //클릭당 골드 변경된 부분들 저장하는 부분
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
        upgradeDisplayer.text = "부위이름 : " + upgradeName + "\n" + "필요 비용 : " + currentCost + "\n" + "레벨 : " + level + "\n" + "획득 가능 골드 : " + goldByUpgrade;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
