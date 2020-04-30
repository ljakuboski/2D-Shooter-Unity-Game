using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
  public GameObject bombPrefab;
  public float respawnTime = 1.5f;
  private Vector2 screenBounds;

  // Use this for initialization
  void Start () {
      screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
      StartCoroutine(bombingWave());
  }
  private void spawnEnemy(){
      GameObject obstacle = Instantiate(bombPrefab) as GameObject;
      obstacle.transform.position = new Vector2(screenBounds.x * -1, Random.Range(-screenBounds.y-5, screenBounds.y+1));
  }
  IEnumerator bombingWave(){
      while(true){
          yield return new WaitForSeconds(respawnTime);
          spawnEnemy();
      }
  }
}
