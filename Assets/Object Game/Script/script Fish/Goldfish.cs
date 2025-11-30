using UnityEngine;

public class GoldFish : Fish
{
    public override void Swim()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
