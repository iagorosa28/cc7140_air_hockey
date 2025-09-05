using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int PlayerScore1 = 0; // Pontua��o do player 1
    public static int PlayerScore2 = 0; // Pontua��o do player 2
    public GUISkin layout; // Fonte do placar
    GameObject thePuck; // Refer�ncia ao objeto bola

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePuck = GameObject.FindGameObjectWithTag("puck"); // Busca a refer�ncia da bola
    }

    public static void Score(string wallID)
    {
        if (wallID == "TopGol")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            thePuck.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            thePuck.SendMessage("ResetPuck", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            thePuck.SendMessage("ResetPuck", null, SendMessageOptions.RequireReceiver);
        }
    }
}
