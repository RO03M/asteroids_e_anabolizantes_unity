using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private LineRenderer line_renderer;

    public float velocity = 5;
    public float direction;
    public float size = 1;
    public int point_amount = 10;
    [Range(0, 1)] public float min_width = 0.2f;//width inside a circle with radius of one
    [Range(0, 1)] public float max_width = 1f;
    public float min_size = 0.2f;

    int asteroids_children = 2;

    void Start() {
        line_renderer = this.GetComponent<LineRenderer>();
        line_renderer.loop = true;
        line_renderer.positionCount = point_amount;
        direction = Random.Range(0, 359);
        velocity = Random.Range(0.2f, velocity);
        this.GetComponent<CircleCollider2D>().radius = size;
        ShapeCreation();
    }

    void Update() {
        transform.position += new Vector3(velocity * Mathf.Cos(direction * Mathf.Deg2Rad), velocity * Mathf.Sin(direction * Mathf.Deg2Rad), 0) * Time.deltaTime;
        Vector2 player_pos_to_screen = Camera.main.WorldToScreenPoint(this.transform.position);
        if (player_pos_to_screen.x > Screen.width) {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, player_pos_to_screen.y));
        } else if (player_pos_to_screen.x < -5) {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, player_pos_to_screen.y));
        }

        if (player_pos_to_screen.y > Screen.height) {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector2(player_pos_to_screen.x, 0));
        } else if (player_pos_to_screen.y < -5) {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector2(player_pos_to_screen.x, Screen.height));
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void ShapeCreation() {
        int angle_between_points = 360 / point_amount;
        int angle = 0;
        for (int i = 0; i < point_amount; i++, angle += angle_between_points) {
            float random_width = Random.Range(min_width, max_width);
            line_renderer.SetPosition(i, new Vector2(random_width * Mathf.Cos(angle * Mathf.Deg2Rad) * size, random_width * Mathf.Sin(angle * Mathf.Deg2Rad) * size));
        }
    }

    public void CreateChildren() {
        if (size / 2 < min_size) return;
        for (int i = 0; i < asteroids_children; i++) {
            GameObject clone = Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
            clone.GetComponent<Asteroid>().size = this.size / 2;
            clone.GetComponent<LineRenderer>().startWidth = this.GetComponent<LineRenderer>().startWidth / 2;
            clone.name = "Asteroid";
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        Vector3 other_pos = collision.gameObject.transform.position;
        Vector3 _pos = this.transform.position;

        Vector2 delta = _pos - other_pos;

        float angle_between = Mathf.Atan2(delta.x, delta.y);
        direction = -(angle_between * Mathf.Rad2Deg + 180);

    }

}
