using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(15, 15);
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
      rigidbodyComponent = this.GetComponent<Rigidbody2D>();
      screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }



    // Update is called once per frame
    void Update()
    {
      float inputX = Input.GetAxis("Horizontal");
      float inputY = Input.GetAxis("Vertical");

      movement = new Vector2( speed.x * inputX, speed.y * inputY);

      bool shoot = Input.GetButtonDown("Fire1");

      if (shoot)
      {
        weaponScript weapon = GetComponent<weaponScript>();
        if (weapon != null)
        {
        // false because the player is not an enemy
        weapon.Attack(false);
        }
      }
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null)
          rigidbodyComponent = GetComponent<Rigidbody2D>();

        rigidbodyComponent.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      bool damagePlayer = false;

      // Collision with enemy
      obstacleScript enemy = collision.gameObject.GetComponent<obstacleScript>();
      if (enemy != null)
      {
        healthScript enemyHealth = enemy.GetComponent<healthScript>();
        if (enemyHealth != null)
          enemyHealth.Damage(enemyHealth.hp);
        damagePlayer = true;
      }

      coinScript coin = collision.gameObject.GetComponent<coinScript>();
      if (coin != null)
      {
        healthScript coinHealth = coin.GetComponent<healthScript>();
        if (coinHealth != null)
          coinHealth.Damage(coinHealth.hp);
          scoreScript.scoreValue += 5;
      }

    // Damage the player
      if (damagePlayer)
      {
        healthScript playerHealth = this.GetComponent<healthScript>();
        if (playerHealth != null)
        {
          playerHealth.Damage(1);
          SceneManager.LoadScene("GameOverScene");
        }
      }
    }
}
