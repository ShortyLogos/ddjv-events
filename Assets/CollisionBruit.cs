using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBruit : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.layer == LayerMask.NameToLayer("Projectile") || collision.gameObject.layer == LayerMask.NameToLayer("Player")))
        {
            EventManager.TriggerEvent("bruit", new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
        }
        // Si on veut passer de multiples données, on doit faire une struct
    }
}
