using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Ensure this is included for TMP support

public class TicTacToeManager : MonoBehaviour
{
    public Button[] cells; // Assign the buttons in the Inspector
    private string[] board = new string[9];
    private string currentPlayer = "X";

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            int index = i;
            board[i] = "";
            // Use TMP_Text instead of Text for TextMeshPro
            cells[i].GetComponentInChildren<TMP_Text>().text = ""; // Reset button text
            cells[i].onClick.RemoveAllListeners();
            cells[i].onClick.AddListener(() => MakeMove(index));
            cells[i].interactable = true;
        }
        currentPlayer = "X"; // Start with player X
    }

    void MakeMove(int index)
    {
        if (board[index] != "")
            return;

        // Update board and UI
        board[index] = currentPlayer;
        // Use TMP_Text instead of Text for TextMeshPro
        cells[index].GetComponentInChildren<TMP_Text>().text = currentPlayer;
        cells[index].interactable = false;

        // Check for a winner or draw
        if (CheckWin(currentPlayer))
        {
            Debug.Log(currentPlayer + " wins!");
            EndGame();
            return;
        }
        if (CheckDraw())
        {
            Debug.Log("It's a draw!");
            EndGame();
            return;
        }

        // Switch turn
        currentPlayer = currentPlayer == "X" ? "O" : "X";

        // If the current player is "O" (AI), make its move
        if (currentPlayer == "O")
        {
            Invoke("AiMove", 0.5f); // Delay AI move a little for better experience
        }
    }

    void AiMove()
    {
        List<int> availableMoves = new List<int>();

        // Find available spots (empty cells)
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == "")
            {
                availableMoves.Add(i);
            }
        }

        // If there are available moves, pick a random one for the AI
        if (availableMoves.Count > 0)
        {
            int randomIndex = Random.Range(0, availableMoves.Count);
            MakeMove(availableMoves[randomIndex]);
        }
    }

    bool CheckWin(string player)
    {
        // Check rows, columns, and diagonals for a win
        return (board[0] == player && board[1] == player && board[2] == player) ||  // Row 1
               (board[3] == player && board[4] == player && board[5] == player) ||  // Row 2
               (board[6] == player && board[7] == player && board[8] == player) ||  // Row 3
               (board[0] == player && board[3] == player && board[6] == player) ||  // Column 1
               (board[1] == player && board[4] == player && board[7] == player) ||  // Column 2
               (board[2] == player && board[5] == player && board[8] == player) ||  // Column 3
               (board[0] == player && board[4] == player && board[8] == player) ||  // Diagonal 1
               (board[2] == player && board[4] == player && board[6] == player);    // Diagonal 2
    }

    bool CheckDraw()
    {
        // If all spots are filled and there's no winner, it's a draw
        foreach (var spot in board)
        {
            if (spot == "")
                return false;
        }
        return true;
    }

    void EndGame()
    {
        // Disable all buttons after game ends
        foreach (var button in cells)
        {
            button.interactable = false;
        }
    }
}
