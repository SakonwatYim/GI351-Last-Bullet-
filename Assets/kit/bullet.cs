using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.HID;

public class bullet : MonoBehaviour
{
    public Monster monster;
    public float speed = 100f;
    public float speed_bullet = 50f;

   
    // Update is called once per frame
    void Update()
    {
        //raycastดีกว่าOncollitionเพราะ raycastตรวจจับเป็นเส้นตรง(เป็นเส้นดูว่ามันกำลังจะชนไหม) แล้วใช้colliderตรวจcompareTagว่ามันโดนไหมุ 
        //แต่ถุ้ามันเป็นOncollitionมันจะตรวจจับระยะใหล้และกระสุนเดินทางไวทำให้ข้ามคอไรเดอร์ไปได้
        if (Physics.Raycast(transform.position, monster.distance_direction.normalized, out RaycastHit shoot, speed *Time.deltaTime))
        {
            if (shoot.collider.CompareTag("Player"))
            {
                monster.hasShoot = true;
                //Destroy(monster.player);
                //รอทำเรื่องplayer
                Destroy(gameObject);
            }
            else if (shoot.collider.CompareTag("WallY_under") || shoot.collider.CompareTag("WallY_on") || shoot.collider.CompareTag("WallX_left") || shoot.collider.CompareTag("WallX_right")||shoot.collider.CompareTag("floor"))
            {
                monster.hasShoot = true;
                Destroy(gameObject);
            }
            else if(shoot.collider.CompareTag("monster"))
            {
                monster.hasShoot = true;
                Destroy(gameObject);
            }
        }
        transform.position += monster.distance_direction.normalized * (speed_bullet * Time.deltaTime);
    }
}
    
       