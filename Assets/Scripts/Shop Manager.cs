using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] int price;
    [SerializeField] ArrowBoost arrowBoost;
    [SerializeField] CoinManager coinManager;
    

    private void Start()
    {
        priceText.text = $"{price}$";
    }
    public void BuyArrowBoost()
    {
        if(coinManager.coinCount >= price)
        {
            arrowBoost.countBoost++;       
            
            coinManager.coinCount -= price;
            coinManager.SaveCoin();
            coinManager.UpdateTextcoin();
            arrowBoost.UpdateTextCount();
            arrowBoost.SaveBoostCount();
        }
    }
}
