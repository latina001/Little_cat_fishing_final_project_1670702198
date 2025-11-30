using UnityEngine;

public class Trash : Fish
{
    public override void Swim()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}