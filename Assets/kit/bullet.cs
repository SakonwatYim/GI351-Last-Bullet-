using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class bullet : MonoBehaviour
{
    public Monster monster;
    public float speed = 30; 
    // Update is called once per frame
    void Update()
    {
        //raycastดีกว่าOncollitionเพราะ raycastตรวจจับเป็นเส้นตรง(เป็นเส้นดูว่ามันกำลังจะชนไหม) แล้วใช้colliderตรวจcompareTagว่ามันโดนไหมุ 
        //แต่ถุ้ามันเป็นOncollitionมันจะตรวจจับระยะใหล้และกระสุนเดินทางไวทำให้ข้ามคอไรเดอร์ไปได้
        transform.position += monster.distance_direction.normalized * (100 * Time.deltaTime);
        if (Physics.Raycast(transform.position, monster.distance_direction, out RaycastHit shoot, speed *Time.deltaTime))
        {
            if (shoot.collider.CompareTag("Player"))
            {
                Destroy(monster.player);
                //รอทำเรื่องplayer
                monster.hasShoot = true;
                Destroy(gameObject);
            }
            if (shoot.collider.CompareTag("WallY_under") || shoot.collider.CompareTag("WallY_on") || shoot.collider.CompareTag("WallX_left") || shoot.collider.CompareTag("WallX_right"))
            {
                Destroy(gameObject);
                monster.hasShoot = true;
            }
            if (shoot.collider.CompareTag("monster"))
            {
                Destroy(gameObject);
                monster.hasShoot = true;
            }
        }
    }
}
    
       