using System;
using System.Threading;
using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    bool hasShoot =true;
    public int health;
    public int damage;
    public Monster monster;
    public Transform firepoint;
    public GameObject bullet;
    public GameObject lazer;
    public int currrent_Bullet;
    public int max_Bullet ;
    public Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Delay()
    {
        shoot(bullet);
        hasShoot = false;
        yield return new WaitForSeconds(2f);
        hasShoot = true;
    }
   
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
    }
    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(health);
        Debug.Log(currrent_Bullet);
        direction = Camera.main.transform.forward;

        if (hasShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currrent_Bullet > 20)
                {
                    damage -= 10;
                    StartCoroutine(Delay());
                    currrent_Bullet -= 1;
                }
                if (currrent_Bullet <= 20 && currrent_Bullet >= 2)
                {
                    shoot(bullet);
                    shoot(bullet);
                    currrent_Bullet -= 1;
                }

                if (currrent_Bullet == 1)
                
                        {
                    shoot(lazer);
                        currrent_Bullet -= 1;
                        }

                


            }
        }

    }
   
}
