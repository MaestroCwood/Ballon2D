using UnityEngine;

public class IncrimentCoin : MonoBehaviour
{
    CoinManager coinManager;
    [SerializeField] StarManager starManager;
    [SerializeField] int minRandimSubstract, maxRandimSubstract;

    private void Start()
    {
        coinManager = GetComponent<CoinManager>();
    }

    public void SubtractCoin(Vector3 pos)
    {
        if(coinManager.coinCount > 0)
        {
            int randomSubtraction = RandomSubstract();
            if (coinManager.coinCount <= randomSubtraction)
            {
                randomSubtraction = coinManager.coinCount;
                coinManager.coinCount -= randomSubtraction;
                starManager.CreatedText(pos, "-", randomSubtraction);
                coinManager.UpdateTextcoin();
                coinManager.SaveCoin();              
            }
            else
            {
                starManager.CreatedText(pos, "-", randomSubtraction);
                coinManager.coinCount -= randomSubtraction;
                coinManager.UpdateTextcoin();
                coinManager.SaveCoin();
            }
           
        }
    }

    int RandomSubstract()
    {
        int random = Random.Range(minRandimSubstract, maxRandimSubstract);
        return random; 
    }
}
