using System;
using System.Threading;
using UnityEngine;

public class player : MonoBehaviour
{
    public int health;
    public int damage;
    public Monster monster;
    public Transform firepoint;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public int currrent_Bullet;
    public int max_Bullet = 10;
    public Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        currrent_Bullet = max_Bullet;
    }
    void shoot(GameObject shoot)
    {
        //อยู่ในupdateทำงานทุกเฟรมอยู่แล้ว
        Quaternion rot = Quaternion.LookRotation(direction);
        GameObject gun = Instantiate(shoot, firepoint.position , rot);
        //GameObject gun1 = Instantiate(shoot,firepoint.position + new Vector3(-1f, 0f, 0f),rot); เผื่อไว้ตอนเป็นกระสุนที่5-1
        //ระบบตีตัดเลือกเปลี่ยนDestroyเป็นลดเลือด
        currrent_Bullet -= 1;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        direction = Camera.main.transform.forward;

        if (Input.GetMouseButtonDown(0))
        {
            if (currrent_Bullet > 5)
            {
                shoot(bullet);
            }
            switch (currrent_Bullet)
            {
                case 5:
                    {
                        shoot(bullet1);
                        break;
                    }
                case 4:
                    {
                        shoot(bullet2);
                        break;
                    }
                case 3:
                    {
                        shoot(bullet3);
                        break;
                    }
                case 2:
                    {
                        shoot(bullet4);
                        break;
                    }
                case 1:
                    {
                        shoot(bullet5);
                        break;
                    }
            }


        }

    }
   
}
