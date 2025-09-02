using System;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Action<int, Vector2> conbinedSetting;
    public Action<int> addScore;

    int coinIndex;
    public int CoinIndex { get{ return coinIndex; } set{ coinIndex = value; } }

    bool isConbinedFlag = false;  // è’ìÀéûÅAÇ«ÇøÇÁÇ©1âÒÇµÇ©èàóùÇåƒÇŒÇ»Ç¢ÇÊÇ§Ç…Ç∑ÇÈÇΩÇﬂ

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CoinController>() != null)
        {
            CoinController hitCoinController = collision.gameObject.GetComponent<CoinController>();

            if (coinIndex == hitCoinController.coinIndex)
            {
                if (hitCoinController.isConbinedFlag) return;

                isConbinedFlag = true;
                Vector2 hitPos = collision.transform.position;
                Vector2 middlePos = Vector2.Lerp(transform.position, hitPos, 0.5f);
                Vector2 conbinePos = new Vector2(middlePos.x, Mathf.Min(transform.position.y, hitPos.y));

                conbinedSetting.Invoke(coinIndex + 1, conbinePos);
                addScore.Invoke(coinIndex);

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
