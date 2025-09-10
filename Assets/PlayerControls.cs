using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float boundX = 8.0f;   // Limite m�ximo e m�nimo horizontal
    public float boundY = 2.25f;  // Limite m�ximo e m�nimo vertical
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Pega a posi��o do mouse na tela e converte para coordenadas do mundo do Unity
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Pega a posi��o atual da raquete
        var pos = transform.position;

        // Atualiza a posi��o da raquete com base no mouse
        pos.x = mousePos.x;
        pos.y = mousePos.y;

        // Limita a raquete dentro da �rea do jogo
        if (pos.x > boundX) pos.x = boundX;
        else if (pos.x < -boundX) pos.x = -boundX;

        if (pos.y > 0) pos.y = 0;
        else if (pos.y < -boundY) pos.y = -boundY;

        // Aplica a posi��o calculada
        transform.position = pos;
    }
}
