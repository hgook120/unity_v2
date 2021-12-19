using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoGoGo rubyMove = collision.GetComponent<GoGoGo>();
        print("�I�쪺�F��O:" + rubyMove);
        rubyMove.ChangeHealth(1);
        

        //����
        rubyMove.PlaySound(audioClip);

        Destroy(gameObject);
    }


}
