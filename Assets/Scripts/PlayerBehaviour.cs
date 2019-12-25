using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int jumpingForce;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyedPrefab;
    string currentColor;

    void Start()
    {
        currentColor = setStartColor();
    }

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
            if (other.gameObject.tag != currentColor)
            {
                Instantiate(destroyedPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    string setStartColor()
    {
        int index = Random.Range(0, 3);
        switch (index)
        {
            case 0:
                spriteRenderer.color = Color.cyan;
                return "blue";
            case 1:
                spriteRenderer.color = Color.yellow;
                return "yellow";
            case 2:
                spriteRenderer.color = Color.magenta;
                return "purple";
            case 3:
                spriteRenderer.color = new Color(255,0,125);
                return "pink";
        }
        return "blue";
    }
}
