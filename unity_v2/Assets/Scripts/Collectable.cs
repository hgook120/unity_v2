using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoGoGo rubyMove = collision.GetComponent<GoGoGo>();
        print("碰到的東西是:" + rubyMove);
        rubyMove.ChangeHealth(1);
        

        //音效
        rubyMove.PlaySound(audioClip);

        Destroy(gameObject);
    }


}
