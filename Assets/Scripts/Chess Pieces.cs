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
        CreateChessPiece(7, 7, ChessPieceType.Rook, ChessPieceColor.Black);
        for (int i = 0; i < 8; i++)
        {
            CreateChessPiece(6, i,ChessPieceType.Pawn, ChessPieceColor.Black);
        }
    }


    private void CreateChessPiece(int row, int col, ChessPieceType type, ChessPieceColor color)
    {
        Vector3 position = GetTileCenter(int row, int col);
        GameObject pieceObject = Instantiate(chessPiecePrefab, position, Quaternion.identity) as GameObject;
        ChessPiece piece = pieceObject.GetComponent<ChessPiece>();
        piece.Setup(type, color);
        chessPieces[row, col] = piece;
        piece.SetPosition(row, col);
    }
    // Update is called once per frame
    private Vector3 GetTileCenter(int row, int col)
    {
        Vector3 position - new Vector3();
        position.x = col * tileSize + tileSize / 2.0f;
        position.y = 0;
        position.z = row * tileSize + tileSize / 2.0f;
        position += boardOffset;
        return position;
    }

    public void SelectPiece(ChessPiece piece)
    {
        selectedPiece = piece;
        foreach (var move in selectedPiece.GetValidMoves())
        {
            Vector3 position = GetTileCenter(move.row, move.col);
            GameObject square = Instantiate(selectedSquarePrefab, position, Quaternion.identity) as GameObject;
            selectedSquares.Add(square);
        }
    }

    public void DeselectPiece()
    {
        selectedPiece = null;
        foreach (var square in selectedSquares)
        {
            Destroy(square);
        }
        selectedSquares.Clear();
    }

    public void MovePiece(ChessPiece piece, int row, int col)
    {
        chessPieces[piece.GetCurrentRow(), piece.GetCurrentCol()] = null;
        chessPieces[row, col] = piece;
        piece.SetPosition(row, col);
        SnapToGrid(piece.transform);
        DeselectPiece();
    }

    void Update()
    {
        if (selectedPiece != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.RayCast(ray, out hit))
                {
                    int row = (int)(hit.point.z - boardOffset.z) / (int)tileSize;
                    int col = (int)(hit.point.x - boardOffset.x) / (int)tileSize;
                    if (selectedPiece.IsValidMove(row, col))
                    {
                        MovePiece(selectedPiece, row, col);
                    }
                }
            }
        }
    }
}
