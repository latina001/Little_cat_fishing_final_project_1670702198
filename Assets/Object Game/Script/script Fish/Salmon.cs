using UnityEngine;

public class Salmon : Fish
{
    public override void Swim()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
