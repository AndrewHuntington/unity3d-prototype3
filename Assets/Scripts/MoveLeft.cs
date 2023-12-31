using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveLeft : MonoBehaviour
{
  private float speed = 30;
  private PlayerController playerControllerScript;
  private float leftBound = -15;

  // Start is called before the first frame update
  void Start()
  {
    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!playerControllerScript.gameOver)
    {
      transform.Translate(speed * Time.deltaTime * Vector3.left);
    }

    if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
    {
      Destroy(gameObject);
    }
  }
}
