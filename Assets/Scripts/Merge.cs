using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    AudioManager audioManager;
    GameManager gameManager;
    CoinManager coinManager;
    public bool IsProtected { get; private set; } = true; // ¬ключена защита по умолчанию
    private float protectionDuration = 5;
    bool isColizion = false;
    public int objectID;
    private void Start()
    {
        objectID = GetInstanceID();
        audioManager = FindAnyObjectByType<AudioManager>();
        gameManager = FindAnyObjectByType<GameManager>();
        coinManager = FindAnyObjectByType<CoinManager>();
        Invoke(nameof(RemoveProtection), protectionDuration);
    }
    private void RemoveProtection()
    {
        IsProtected = false; // —нимаем защиту
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == gameObject.tag && !isColizion)
        {   
            Merge otherObject = collision.gameObject.GetComponent<Merge>();
            Merge thisObject = GetComponent<Merge>();
            if(otherObject.objectID > thisObject.objectID)
            {   
               
                StarManager star = FindAnyObjectByType<StarManager>();
                star.AddStar();
                star.CreatedText(thisObject.transform.position,"+",star.RandomAddStar());
                audioManager.SoundFx(1);
                audioManager.PlayOneFx(4);
                gameManager.CreateFxStar();
                if(Random.value > 0.5)
                {
                    coinManager.CreateCoin(thisObject.transform.position);
                    audioManager.PlayOneFx(2);
                }
            }

            isColizion=true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
         
        }
    }

    private void OnDestroy()
    {
        if(audioManager != null)
        {
            audioManager.SoundFx(1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
