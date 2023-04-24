using UnityEngine;
using System.Collections.Generic;

public class ChessPiece : MonoBehaviour
{
        public ChessSquare currentSquare;

        void Start()
        {
            currentSquare = GetComponentInParent<ChessSquare>();
        }

        void Update()
        {
            transform.LookAt(Camera.main.transform);
        }

        public void MoveToSquare(ChessSquare targetSquare);
        {
            transform.position = targetSquare.transform.position;

            currentSquare = targetSquare;
        }

        void OnTriggerEnter(Collider other)
        {
            ChessSquare square = ither.GetComponent<ChessSquare>();
            if (square != null)
            {
                MoveToSquare(square)
            }
        }
}
    