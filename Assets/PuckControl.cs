using UnityEngine;

public class PuckControl : MonoBehaviour
{

    private Rigidbody2D rb2d;

    void GoPuck()
    {
        float rand = Random.Range(0, 2);
        if(rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoPuck", 2);
    }

    void OnCollissionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.y = rb2d.linearVelocity.y;
            vel.x = (rb2d.linearVelocity.x / 2) + (coll.collider.attachedRigidbody.linearVelocity.x / 3);
            rb2d.linearVelocity = vel;
        }
    }

    void ResetPuck()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetPuck();
        Invoke("GoPuck", 1);
    }
}
