using UnityEngine;
using YG;

public class LeaderBord : MonoBehaviour
{
    [SerializeField] StarManager starManager;
    [SerializeField] LeaderboardYG leaderboard;

    public void SetScoreLb()
    {
        leaderboard.SetLeaderboard(starManager.countStar);
    }

    private void OnEnable()
    {
        //SetScoreLb();
        //Invoke("DelayUpdatelb", 1.5f);
    }

    void DelayUpdatelb()
    {
       // leaderboard.UpdateLB();
    }
}
