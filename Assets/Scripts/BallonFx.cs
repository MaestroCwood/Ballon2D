using UnityEngine;

public class BallonFx : MonoBehaviour
{
   [SerializeField] GameObject prefabFx;
   
   SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        prefabFx = GameObject.FindGameObjectWithTag("Fx");
    }

    private void OnDestroy()
    {
        Texture2D texture = spriteRenderer.sprite.texture;
        Color colorSprite = texture.GetPixel(texture.width / 2, texture.height / 2);
        if(prefabFx != null)
            
        {
            prefabFx.transform.position = transform.position;
            ParticleSystem partical = prefabFx.GetComponent<ParticleSystem>();
            var mainModul = partical.main;
            mainModul.startColor = colorSprite;
            partical.Play();
        }
    }
        




}
