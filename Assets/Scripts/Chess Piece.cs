using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChessPieceType { King, Queen, Rook, Bishop, Knight, Pawn }
public enum ChessPieceColor { White, Black }

public class ChessPiece : MonoBehaviour
{
    public ChessPieceType type;
    public ChessPieceColor color;
    public int currentRow;
    public int currentCol;
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = GetWorldPosition(currentRow, currentCol);
    }

    private Vector3 GetWorldPosition(int row, int col)
    {
        float x = col * GameManager.instance.chessBoard.tileSize + GameManager.instance.chessBoard.boardOffset.x;
        float z = row * GameManager.instance.chessBoard.tileSize + GameManager.instance.chessBoard.boardOffset.z;
        return new Vector3(x, 0 ,z);
    }

    // Update is called once per frame
    public List<Vector2Int> GetValidMoves()
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        return validMoves;
    }
}
