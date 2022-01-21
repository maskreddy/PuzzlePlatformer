using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask climbableLayer;
    private bool isClimbing;
    private bool tryingToClimb;
    private Rigidbody2D body;
    private Game game;
    private PortalController portalController;
    private void Start()
    {
        portalController = FindObjectOfType<PortalController>();
        body = GetComponent<Rigidbody2D>();
        game = FindObjectOfType<Game>();
        transform.position = portalController.GetSpawnPosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If we collided with a bad thing we'll die
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard"))
        {
            Die();
        }


        if (collision.gameObject.GetComponent<Portal>())
        {
            portalController.SetSpawnPortal(collision.gameObject.GetComponent<Portal>());
        }
    }

    private void Update()
    {
        tryingToClimb = Input.GetButton("ClimbUp") || Input.GetButton("ClimbUp");
    }

    private void FixedUpdate()
    {
        RaycastHit2D ladderRay = Physics2D.Raycast(transform.position, Vector2.up, 1f, climbableLayer);
        if (tryingToClimb)
        {
            isClimbing = ladderRay;
        }

        if (isClimbing)
        {
            body.gravityScale = 0;
            body.velocity = new Vector2(body.velocity.x, Input.GetAxisRaw("Vertical") * 4f);
        }

        if (!ladderRay)
        {
            body.gravityScale = 3f;
            isClimbing = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformEffector2D>() != null && Input.GetButtonDown("ClimbDown"))
        {
            isClimbing = true;
            StartCoroutine(FallThroughPlatform(collision.collider));
        }
    }

    IEnumerator FallThroughPlatform(Collider2D collider)
    {
        collider.enabled = false;
        yield return new WaitForSeconds(.5f);
        collider.enabled = true;
    }

    private void Die()
    {
        // When we die, remove a life from the game
        game.RemoveLife();
        // And load the first level
        SceneManager.LoadScene(0);
    }
}
