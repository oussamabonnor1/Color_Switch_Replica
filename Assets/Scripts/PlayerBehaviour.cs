using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public int jumpingForce;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyedPrefab;
    string currentColor;

    void Start()
    {
        int index = Random.Range(0, 4);
        currentColor = setColor(index);
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
            setColor(other.GetComponent<PowerUpBehaviour>().colorIndex);
            Destroy(other.gameObject);
        }
        else
        {
            if (other.gameObject.tag != currentColor)
            {
                //Instantiate(destroyedPrefab, transform.position, Quaternion.identity);
                StartCoroutine(cameraJig());
                spriteRenderer.enabled = false;
            }
        }
    }

    IEnumerator cameraJig()
    {
        Camera.main.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    string setColor(int index)
    {
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
