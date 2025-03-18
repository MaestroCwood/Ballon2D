using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using YG;

public class LoseGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] GameObject textObject;
    string langage;
    float timer = 3f;
    [SerializeField] float startTimerDelay;
   public bool isActiveTimer = false;
    Coroutine startCorutin;
    Merge ballMerge;


    private void Start()
    {
        timer = startTimerDelay;
        langage = YG2.envir.language;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            ballMerge = collision.GetComponent<Merge>();
            if (ballMerge != null && !ballMerge.IsProtected && !isActiveTimer)
            {
                startCorutin = StartCoroutine(StartTimer());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {   
        if(collision != null && !ballMerge.IsProtected)
        {
            Merge mergeComponent = collision.GetComponent<Merge>();
            if(mergeComponent == ballMerge)
            {   
                if(startCorutin != null)
                {
                    StopCoroutine(startCorutin);
                    textObject.SetActive(false);
                    timer = startTimerDelay;
                    isActiveTimer = false;
                    startCorutin = null;
                    ballMerge = null;
                    Debug.Log("Exit trigger");
                }
                
            }
        }
        
    }

    IEnumerator StartTimer()
    {   
        isActiveTimer = true;
        textObject.SetActive(true);
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            textTimer.text = timer.ToString("F0");
            yield return null;
        }
        if(langage == "ru")
            {
                textTimer.text = "Проиграл";
            } else
            {
                textTimer.text = "Lose";
            }
        Debug.Log("Lose");
    }
}
