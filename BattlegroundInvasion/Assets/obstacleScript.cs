using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
      rigidbodyComponent = this.GetComponent<Rigidbody2D>();
      screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);


    // Update is called once per frame
    void Update()
    {
      movement = new Vector2( speed.x * direction.x, speed.y * direction.y);
      Destroy(this.gameObject, 4);
      // if(transform.position.x < screenBounds.x * 2)
      // {
      //     Destroy(this.gameObject, 3);
      // }
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null)
          rigidbodyComponent = GetComponent<Rigidbody2D>();

        rigidbodyComponent.velocity = movement;
    }
}
