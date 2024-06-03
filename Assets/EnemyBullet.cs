using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject targetGameObject;

    Vector3 direction; // ����������� ��������
    [SerializeField] float speed; // �������� ����
    private int damage; // ���� ����
    private float Range;
    int hitDetected = 0; // ���� ��������� �� ����������
    Vector3 bulletDirection;
    Vector3 shotStart;


    public void SetRange(float numeric)
    {
        Range = numeric;
    }
    public void SetDamage(int settetDamage)
    {
        damage = settetDamage;
    }

    public void SetDirection(Vector3 direction)
    { //����� ���� ��� ����
        this.direction = direction;
    }

    private void Start()
    {
        bulletDirection = direction - this.transform.position;
        shotStart = this.transform.position;
    }
    // �������� ���� ������ ����
    void Update()
    {
        transform.right = direction;
        GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * speed;

        if (Vector3.Distance(shotStart, transform.position) > Range)
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAa");
            Destroy(gameObject);
        }

    }
    void FixedUpdate()
    {

        //if (Time.frameCount % 2 == 0) {}
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in hit)
        {
            //string TagObject = collider.GetComponent<TagAttribute>();
            Charachter chara = collider.GetComponent<Charachter>();
            if (chara != null)
            {
                hitDetected += 1;
                chara.TakeDamage(damage);
                Debug.Log("�������, �����" + damage);
                break;
            }
        }
        if (hitDetected >= 1)
        {
            Destroy(gameObject);
        }
    }
}
