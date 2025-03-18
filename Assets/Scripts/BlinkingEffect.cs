using UnityEngine;
using DG.Tweening;

public class BlinkingEffect : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 0.5f; // Время, за которое объект исчезает и появляется
    [SerializeField] private int blinkLoops = -1; // Бесконечные циклы (можно задать число для ограниченного мигания)

    private void Start()
    {
        StartBlinking();
    }

    private void StartBlinking()
    {
        // Анимация мигания через изменение прозрачности
        CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();

        canvasGroup.DOFade(0, blinkDuration)
            .SetLoops(blinkLoops, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
