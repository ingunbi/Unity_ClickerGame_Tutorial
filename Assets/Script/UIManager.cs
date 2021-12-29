using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text goldPerSec;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldDisplayer.text = "∞ÒµÂ : " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "≈¨∏Ø¥Á ∞ÒµÂ : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSec.text = "√ ¥Á »πµÊ ∞ÒµÂ : " + DataController.GetInstance().GetGoldPerSec();
    }
}
