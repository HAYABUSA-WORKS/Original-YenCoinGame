using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] rankTexts = new TextMeshProUGUI[3];

    int[] rank;

    public void SetRank(int score)
    {
        for (int i = 0; i < 3; i++)
        {
            if (score > rank[i])
            {
                int rep = rank[i];
                rank[i] = score;
                score = rep;
            }
        }

    }

    public void DeleteRank()
    {
        for (int i = 0; i < 3; i++)
        {
            rank[i] = 0;
        }
    }

    public void DisplayRank()
    {
        for (int i = 0; i < 3; i++)
        {
            rankTexts[i].text = rank[i] + "‰~";
        }
    }

}
