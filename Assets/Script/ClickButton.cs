//���ӽ����̽��� ȣ�� (�������� Ŭ���� �� ����ü ���� ���� ���ӽ����̽��� �ҷ��´� = ���̺귯�� ȣ��)
using System.Collections;            //�ڷᱸ��
using System.Collections.Generic;    //�ڷᱸ��
using UnityEngine;                   //����Ƽ API ȣ��

public class ClickButton : MonoBehaviour
{

    public DataController dataController;    //DataController�� �ν��Ͻ�ȭ


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
