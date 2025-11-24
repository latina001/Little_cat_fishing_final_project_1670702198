using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public Cat cat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fish fish = collision.GetComponent<Fish>();
        if (fish != null)
        {
            cat.CatchFish(fish);
        }
    }
}
