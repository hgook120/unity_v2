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

    //血量控制-1
    [Header("最高血量")]
    public int maxHealth = 5;

    [Header("當前血量"), Range(0, 5)]
    public int currentHealth;

    //發射子彈-1
    public GameObject projectilePrefab;


    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //血量控制-2
        currentHealth = maxHealth;
        print("Ruby當前血量為:" + currentHealth);
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

        if(!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();
        }

        rubyAnimator.SetFloat("Look X", lookDirection.x);
        rubyAnimator.SetFloat("Look Y", lookDirection.y);
        rubyAnimator.SetFloat("speed", rubyMove.magnitude);

        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition);

        //血量控制-4
        if (currentHealth == 0)
        {
            Application.LoadLevel("Health_damage");
        }

        //發射子彈-3
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }

    }

    //血量控制-3
    public void ChangeHealth(int amout)
    {
        currentHealth = currentHealth + amout;//加血機制-1
        //currentHealth = Math.Clamp(currentHealth + amout, 0, maxHealth); //加血機制-2 改良
        print("Ruby 當前血量為:" + currentHealth);
    }

    //發射子彈-2
    private void Launch() //使用private 因此只有此程式專用
    {
        //使每個Prefab的子彈都「實例化」成場景物件
        //生成的過程中必須告知Prefab生成的位置、角度
        //Quaternion代表無角度旋轉
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position, Quaternion.identity);
        //在Bullet.cs中設置了一個Launch()的方法，並透過「受力的方式」來移動
        //在此設立了一個Bullet的形態的變量，作為乘載此力的施壓容器
        Bullet bullet = projectileObject.GetComponent<Bullet>();

        //上面接收完畢後，透過自帶的 Launch() 方法來實現「受力的方法」
        //在Bullet.cs定義參數 : 方向&力道
        bullet.Launch(lookDirection, 200);//300 數值越大，速度越快

        //發射後播放動畫
        rubyAnimator.SetTrigger("Launch");

    }



}
