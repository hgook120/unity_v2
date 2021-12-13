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

    //�o�g�l�u-1
    public GameObject projectilePrefab;


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

        //�o�g�l�u-3
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }

    }

    //��q����-3
    public void ChangeHealth(int amout)
    {
        currentHealth = currentHealth + amout;//�[�����-1
        //currentHealth = Math.Clamp(currentHealth + amout, 0, maxHealth); //�[�����-2 ��}
        print("Ruby ��e��q��:" + currentHealth);
    }

    //�o�g�l�u-2
    private void Launch() //�ϥ�private �]���u�����{���M��
    {
        //�ϨC��Prefab���l�u���u��Ҥơv����������
        //�ͦ����L�{�������i��Prefab�ͦ�����m�B����
        //Quaternion�N��L���ױ���
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position, Quaternion.identity);
        //�bBullet.cs���]�m�F�@��Launch()����k�A�óz�L�u���O���覡�v�Ӳ���
        //�b���]�ߤF�@��Bullet���κA���ܶq�A�@���������O���I���e��
        Bullet bullet = projectileObject.GetComponent<Bullet>();

        //�W������������A�z�L�۱a�� Launch() ��k�ӹ�{�u���O����k�v
        //�bBullet.cs�w�q�Ѽ� : ��V&�O�D
        bullet.Launch(lookDirection, 200);//300 �ƭȶV�j�A�t�׶V��

        //�o�g�Ἵ��ʵe
        rubyAnimator.SetTrigger("Launch");

    }



}
