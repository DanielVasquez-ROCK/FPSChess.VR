
using UnityEngine;

public class Pawn : ChessPiece
{
    // Start is called before the first frame update
    void Start(){
        private bool hasMoved = false;

        public override bool IsValidMove(ChessSquare targetSquare)
        {
            Vector3 direction = targetSquare.transform.position - currentSquare.transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            if (angle > 45)
            {
                return false;
            }

            if (distance == 1)
            {

                int fileDistance = Mathf.Abs(targetSquare.file - currentSquare .file);
                if (fileDistance != 1)
                {
                    return false;
                }

                ChessPiece targetPiece = targetSquare.GetOccupyingPiece();
                if (targetPiece == null || targetPiece.isWhite == isWhite)
                {
                    return false;
                }
            }
            else
            {
                if (targetSquare.IsOccupied())
                {
                    return false;
                }
            }
            return true;
        }

        public override void MoveToSquare(ChessSquare targetSquare)
        {

            base.MoveToSquare(targetSquare);

            hasMoved = true;
        }
    }
}
