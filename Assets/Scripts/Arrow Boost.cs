using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class ArrowBoost : MonoBehaviour
{
    [SerializeField] GameObject arrowBoost;
    [SerializeField] Transform spawnArrow;
     public int countBoost;
    [SerializeField] TextMeshProUGUI countTextBoost;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Arrow"))
        {
            countBoost = PlayerPrefs.GetInt("Arrow");
        }
        else countBoost = 1;

        UpdateTextCount();

        
    }
    public void CreateArrowBoost()
    {
        Merge[] merges = FindObjectsByType<Merge>(FindObjectsSortMode.None); 
        Arrow[] arrows = FindObjectsByType<Arrow>(FindObjectsSortMode.None); 
        int mergeCount = merges.Length;
        int arrowsCount = arrows.Length;

        if (countBoost > 0 && mergeCount > 0 && arrowsCount == 0)
        {
            GameObject arrow = Instantiate(arrowBoost, spawnArrow.position, Quaternion.identity);
            countBoost--;
            UpdateTextCount();
        }
        
                 
    }

    public void UpdateTextCount()
    {
        countTextBoost.text = countBoost.ToString();
       
    }

    public void SaveBoostCount()
    {
        PlayerPrefs.SetInt("Arrow", countBoost);
        PlayerPrefs.Save();
    }
  
}
