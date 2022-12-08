using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public GameObject SelectPanel;

    public string itemName;
    public int itemID;
    public int price;

    public bool select;
    public bool buy;
    void Start()
    {
        if (PlayerPrefs.GetInt("sword0select") == 1 && select == true)
        {
            ChekActive();
        }
        else
        {
            ChekActive();
        }
        if (PlayerPrefs.GetInt("sword0buy") == 1 && buy == true)
        {
            ChekActive();
            gameObject.SetActive(false);
        }

    }

    public void BuySword(GameObject buttonComp)
    {
        buttonComp.TryGetComponent(out BuyItem button);
        if (GameManager.Instance.GetMoney() >= button.price)
        {
            if (button.itemName == "sword0" && button.itemID ==0)
            {
                PlayerPrefs.SetInt("sword0select",1);
                PlayerPrefs.SetInt("sword0buy",1);
            }
            GameManager.Instance.DecreaseMoney(button.price);
            OpenSword();
            ChekActive();
        }
    }

    public void SelectSword(GameObject buttonComp)
    {
        buttonComp.TryGetComponent(out BuyItem button);
        
        if (button.itemName == "sword0" && button.itemID == 0)
        {
            ClearSelectSword();
            PlayerPrefs.SetInt("swordSelect0", 1);
        }
        if (button.itemName == "sword1" && button.itemID == 1)
        {
            ClearSelectSword();
            PlayerPrefs.SetInt("swordSelect1", 1);
        }
        OpenSword();
    }
    public void ChekActive()
    {
        if (PlayerPrefs.GetInt("sword0buy") == 1)
        {
            SelectPanel.SetActive(true);
            OpenSword();
        }
        else
        {
            SelectPanel.SetActive(false);
        }
    }
    private void OpenSword()
    {
        List<GameObject> SwordList = GameManager.Instance.GetPlayer().GetSwords();
        for (int i = 0; i < SwordList.Count; i++)
        {
            foreach (var item in SwordList)
            {
                item.gameObject.SetActive(false);
                item.gameObject.SetActive(true);
            }
        }
    }
    public void ClearSelectSword()
    {
        PlayerPrefs.SetInt("swordSelect0", 0);
        PlayerPrefs.SetInt("swordSelect1", 0);
        PlayerPrefs.SetInt("swordSelect2", 0);
        PlayerPrefs.SetInt("swordSelect3", 0);
        PlayerPrefs.SetInt("swordSelect4", 0);
    }
}
