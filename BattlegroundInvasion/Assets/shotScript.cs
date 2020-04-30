using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
    }

    public int damage = 1;
    public bool isEnemyShot = false;

    // Update is called once per frame
    void Update()
    {

    }
}
