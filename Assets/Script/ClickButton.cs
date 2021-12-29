//네임스페이스를 호출 (여러가지 클래스 및 구조체 등을 묶은 네임스페이스를 불러온다 = 라이브러리 호출)
using System.Collections;            //자료구조
using System.Collections.Generic;    //자료구조
using UnityEngine;                   //유니티 API 호출

public class ClickButton : MonoBehaviour
{

    public DataController dataController;    //DataController를 인스턴스화


    public void OnClick()
    {
        int goldPerClick = dataController.GetGoldPerClick();
        dataController.AddGold(goldPerClick);
        
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
