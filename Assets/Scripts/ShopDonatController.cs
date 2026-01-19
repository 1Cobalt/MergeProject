using System;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Serialization;

public class ShopDonatController : MonoBehaviour
{
    public TextMeshProUGUI money1Text;
    public TextMeshProUGUI money2Text;
    public TextMeshProUGUI money3Text;
    public GameObject purschaisePanel;

    public string donate1 = "test";
    public string donate2 = "test2";
    public string donate3 = "test3";

    public void UpdateMoney1(Product product)
    {
        money1Text.text = product.metadata.localizedPrice + " " + product.metadata.isoCurrencyCode;
    }

    public void UpdateMoney2(Product product)
    {
        money2Text.text = product.metadata.localizedPrice + " " + product.metadata.isoCurrencyCode;
    }

    public void UpdateMoney3(Product product)
    {
        money3Text.text = product.metadata.localizedPrice + " " + product.metadata.isoCurrencyCode;
    }


    public void OnPurchaseComplete(Product product)
    {
        Debug.Log("Purchase initialised: " + product.definition.id);
        if (product.definition.id == donate1)
        {
            
            StaticDataStorage.SetShakeCount(StaticDataStorage.GetShakeCount() + 5);
        }
        else if (product.definition.id == donate2)
        {
          
            StaticDataStorage.SetShakeCount(StaticDataStorage.GetShakeCount() + 10);
        }
        else if (product.definition.id == donate3)
        {
            
            purschaisePanel.SetActive(true);
        }
        Camera.main.GetComponent<SaveSerial>().SaveGame();
    }

}
