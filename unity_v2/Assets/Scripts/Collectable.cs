using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoGoGo rubyMove = collision.GetComponent<GoGoGo>();
        print("碰到的東西是:" + rubyMove);
        rubyMove.ChangeHealth(1);
        Destroy(gameObject);
    }

}
