/*
 * Ian Connors
 * Prototype 4
 * Handles game state and scene loading
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject LoseText;
    private static GameObject WinText;
    private GameObject InstructionText;
    public static bool gameOver = false;
    private bool instructionsShowing = true;
    // Start is called before the first frame update
    void Start()
    {
        LoseText = GameObject.FindGameObjectWithTag("LoseText");
        WinText = GameObject.FindGameObjectWithTag("WinText");
        InstructionText = GameObject.FindGameObjectWithTag("InstructionText");
        LoseText.SetActive(false);
        WinText.SetActive(false);
    }

    // Update is called once per frame
    public static void Lose()
	{
        LoseText.SetActive(true);
        gameOver = true;
	}
    public static void Win()
    {
        WinText.SetActive(true);
        gameOver = true;
    }
    private void Update()
	{
        if (instructionsShowing && Input.GetKeyDown(KeyCode.Space))
		{
            InstructionText.SetActive(false);
            instructionsShowing = false;
		}
		if (gameOver && Input.GetKeyDown(KeyCode.R))
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
