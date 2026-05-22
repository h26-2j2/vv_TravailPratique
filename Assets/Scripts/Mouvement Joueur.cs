using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementJoueur : MonoBehaviour
{
    public InputAction actionDeplacement;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    Collider2D collider;

    public bool peutBouger = true;
    Vector2 positionDepart;
    Vector2 deplacementEnCours;
    public float vitesseDeplacement;
    public float directionDeplacement;
    void Start()
    {
        positionDepart = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        collider = GetComponent<Collider2D>();
    }
    void OnEnable()
    {
        actionDeplacement.Enable();
    }

    void OnDisable()
    {
        actionDeplacement.Disable();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {

        if (directionDeplacement < 0)
        {
            sr.flipX = true;
        }
        else if (directionDeplacement > 0)
        {
            sr.flipX = false;
        }
    }

    void FixedUpdate()
    {
           if (peutBouger)
        {
            directionDeplacement = actionDeplacement.ReadValue<float>();

            if(directionDeplacement != 0)
            {
                rb.linearVelocityX = directionDeplacement * vitesseDeplacement;
            }
            float vitesseAbsolue = Mathf.Abs(rb.linearVelocityX);
            anim.SetFloat("vitesse", vitesseAbsolue);

        }
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
