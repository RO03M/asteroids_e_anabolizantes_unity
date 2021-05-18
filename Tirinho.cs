using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirinho : MonoBehaviour
{

    public float direcao;
    public float velocidade = 1;
    public float time_to_die = 5;

    Collider2D m_collider;

    void Start() {
        if (!(m_collider = this.GetComponent<Collider2D>())) m_collider = this.gameObject.AddComponent<CircleCollider2D>();
        direcao -= 90;
        Destroy(this.gameObject, time_to_die);
    }

    void Update() {
        transform.position += new Vector3(velocidade * Mathf.Cos(direcao * Mathf.Deg2Rad), velocidade * Mathf.Sin(direcao * Mathf.Deg2Rad), 0) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Asteroid") {
            collision.gameObject.GetComponent<Asteroid>().CreateChildren();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

}
