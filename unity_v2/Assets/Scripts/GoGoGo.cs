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

    //��q����-1
    [Header("�̰���q")]
    public int maxHealth = 5;

    [Header("��e��q"), Range(0, 5)]
    public int currentHealth;
    

    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //��q����-2
        currentHealth = maxHealth;
        print("Ruby��e��q��:" + currentHealth);
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

        //��q����-4
        if (currentHealth == 0)
        {
            Application.LoadLevel("Health_damage");
        }

    }

    //��q����-3
    public void ChangeHealth(int amout)
    {
        currentHealth = currentHealth + amout;//�[�����-1
        //currentHealth = Math.Clamp(currentHealth + amout, 0, maxHealth); //�[�����-2 ��}
        print("Ruby ��e��q��:" + currentHealth);
    }



}
