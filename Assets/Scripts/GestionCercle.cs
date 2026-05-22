using UnityEngine;

public class GestionCercle : MonoBehaviour
{
    public GameObject spawn;
    bool isVise;
     public GestionCercleVise viser;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Respawn")
        {
            Cacher(collision.gameObject.tag);
        }
    }

    public void Cacher(string tag)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition; //fait un lien avec 

        float centreX = spawn.transform.position.x;
        float centreY = spawn.transform.position.y;
        float moitieLongueurX = spawn.transform.localScale.x / 2; //scale a partir du parent
        float nouveauX = Random.Range(centreX - moitieLongueurX, centreX + moitieLongueurX);

        transform.position = new Vector2(nouveauX, centreY);

        float delaiGeneration = 0f;

        if (tag == "Player")
        {
            if (viser.VerifierCercle(GetComponent<SpriteRenderer>().color))
            {
                Camera.main.backgroundColor = Color.green;
                delaiGeneration = Random.Range(1f, 5f);
                GetComponent<SpriteRenderer>().color = Random.ColorHSV(); //similaire a Random.Range mais choisi aleatoirement la couleur
                viser.ChoisirCercleViser();
            }
            else
            {
                Camera.main.backgroundColor = Color.red;
            }
        } else if (tag == "Respawn")
        {
            if (!viser.VerifierCercle(GetComponent<SpriteRenderer>().color))
            {
                delaiGeneration = Random.Range(1f, 5f);
                GetComponent<SpriteRenderer>().color = Random.ColorHSV(); //similaire a Random.Range mais choisi aleatoirement la couleur
            }
        }

        Invoke("Reapparaitre", delaiGeneration);
    }

    void Reapparaitre()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
