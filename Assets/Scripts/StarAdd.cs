using UnityEngine;
using DG.Tweening;

public class StarAdd : MonoBehaviour
{
  

    [SerializeField] SpriteRenderer spriteRenderer;


    private void Start()
    {
        AnimateStar();
    }
    public void AnimateStar()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(1f, 3f);
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(new Vector3(0.7f, 0.7f), 1f));

        sequence.Join(transform.DORotate(new Vector3(0f, 360f * 3, 360f * 3), 1f, RotateMode.FastBeyond360)
                          .SetLoops(5, LoopType.Yoyo));

        sequence.Join(transform.DOMove(transform.position + new Vector3(randomX, randomY), 1f));

        sequence.Join(spriteRenderer.DOFade(0, 1f).SetDelay(1f));

        sequence.Join(transform.DOScale(Vector3.zero, 1f).SetDelay(1f));

        // Удаление объекта после завершения всех анимаций
        sequence.OnComplete(() => Destroy(gameObject));


    }
}
