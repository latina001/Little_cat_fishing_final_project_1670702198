using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Salmon : Fish
{
    void Start()
    {
        fishName = "Goldfish";
        points = 10;
        speed = 10f;
    }

    public override void Swim()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void Update()
    {
        Swim();
    }
}
