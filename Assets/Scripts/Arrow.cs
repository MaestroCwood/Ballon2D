
using UnityEngine;

public class Arrow : MonoBehaviour
{

    
    Merge randomMerge;
    public float speed = 5f;
   
    private void Start()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlayOneFx(3);
        Merge[] allMerges = FindObjectsByType<Merge>(FindObjectsSortMode.None);
        if (allMerges.Length > 0)
        {
            // Выбираем случайный объект
            randomMerge = allMerges[Random.Range(0, allMerges.Length)];
        }

    }

    private void FixedUpdate()
    {
        Vector2 direction = (randomMerge.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

    }


}
