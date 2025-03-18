using System;
using TMPro;
using UnityEngine;

public class StarManager : MonoBehaviour
{
   [NonSerialized] public int countStar;
    public int minRandomAdd, maxRandomAdd;
    public TextMeshProUGUI textCount;
    public TextMeshPro createdTextCount;
    public GameObject parrentCreatedText;


    private void Start()
    {
        if(PlayerPrefs.HasKey("Star"))
        {
            countStar = PlayerPrefs.GetInt("Star", 0);
        }
        UpdateTextStar();
    }
    public void AddStar()
    {
        countStar += RandomAddStar();
        UpdateTextStar();
        SaveCountStar();
    }

    void UpdateTextStar()
    {
        textCount.text = countStar.ToString();
    }

    void SaveCountStar()
    {
        PlayerPrefs.SetInt("Star", countStar);
        PlayerPrefs.Save();
    }

    public int RandomAddStar()
    {
        int count = UnityEngine.Random.Range(minRandomAdd, maxRandomAdd);
        return count;
    }

    public void CreatedText(Vector3 pos, string increment, int count)
    {
        TextMeshPro text = Instantiate(createdTextCount, pos, Quaternion.identity);
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);
        text.color = new Color(r, g, b);
        text.text = increment + count.ToString();
    }
}
