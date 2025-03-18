using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextCreated : MonoBehaviour
{
    [SerializeField] float scale, duration;
    void Start()
    {
        transform.DOScale(scale, duration);
        TextMeshPro text = GetComponent<TextMeshPro>();
        text.DOFade(0, duration).OnComplete(() => Destroy(gameObject));
    }


}
