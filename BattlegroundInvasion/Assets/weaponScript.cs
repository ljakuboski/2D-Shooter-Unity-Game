using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{

  public Transform shots;
  public float shootingRate = 5;
  private float shootCooldown;

  void Start()
  {
    shootCooldown = 0;
  }

  void Update()
  {
    if (shootCooldown > 0)
    {
      shootCooldown -= Time.deltaTime;
    }
  }

  public void Attack(bool isEnemy)
  {
    // if (CanAttack)
    // {
      shootCooldown = shootingRate;

      // Create a new shot
      var shotTransform = Instantiate(shots) as Transform;

      // Assign position
      shotTransform.position = transform.position;

      // The is enemy property
      shotScript shot = shotTransform.gameObject.GetComponent<shotScript>();
      if (shot != null)
      {
        shot.isEnemyShot = isEnemy;
      }

      // Make the weapon shot always towards it
      bulletMoveScript move = shotTransform.gameObject.GetComponent<bulletMoveScript>();
      if (move != null)
      {
        move.direction = this.transform.right; // towards in 2D space is the right of the sprite
      }
    // }
  }

  public bool CanAttack
  {
    get
    {
      return shootCooldown <= 0;
    }
  }
}
