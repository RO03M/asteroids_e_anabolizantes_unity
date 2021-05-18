using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject tirinho_foda;

    public float speed = 10;

    void Start() {

    }

    void Update() {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoY = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, eixoY, 0);
        transform.position += direcao * speed * Time.deltaTime;

        LookAtMouse();
        TaForaDaTela();

        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }

    }

    public void TaForaDaTela() {
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

    public void LookAtMouse() {
        Vector2 mouse_pos = Input.mousePosition;
        mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        Vector2 player_pos = this.transform.position;
        Vector2 delta = player_pos - mouse_pos;
        float angle = Mathf.Atan2(delta.x, delta.y);
        angle *= Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle * -1));
    }

    public void Shoot() {
        GameObject tirinho_clone = Instantiate(tirinho_foda, transform.position, Quaternion.identity);
        tirinho_clone.GetComponent<Tirinho>().direcao = this.transform.eulerAngles.z;
    }

}