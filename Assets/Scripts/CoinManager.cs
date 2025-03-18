using System;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCoin;
    public int coinCount;
    [SerializeField] int minRandomAdd, maxRandomAdd;
    [SerializeField] GameObject coinFx;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Coin"))
        {
            coinCount = PlayerPrefs.GetInt("Coin", 0);
        }

        UpdateTextcoin();
    }

     void AddCoin()
    {
        
        coinCount += RandomAddCoin();
        UpdateTextcoin();
        SaveCoin();

    }

    public void UpdateTextcoin()
    {
        textCoin.text = coinCount.ToString();
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", coinCount);
        PlayerPrefs.Save();
    }

    public void CreateCoin(Vector3 pos)
    {
        AddCoin();
        Instantiate(coinFx, pos, Quaternion.identity);
        
    }

    int RandomAddCoin()
    {
        int coinRandom = UnityEngine.Random.Range(minRandomAdd, maxRandomAdd);
        return coinRandom;
    }
}
