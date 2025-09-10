using UnityEngine;

public class IA : MonoBehaviour
{
    // Limite m�ximo e m�nimo no eixo X (horizontal)
    public float boundX = 8.0f;

    // Limite m�ximo e m�nimo no eixo Y (vertical)
    public float boundY = 2.25f;

    // Velocidade de movimento da IA
    public float moveSpeed = 3.0f;

    // Dire��o atual do movimento (um vetor 2D com X e Y)
    private Vector2 direction;

    // Start � chamado uma vez quando o objeto � iniciado
    void Start()
    {
        // Escolhe uma dire��o inicial aleat�ria
        EscolherNovaDirecao();
    }

    // Update � chamado uma vez por frame (60+ vezes por segundo)
    void Update()
    {
        // Move o objeto na dire��o escolhida
        // Multiplicado por moveSpeed para controlar a velocidade
        // Multiplicado por Time.deltaTime para que o movimento seja igual em todos os PCs (independente do FPS)
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Guarda a posi��o atual
        var pos = transform.position;

        // Se passar do limite no eixo X...
        if (pos.x > boundX || pos.x < -boundX)
        {
            // Inverte a dire��o no eixo X (faz a IA "quicar" na parede)
            direction.x *= -1;

            // Garante que a posi��o n�o passe do limite
            pos.x = Mathf.Clamp(pos.x, -boundX, boundX);
        }

        // Se passar do limite no eixo Y...
        if (pos.y > boundY || pos.y < 0)
        {
            // Inverte a dire��o no eixo Y
            direction.y *= -1;

            // Corrige a posi��o dentro do limite
            pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
        }

        // Atualiza a posi��o do objeto com os valores corrigidos
        transform.position = pos;
    }

    // Fun��o para escolher uma dire��o aleat�ria
    void EscolherNovaDirecao()
    {
        // Cria um vetor aleat�rio com valores entre -1 e 1
        // Normalizado (normalized) garante que a velocidade seja sempre a mesma,
        // mesmo se estiver indo na diagonal
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
