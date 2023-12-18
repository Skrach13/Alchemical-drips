using UnityEngine;

public class WiningOrLosePanel : MonoBehaviour
{
    private void Start()
    {
        TrackerWinningConditions.Instance.OnVictory += ChanhedVictory;
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        TrackerWinningConditions.Instance.OnVictory -= ChanhedVictory;
    }

    private void ChanhedVictory()
    {
        gameObject.SetActive(true);
    }

}
