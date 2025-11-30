using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private GameObject[] gameOverUIs;

    public int Score => score; 

    public void CatchFish(Fish fish)
    {
        score += fish.Points;
        Destroy(fish.gameObject);

        if (score < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");

        foreach (GameObject ui in gameOverUIs)
        {
            if (ui != null) ui.SetActive(true);
        }

  
    }
}
