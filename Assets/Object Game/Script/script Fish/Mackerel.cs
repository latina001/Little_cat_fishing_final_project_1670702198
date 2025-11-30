using UnityEngine;

public class Mackerel : Fish
{
    public override void Swim()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}