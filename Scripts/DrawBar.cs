using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBar : MonoBehaviour
{
    [SerializeField] LineRenderer line;

    LayerMask coinMask;

    void Start()
    {
        line.startWidth = 0.03f;
        line.endWidth = 0.03f;
        coinMask = 1 << LayerMask.NameToLayer("Coin");
    }

    void Update()
    {
        Vector3 playerPosition = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 9f, coinMask);
        //Debug.Log(hit.collider);

        Vector3 endPosition = new Vector3(playerPosition.x, hit.point.y, 0);

        line.SetPosition(0, playerPosition);
        line.SetPosition(1, endPosition);

        //Debug.Log(endPosition);
    }
}