using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public RectTransform fishIndicator; // ตัวชี้ปลา
    public RectTransform catchZone;     // โซนที่ต้องอยู่
    public float speed = 100f;          // ความเร็วปลา
    public Cat playerCat;
    private Fish currentFish;
    private bool isActive = false;

    public void StartMiniGame(Fish fish, Cat cat)
    {
        currentFish = fish;
        playerCat = cat;
        isActive = true;

        // วาง fishIndicator เริ่มต้น
        fishIndicator.anchoredPosition = new Vector2(0, 0);
        Debug.Log("Mini-game started! Align the fish in the catch zone!");
    }

    private void Update()
    {
        if (!isActive) return;

        // เคลื่อน fishIndicator ขึ้นลง
        float move = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow)) move = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) move = -speed * Time.deltaTime;

        fishIndicator.anchoredPosition += new Vector2(0, move);

        // ตรวจสอบว่าปลาติดใน catchZone
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fishIndicator.anchoredPosition.y >= catchZone.anchoredPosition.y - catchZone.sizeDelta.y / 2 &&
                fishIndicator.anchoredPosition.y <= catchZone.anchoredPosition.y + catchZone.sizeDelta.y / 2)
            {
                WinMiniGame();
            }
            else
            {
                LoseMiniGame();
            }
        }
    }

    void WinMiniGame()
    {
        isActive = false;
        playerCat.CatchFish(currentFish);
        Debug.Log("Success! You caught the fish!");
    }

    void LoseMiniGame()
    {
        isActive = false;
        Debug.Log("Failed! The fish escaped!");
        Destroy(currentFish.gameObject);
    }
}
