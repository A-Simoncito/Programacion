using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    private PuzzleController puzzleController;

    void Start()
    {
        // Obtener la referencia al PuzzleController
        puzzleController = FindObjectOfType<PuzzleController>();
    }

    void OnMouseDown()
    {
        // Seleccionar la pieza del rompecabezas clickeada por el jugador
        puzzleController.SelectPiece(transform);
    }
}