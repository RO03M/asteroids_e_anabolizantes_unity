using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {

    public GameObject m_asteroid_prefab;
    public int asteroid_quantity = 20;

    Vector2 start_screen_coords;
    Vector2 end_screen_coords;

    void Start() {
        start_screen_coords = Camera.main.ScreenToWorldPoint(Vector2.zero);
        end_screen_coords = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        for (int i = 0; i < asteroid_quantity; i++) {
            Vector2 temp_random_screen_position = new Vector2(Random.Range(start_screen_coords.x, end_screen_coords.x), Random.Range(start_screen_coords.y, end_screen_coords.y));
            GameObject temp_clone = Instantiate(m_asteroid_prefab, temp_random_screen_position, Quaternion.identity);
            temp_clone.name = "Asteroid";
        }
    }

}
