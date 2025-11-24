using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public GameObject miniGameUI;      // UI Panel ของมินิเกม
    public RectTransform fishIndicator;
    public RectTransform catchZone;
    public float speed = 100f;

    private Cat playerCat;
    private Fish currentFish;
    private bool isActive = false;

    public void StartMiniGame(Fish fish, Cat cat)
    {
        currentFish = fish;
        playerCat = cat;
        isActive = true;

        miniGameUI.SetActive(true);

        // ตั้งตำแหน่งเริ่ม
        fishIndicator.anchoredPosition = new Vector2(0, 0);

        Debug.Log("MiniGame Started");
    }

    void Update()
    {
        if (!isActive) return;

        // ขยับปลาด้วยปุ่ม Up/Down (อันนี้คุณจะเปลี่ยนเป็นแรงโน้มถ่วงก็ได้)
        float move = 0f;
        if (Input.GetKey(KeyCode.UpArrow)) move = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) move = -speed * Time.deltaTime;

        fishIndicator.anchoredPosition += new Vector2(0, move);

        // กด Space เพื่อตรวจว่าทับหรือไม่
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsOverlap(fishIndicator, catchZone))
            {
                WinMiniGame();
            }
            else
            {
                LoseMiniGame();
            }
        }
    }

    // ---------------------------
    // ใช้เช็คการชนแบบ UI เป๊ะที่สุด
    // ---------------------------
    bool IsOverlap(RectTransform a, RectTransform b)
    {
        Rect rectA = new Rect(
            a.anchoredPosition - (a.sizeDelta * 0.5f),
            a.sizeDelta
        );

        Rect rectB = new Rect(
            b.anchoredPosition - (b.sizeDelta * 0.5f),
            b.sizeDelta
        );

        return rectA.Overlaps(rectB);
    }

    void WinMiniGame()
    {
        isActive = false;
        miniGameUI.SetActive(false);

        playerCat.CatchFish(currentFish);

        Debug.Log("Success! You caught the fish!");
    }

    void LoseMiniGame()
    {
        isActive = false;
        miniGameUI.SetActive(false);

        Destroy(currentFish.gameObject);

        Debug.Log("Failed! The fish escaped!");
    }
}
