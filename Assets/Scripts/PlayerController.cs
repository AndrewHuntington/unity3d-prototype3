using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Animator playerAnim;
  private Rigidbody playerRb;
  public float jumpForce = 10;
  public float gravityModifier;
  public bool isOnGround = true;
  public bool gameOver = false;

  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    playerAnim = GetComponent<Animator>();
    Physics.gravity *= gravityModifier;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
    {
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
      playerAnim.SetTrigger("Jump_trig");
    }
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Ground"))
    {
      isOnGround = true;
    }
    else if (other.gameObject.CompareTag("Obstacle"))
    {
      Debug.Log("Game Over");
      gameOver = true;
    }

  }
}
