using UnityEngine;

public class Cat : MonoBehaviour
{
    public int score;

    public void CatchFish(Fish fish)
    {
        score += fish.points;
        Destroy(fish.gameObject);
    }
}
