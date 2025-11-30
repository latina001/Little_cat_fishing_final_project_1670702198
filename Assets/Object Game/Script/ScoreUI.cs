using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public Cat playerCat;
    public TMP_Text scoreText;

    private void Update()
    {
        if (playerCat != null)
        {
            scoreText.text = "" + playerCat.score;
        }
    }
}
