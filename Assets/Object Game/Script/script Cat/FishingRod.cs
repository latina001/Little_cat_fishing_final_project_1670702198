using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public Cat playerCat;
    public MiniGame miniGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fish fish = collision.GetComponent<Fish>();
        if (fish != null)
        {
            miniGame.StartMiniGame(fish, playerCat);
        }
    }
}
