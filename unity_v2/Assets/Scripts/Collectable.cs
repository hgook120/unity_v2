using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoGoGo rubyMove = collision.GetComponent<GoGoGo>();
        print("�I�쪺�F��O:" + rubyMove);
        rubyMove.ChangeHealth(1);
        Destroy(gameObject);
    }

}