using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubyMove : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D ruby;

    public Animator rubyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ruby = GetComponent<Rigidbody2D>();
        
        rubyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 rubyPosition = transform.position;

        //rubyPosition.x = rubyPosition.x + moveSpeed * Input.GetAxis("Horizontal");
        //print( Input.GetAxis("Horizontal") );
        //transform.position = rubyPosition;
        //rubyPosition.y = rubyPosition.y + moveSpeed * Input.GetAxis("Vertical");
        //print(Input.GetAxis("Vertical"));
        //transform.position = rubyPosition;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal ==0 && vertical ==0)
        {
            rubyAnimator.SetTrigger("stand");
        }

        rubyAnimator.SetFloat("moveX", horizontal);
        rubyAnimator.SetFloat("moveY", vertical);
        rubyPosition.x += moveSpeed * horizontal * Time.deltaTime;
        rubyPosition.y += moveSpeed * vertical * Time.deltaTime;

        ruby.MovePosition(rubyPosition);       
    }
}
