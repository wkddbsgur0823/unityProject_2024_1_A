using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;               //���콺 Drag �Ǵ�
    public bool isUsed;              //��� �Ϸ� üũ
    Rigidbody2D rigidbody2D;  //2D ��ü ����
    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;                                                    //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D = GetComponent<Rigidbody2D>();        //������Ʈ�� ��ü�� ����
        rigidbody2D.simulated = false;                                    //���� �ൿ�� ó������ �������� �ʰ� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)                                                          //����� �Ϸ�� ������Ʈ�� ������Ʈ ���� �׳� ���� ������.  (���콺 Input ������ ���� ����)
            return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);           //ȭ�� ��ũ������ ����Ƽ Scene ������ ��ǥ�� �����´�.

            float leftBorder = -5.0f + transform.localScale.x / 2f;                        //������ ��ŭ �̵� ����
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;                //���콺 ��ġ�� �̵� ���� �Ѱ� �̻�, ���Ϸ� ���� ���� �����ؼ� ���д�.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                                                          //������Ʈ Y �� �� ����
            mousePos.z = 0;                                                                          //������Ʈ Z �� �� ����
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);                    //�� ������Ʈ�� ���콺 ��ġ�� ���Ͼ��ϰ� 0.2 ����ŭ�� �̵����� ���󰣴�.
        }

        if (Input.GetMouseButtonDown(0)) Drag();                 //���콺 ��ư�� �������� Drag �Լ� ����
        if (Input.GetMouseButtonUp(0)) Drop();                      //���콺 ��ư�� �ö󰥶� Drop �Լ� ����
    }

    void Drag()                                                           //�巡�� �� �� ���� �� �Լ�
    {
        isDrag = true;                                                   //�巡�� ���̴�.  (true)
        rigidbody2D.simulated = false;                        //���� �ùķ��̼� ����  (false)
    }
    void Drop()                                                        //��� �� �� ���� �� �� ��
    {
        isDrag = false;                                              //�巡�� ���̴�.  (false)
        isUsed = true;                                               // ��� �Ϸ� �Ǿ���.  (true)
        rigidbody2D.simulated = true;                      //���� �ùķ��̼� �����  (true)

        GameObject temp = GameObject.FindWithTag("GameManager");                   //Scene���� GameManager Tag ����� �ִ� ������Ʈ�� �����´�.
        if(temp !=null)                                                                                                     //�ش� ������Ʈ�� ���� ���
        {
            temp.gameObject.GetComponent<GameManager>().GenObject();             //GameManager�� GenObject �Լ��� ȣ��

        }
    }
}
