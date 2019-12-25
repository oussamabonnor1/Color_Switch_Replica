using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int jumpingForce;
    public Rigidbody2D rb;
    public GameObject destroyedPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpingForce;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PowerUp")
        {

        }
        else
        {
            if (other.gameObject.tag != gameObject.tag)
            {
                Instantiate(destroyedPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
