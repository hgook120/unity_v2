using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGoGo : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 lookDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;

    public Animator rubyAnimator;
    public Rigidbody2D rb;

    public float speed = 3;

    //﹀秖北-1
    [Header("程蔼﹀秖")]
    public int maxHealth = 5;

    [Header("讽玡﹀秖"), Range(0, 5)]
    public int currentHealth;

    //祇甮紆-1
    public GameObject projectilePrefab;

    //
    public AudioSource audioSource;

    //端
    public AudioClip playerHit;

    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //﹀秖北-2
        currentHealth = maxHealth;
        print("Ruby讽玡﹀秖:" + currentHealth);

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rubyPosition = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        print("Horizontal is:" + horizontal);
        print("Vertical is:" + vertical);

        rubyMove = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();
        }

        rubyAnimator.SetFloat("Look X", lookDirection.x);
        rubyAnimator.SetFloat("Look Y", lookDirection.y);
        rubyAnimator.SetFloat("speed", rubyMove.magnitude);

        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition);

        //﹀秖北-4
        if (currentHealth == 0)
        {
            Application.LoadLevel("Health_damage");
        }

        //祇甮紆-3
        if (Input.GetKey(KeyCode.Space))
        {
            Launch();
        }


    }

    //﹀秖北-3
    public void ChangeHealth(int amout)
    {
        currentHealth = currentHealth + amout;//﹀诀-1
        //currentHealth = Math.Clamp(currentHealth + amout, 0, maxHealth); //﹀诀-2 э▆
        print("Ruby 讽玡﹀秖:" + currentHealth);
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);

        //端
        //if (amout < 0)
        //{
        //    PlaySound(playerHit);
        //}

    }

    //祇甮紆-2
    private void Launch() //ㄏノprivate Τ祘Α盡ノ
    {
        //ㄏ–Prefab紆常龟ㄒてΘ初春ン
        //ネΘ筁祘いゲ斗PrefabネΘ竚à
        //Quaternion礚à臂锣
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position, Quaternion.identity);
        //Bullet.csい砞竚Launch()よ猭硓筁よΑㄓ簿笆
        //砞ミBullet篈跑秖更琁溃甧竟
        Bullet bullet = projectileObject.GetComponent<Bullet>();

        //钡ΜЧ拨硓筁盿 Launch() よ猭ㄓ龟瞷よ猭
        //Bullet.cs﹚竡把计 : よ&笵
        bullet.Launch(lookDirection, 10);//300 计禫硉禫е

        //祇甮冀笆礶
        rubyAnimator.SetTrigger("Launch");

    }



}
