using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Collections;
using YG;

public class TextScaleTween : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float scaleDuration = 0.5f; // Время на увеличение и уменьшение одной цифры
    public float waitBetweenNumbers = 0.2f; // Задержка между цифрами
   
    private void Start()
    {
        
        
    }

    private IEnumerator StartCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            countdownText.transform.localScale = Vector3.zero;

            // Анимация увеличения и уменьшения текста
            Sequence sequence = DOTween.Sequence();
            sequence.Append(countdownText.transform.DOScale(1.5f, scaleDuration).SetEase(Ease.OutBack));
            sequence.Append(countdownText.transform.DOScale(0f, scaleDuration).SetEase(Ease.InBack));

            yield return sequence.WaitForCompletion();
            yield return new WaitForSeconds(waitBetweenNumbers); // Небольшая пауза между цифрами
        }

        
        countdownText.transform.localScale = Vector3.zero;
        countdownText.transform.DOScale(1.5f, scaleDuration).SetEase(Ease.OutBack);
    }

    private void OnEnable()
    {
        StartCoroutine(StartCountdown());
    }

    private void OnDisable()
    {
        StopCoroutine(StartCountdown());
    }
}
