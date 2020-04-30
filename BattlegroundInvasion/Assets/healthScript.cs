using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    public int hp = 1;
    public bool isEnemy = true;

    public void Damage(int damageCount)
    {
      hp -= damageCount;

      if (hp <= 0)
        {
          Destroy(gameObject);
        }
      }


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
      shotScript shot = otherCollider.gameObject.GetComponent<shotScript>();
      if (shot != null)
      {
        if (shot.isEnemyShot != isEnemy)
        {

          scoreScript.scoreValue += 1;
          Damage(shot.damage);
          Destroy(shot.gameObject);
        }
      }
    }
}
