﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Vector2 speed = new Vector2(5, 5);
    public Vector2 direction = new Vector2(1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    // Update is called once per frame
    void Update()
    {
      movement = new Vector2( speed.x * direction.x, speed.y * direction.y);
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null)
          rigidbodyComponent = GetComponent<Rigidbody2D>();

        rigidbodyComponent.velocity = movement;
    }
}
