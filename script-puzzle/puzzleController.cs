using UnityEngine;
using System.Collections.Generic;

public class PuzzleController : MonoBehaviour
{
    public Transform[] puzzlePieces; 
    public float moveSpeed = 100000f; 
    private Transform selectedPiece; 
    private Dictionary<string, Vector2> correctPositions;
    public float snapDistance = 0.1f; 

    void Start()
    {
        // Mezcla las piezas del rompecabezas al inicio del juego
        ShufflePuzzlePieces();

        // Inicializar el diccionario de posiciones correctas
        correctPositions = new Dictionary<string, Vector2>();

       
        correctPositions["Parte 1"] = new Vector2(-11.0084f, 2.2857f);
        correctPositions["Parte 2"] = new Vector2(-5.88f, 2.2636f);
        correctPositions["parte 4"] = new Vector2(-11.01f, -2.9304f);
        correctPositions["Parte_3"] = new Vector2(-5.86f, -2.96f);
    }

    void Update()
    {
        // Manejar el movimiento de la pieza del rompecabezas seleccionada por el jugador
        HandlePieceMovement();
        // Verificar la distancia entre cada pieza y su posición correcta en el fondo
        foreach (Transform piece in puzzlePieces)
        {
            if (!correctPositions.ContainsKey(piece.gameObject.name))
            {
                continue;
            }

            float distanceToCorrectPosition = Vector2.Distance(piece.position, correctPositions[piece.gameObject.name]);
            
            if (distanceToCorrectPosition < snapDistance)
            {
                piece.position = correctPositions[piece.gameObject.name];
            }
        }
    }

    void ShufflePuzzlePieces()
    {
        // Mezcla las posiciones de las piezas del rompecabezas
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            int randomIndex = Random.Range(i, puzzlePieces.Length);
            Transform temp = puzzlePieces[randomIndex];
            puzzlePieces[randomIndex] = puzzlePieces[i];
            puzzlePieces[i] = temp;
        }

        // Coloca las piezas del rompecabezas en posiciones aleatorias
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i].position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);

            // Aleatoriamente, establece algunas piezas como volteadas
            if (Random.Range(0, 2) == 1)
            {
                puzzlePieces[i].Rotate(Vector3.forward * 180); 
            }
        }
    }

    void HandlePieceMovement()
    {
       
        if (selectedPiece != null)
        {
            Vector2 moveDirection = Vector2.zero;

            
            if (Input.GetKey(KeyCode.W))
                moveDirection += Vector2.up * moveSpeed;
            if (Input.GetKey(KeyCode.S))
                moveDirection += Vector2.down * moveSpeed;
            if (Input.GetKey(KeyCode.A))
                moveDirection += Vector2.left * moveSpeed;
            if (Input.GetKey(KeyCode.D))
                moveDirection += Vector2.right * moveSpeed;

            
            if (Input.GetKeyDown(KeyCode.Q))
                selectedPiece.Rotate(Vector3.forward * 90);
            if (Input.GetKeyDown(KeyCode.E))
                selectedPiece.Rotate(Vector3.forward * -90);

            
            selectedPiece.position += (Vector3)moveDirection * Time.deltaTime;
        }
    }

    public void SelectPiece(Transform piece)
    {
        
        selectedPiece = piece;
    }

    public void DeselectPiece()
    {
        // Deseleccionar la pieza del rompecabezas
        selectedPiece = null;
    }
}

