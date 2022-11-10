using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lanceur : MonoBehaviour
{
    private Rigidbody2D rig;
    private float vitesseLancer = 2.0f;
    private UnityAction<object> lancer; // On ne sait pas d'avance le type d'objet qu'on reçoit, donc on passe le générique 'object' qui est équivalent à void* en C/C++
    public Transform boulette;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        lancer = new UnityAction<object>(LancerBoulette);
    }

    private void OnEnable()
    {
        EventManager.StartListening("bruit", lancer);
    }

    private void OnDisable()
    {
        EventManager.StopListening("bruit", lancer);
    }

    void LancerBoulette(object data)
    {
        Vector2 source = (Vector2)data; // Le type de l'objet est inconnu au moment de la réception, équivalent de void* en C/C++
        Vector2 direction = source - new Vector2(transform.position.x, transform.position.y); // Retourne le vecteur directionnel vers lequel le garde doit se diriger

        Lancer(direction.normalized);
    }

    public void Lancer(Vector2 direction)
    {
        Vector3 delta = new Vector3(direction.x, direction.y, 0.0f);
        Transform projectile = Instantiate(boulette, (this.transform.position + delta), Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * vitesseLancer, ForceMode2D.Impulse);
    }
}
