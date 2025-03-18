using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] ballPrefabs;
    [SerializeField] EnergyUI energyUI;
    [SerializeField]  float offsetMobileY;
    [SerializeField] GameObject starFx;
    [SerializeField] AudioManager audioManager;
    [SerializeField] float gravityScale = -0.5f;
    [SerializeField] SpriteRenderer spriteRendererNextBal;
    GameObject currentBall;
    [SerializeField]float delay = 1f;
    [SerializeField] Collider2D spawnArea;
    IncrimentCoin incrimentCoin;
    float lastActionTime = -Mathf.Infinity;
    int nextBallIndex;
    bool isMibileDives;


    private void Awake()
    {
        incrimentCoin = GetComponent<IncrimentCoin>();
    }
    void Start()
    {
        isMibileDives = YG2.envir.isMobile;
        nextBallIndex = RandomBall();
        UpdateNextBallSprite();
    }

    void Update()
    {
       
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;

        
        if (Input.GetMouseButtonDown(0) && Time.time >= lastActionTime + delay && spawnArea.OverlapPoint(worldPos))
        {
            if(isMibileDives)
            {
                worldPos.y += offsetMobileY;
            }
            currentBall = Instantiate(ballPrefabs[nextBallIndex], worldPos, Quaternion.identity);
            audioManager.SoundFx(0);
            nextBallIndex = RandomBall();
            UpdateNextBallSprite();
            lastActionTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0) && currentBall != null)
        {
            audioManager.StopSound();
            currentBall.GetComponent<Rigidbody2D>().gravityScale = -Mathf.Pow(currentBall.transform.localScale.x, 2) * gravityScale;
            energyUI.image.fillAmount = 0;
            currentBall = null;

        }

        if (Input.GetMouseButton(0) && currentBall != null)
        {
          
            currentBall.transform.localScale += Vector3.one * Time.deltaTime;
            energyUI.UpdateFillAmount(currentBall.transform.localScale.x);
            if (currentBall.transform.localScale.x >= 1f &&
                currentBall.transform.localScale.y >= 1f &&
                currentBall.transform.localScale.z >= 1f)
            {
                audioManager.StopSound();
                audioManager.SoundFx(1);

                Destroy(currentBall);
                energyUI.image.fillAmount = 0;
                incrimentCoin.SubtractCoin(transform.position);
            }

        }
       
    }

    int RandomBall()
    {
        return Random.Range(0, ballPrefabs.Length);
    }

    void UpdateNextBallSprite()
    {
        if (ballPrefabs.Length > 0 && ballPrefabs[nextBallIndex] != null && ballPrefabs[nextBallIndex].GetComponent<SpriteRenderer>() != null)
        {
            spriteRendererNextBal.sprite = ballPrefabs[nextBallIndex].GetComponent<SpriteRenderer>().sprite;

            // Проверка на null для currentBall
            if (currentBall != null)
            {
                SpriteRenderer spriteRenderer = currentBall.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Sprite sprite = spriteRenderer.sprite;
                    Texture2D texture = sprite.texture;
                    Rect rect = sprite.rect;
                    int x = (int)(rect.x + rect.width / 2);
                    int y = (int)(rect.y + rect.height / 2);
                    Color color = texture.GetPixel(x, y);
                    energyUI.SetColor(color);
                }
            }
        }
     
    }

    public void CreateFxStar()
    {
        Vector2 worldPosCentr = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Instantiate(starFx, worldPosCentr, Quaternion.identity);
    }
}
