using UnityEngine;

public class RodToggle : MonoBehaviour
{
    public GameObject rodObject; // ตัวเบ็ตตกปลา

    private void Update()
    {
        // คลิกขวาเพื่อเปิด/ปิดเบ็ต
        if (Input.GetMouseButtonDown(1)) // 1 = Right Click
        {
            if (rodObject != null)
                rodObject.SetActive(!rodObject.activeSelf); // สลับเปิด/ปิด
        }
    }
}
