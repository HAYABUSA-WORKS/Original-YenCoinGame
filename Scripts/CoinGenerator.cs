using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CoinController[] coins;
    [SerializeField] Image currentCoinImage;
    [SerializeField] Image nextCoinImage;

    public Action<int> addScore;

    int currentCoinNo;
    int nextCoinNo;

    void Start()
    {
        currentCoinNo = ChooseCoin();
        currentCoinImage.sprite = coins[currentCoinNo].GetComponent<SpriteRenderer>().sprite;
        nextCoinNo = ChooseCoin();
        nextCoinImage.sprite = coins[nextCoinNo].GetComponent<SpriteRenderer>().sprite;

    }

    IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            CoinController coinObject = Instantiate(coins[currentCoinNo], spawnPoint.transform.position, Quaternion.identity, transform);
            coinObject.CoinIndex = currentCoinNo;
            coinObject.conbinedSetting = GenerateConbinedCoin;
            coinObject.addScore = (coinIndex) => addScore.Invoke(coinIndex);

            yield return new WaitForSeconds(0.4f);

            currentCoinNo = nextCoinNo;
            currentCoinImage.sprite = coins[currentCoinNo].GetComponent<SpriteRenderer>().sprite;
            nextCoinNo = ChooseCoin();
            nextCoinImage.sprite = coins[nextCoinNo].GetComponent<SpriteRenderer>().sprite;
        }
    }

    int ChooseCoin()
    {
        int coinNo = UnityEngine.Random.Range(0, 4);  // 1,5,10,50‰~‚ð¶¬‚Å‚«‚é
        return coinNo;
    }

    public void GenerateConbinedCoin(int coinIndex, Vector2 pos)
    {
        SoundManager.instance.PlaySE(0);
        if (coinIndex > coins.Length - 1) return;

        CoinController coinObject = Instantiate(coins[coinIndex], pos, Quaternion.identity, transform);
        coinObject.CoinIndex = coinIndex;
        coinObject.conbinedSetting = GenerateConbinedCoin;
        coinObject.addScore = (coinIndex) => addScore.Invoke(coinIndex);
    }

    public int CoinsLength()
    {
        return coins.Length;
    }

    public void GenerateStart()
    {
        StartCoroutine(SpawnCoin());
    }
}
