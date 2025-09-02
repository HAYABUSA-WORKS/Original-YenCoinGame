using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 3;
    bool isStart = false;
    public bool IsStart { get { return isStart; } set { isStart = value; } }

    void Update()
    {
        if (!isStart) return;

        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.3f, 4.3f);
        pos += new Vector2(Input.GetAxisRaw("Horizontal"), 0) * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

}
