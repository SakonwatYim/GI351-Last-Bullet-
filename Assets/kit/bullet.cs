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
        //raycast�ա���Oncollition���� raycast��Ǩ�Ѻ����鹵ç(����鹴�����ѹ���ѧ�Ъ����) ������collider��ǨcompareTag����ѹⴹ���� 
        //������ѹ��Oncollition�ѹ�е�Ǩ�Ѻ����������С���ع�Թ�ҧ�Ƿ������������������
        transform.position += monster.distance_direction.normalized * (100 * Time.deltaTime);
        if (Physics.Raycast(transform.position, monster.distance_direction, out RaycastHit shoot, speed *Time.deltaTime))
        {
            if (shoot.collider.CompareTag("Player"))
            {
                Destroy(monster.player);
                //�ͷ�����ͧplayer
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
    
       