using System.Collections.Generic;
using UnityEngine;

public class PuzzleCellLogic : MonoBehaviour //��������� ����� � ����� ������, ������� ����� �������������� ������� �������
{
    [SerializeField] private GameObject _samplePiece; //��������� ���������� ��������� ����� ��� ������
    [SerializeField] private int _squareNumber;

    public bool _isRightPiece;
    private List<GameObject> _colliders = new List<GameObject>();
    private int _pieceIndex = -1;
    private bool _isPieceReleased;

    private void Update() //����� Update ���������� ������ ����, ��� �������� 60 ��� � �������
    {
        if (_pieceIndex == _squareNumber & _colliders.Count == 1 & _isPieceReleased) //���� ���� �������� � ������
            _isRightPiece = true; //���� ������ �������� ����������
        else
            _isRightPiece = false; //����� - ������
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PuzzlePiece")
        {
            _pieceIndex = collision.gameObject.GetComponent<PuzzlePieceLogic>().pieceIndex;
            _isPieceReleased = collision.gameObject.GetComponent<PuzzlePieceLogic>()._isPieceReleased;

            if (!_colliders.Contains(collision.gameObject))
                _colliders.Add(collision.gameObject);

            if (_colliders.Count <= 1 & _isPieceReleased)
                collision.gameObject.transform.position = transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _colliders.Remove(collision.gameObject);
    }
}
