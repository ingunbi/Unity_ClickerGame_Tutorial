using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public DataController dataController;

    public Text itemDisplayer;
    public string itemName;
    public int level;
    public int currentCost;                  //현재구매비용
    public int startCurrentCost = 1;
    public int goldPerSec;
    public int startGoldPerSec = 1;
    public float costPow = 2.14f;
    public float upgradePow = 1.14f;
    public bool isPurchased = false;

    void Start()
    {
        dataController.LoadItemButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
    }


    public void PurchaseItem()
    {
        if(dataController.GetGold() >= currentCost)
        {
            isPurchased = true;             //대단히 주의 해야 할 코드
            dataController.SubGold(currentCost);
            level += 1;

            UpdateItem();
            UpdateUI();
            dataController.SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()
    {
        while(true)
        {
            if(isPurchased)
            {
                dataController.AddGold(goldPerSec);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = currentCost + startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = "아이템이름 : " + itemName + "\n" + "레벨 : " + level + "\n" + "구매비용 : " + currentCost + "\n" + "초당골드획득 : " + goldPerSec + "\n" + "구매여부 : " + isPurchased;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
