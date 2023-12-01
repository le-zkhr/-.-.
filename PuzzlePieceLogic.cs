using UnityEngine;

public class PuzzlePieceLogic : MonoBehaviour
{
    [SerializeField] private float _distance = 10f;
    [SerializeField] private int _pieceIndex;
    [SerializeField] private bool _isForQuest2;

    [HideInInspector]
    public int pieceIndex;
    public bool _isPieceReleased = true;

    private void Awake()
    {
        if(!_isForQuest2)
            pieceIndex = _pieceIndex;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        { gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0; _isPieceReleased = true; }
    }

    private void OnMouseDrag()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        _isPieceReleased = false;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}