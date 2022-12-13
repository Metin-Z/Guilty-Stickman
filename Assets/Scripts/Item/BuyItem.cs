using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public GameObject SelectPanel;

    public int itemID;
    public int price;

    public bool select;
    public bool buy;

    public bool sword;
    public bool hat;
    void Start()
    {
        if (sword == true)
        {
            SwordBuyDeActive();
        }
        if (hat == true)
        {
            HatBuyDeActive();
        }
    }
    public void BuySword(GameObject buttonComp)
    {
        buttonComp.TryGetComponent(out BuyItem button);
        if (GameManager.Instance.GetMoney() >= button.price)
        {
            PlayerPrefs.SetInt("swordSelect", button.itemID);

            GameManager.Instance.DecreaseMoney(button.price);
            PlayerPrefs.SetInt("buySword" + button.itemID,1);
            OpenSword();
            SwordBuyDeActive();
        }
    }
    public void BuyHat(GameObject buttonComp)
    {
        buttonComp.TryGetComponent(out BuyItem button);
        if (GameManager.Instance.GetMoney() >= button.price)
        {
            PlayerPrefs.SetInt("hatSelect", button.itemID);

            GameManager.Instance.DecreaseMoney(button.price);
            PlayerPrefs.SetInt("buyHat" + button.itemID, 1);
            OpenSword();
            HatBuyDeActive();
        }
    }
    public void SelectSword(GameObject buttonComp)
    {
        buttonComp.TryGetComponent(out BuyItem button);
        PlayerPrefs.SetInt("swordSelect", button.itemID);
        OpenSword();
    }
    public void SelectHat(GameObject buttonComp)
    {
        buttonComp.TryGetComponent(out BuyItem button);
        PlayerPrefs.SetInt("hatSelect", button.itemID);
        OpenSword();
    }
    public void SwordBuyDeActive()
    {
        gameObject.TryGetComponent(out BuyItem button);
        if (PlayerPrefs.GetInt("buySword"+button.itemID)== 1 && buy == true)
        {
            gameObject.SetActive(false);
        }
    }
    public void HatBuyDeActive()
    {
        gameObject.TryGetComponent(out BuyItem button);
        if (PlayerPrefs.GetInt("buyHat" + button.itemID) == 1 && buy == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OpenSword()
    {
        List<GameObject> SwordList = GameManager.Instance.GetPlayer().GetSwords();
        List<GameObject> HatList = GameManager.Instance.GetPlayer().GetHats();
        for (int i = 0; i < SwordList.Count; i++)
        {
            foreach (var item in SwordList)
            {
                item.transform.parent.gameObject.TryGetComponent(out SpawnItem itemSpawn);
                itemSpawn.ResetItem();
            }
        }
        for (int i = 0; i < HatList.Count; i++)
        {
            foreach (var item in HatList)
            {
                item.transform.parent.gameObject.TryGetComponent(out SpawnItem itemSpawn);
                itemSpawn.ResetItem();
            }
        }
    }
}
