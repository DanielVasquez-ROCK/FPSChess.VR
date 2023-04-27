using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject chessPiece Prefab;
    public float tileSize = 1.0f;
    public Vector3 boardOffset = newVector3(-4.0f, 0.0f, -4.0f);
    private ChessPiece[,] chessPieces = new ChessPiece[8, 8];
    // Start is called before the first frame update
    void Start()
    {
        CreateChessPiece(0, 0, ChessPieceType.Rook, ChessPieceColor.White);
        CreateChessPiece(0, 1, ChessPieceType.Knight, ChessPieceColor.White);
        CreateChessPiece(0, 2, ChessPieceType.Bishop, ChessPieceColor.White);
        CreateChessPiece(0, 3, ChessPieceType.Queen, ChessPieceColor.White);
        CreateChessPiece(0, 4, ChessPieceType.King, ChessPieceColor.White);
        CreateChessPiece(0, 5, ChessPieceType.Bishop, ChessPieceColor.White);
        CreateChessPiece(0, 6, ChessPieceType.Knight, ChessPieceColor.White);
        CreateChessPiece(0, 7, ChessPieceType.Rook, ChessPieceColor.White);
        for (int i = 0; i < 8; i++)
        {
            CreateChessPiece(1, i, ChessPieceType.Pawn, ChessPieceColor.White);
            CreateChessPiece(6, i, ChessPieceType.Pawn, ChessPieceColor.Black);
        }
        CreateChessPiece(7, 0, ChessPieceType.Rook, ChessPieceColor.Black);
        CreateChessPiece(7, 1, ChessPieceType.Knight, ChessPieceColor.Black);
        CreateChessPiece(7, 2, ChessPieceType.Bishop, ChessPieceColor.Black);
        CreateChessPiece(7, 3, ChessPieceType.Queen, ChessPieceColor.Black);
        CreateChessPiece(7, 4, ChessPieceType.King, ChessPieceColor.Black);
        CreateChessPiece(7, 5, ChessPieceType.Bishop, ChessPieceColor.Black);
        CreateChessPiece(7, 6, ChessPieceType.Knight, ChessPieceColor.Black)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
