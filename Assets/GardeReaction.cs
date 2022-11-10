using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GardeReaction : MonoBehaviour
{
    private UnityAction<object> reactionBruit; // On ne sait pas d'avance le type d'objet qu'on reçoit, donc on passe le générique 'object' qui est équivalent à void* en C/C++
    private Rigidbody2D rig;

    private float vitesse = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        reactionBruit = new UnityAction<object>(ReactionBruit);
    }

    private void OnEnable()
    {
        EventManager.StartListening("bruit", reactionBruit);
    }

    private void OnDisable()
    {
        EventManager.StopListening("bruit", reactionBruit);
    }

    void ReactionBruit(object data)
    {
        Vector2 source = (Vector2)data; // Le type de l'objet est inconnu au moment de la réception, équivalent de void* en C/C++
        Vector2 direction = source - new Vector2(transform.position.x, transform.position.y); // Retourne le vecteur directionnel vers lequel le garde doit se diriger

        rig.AddForce(direction.normalized * vitesse, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
