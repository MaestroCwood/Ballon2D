using UnityEngine;
using DG.Tweening;

public class BlinkingEffect : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 0.5f; // �����, �� ������� ������ �������� � ����������
    [SerializeField] private int blinkLoops = -1; // ����������� ����� (����� ������ ����� ��� ������������� �������)

    private void Start()
    {
        StartBlinking();
    }

    private void StartBlinking()
    {
        // �������� ������� ����� ��������� ������������
        CanvasGroup canvasGroup = gameObject.AddComponent<CanvasGroup>();

        canvasGroup.DOFade(0, blinkDuration)
            .SetLoops(blinkLoops, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
