using UnityEngine;

public class CheckMapAssembling : MonoBehaviour
{
    [SerializeField] private GameObject _UIButtons;
    [SerializeField] private GameObject _darkBG;
    [SerializeField] private Animator _tabAnimations;

    public int _rightSquaresCount = 0, _rightPiecesAmount = 28;
    private bool _isAnimationPlayed = false;

    private void Update() //����� Update ���������� ������ ����, ��� �������� 60 ��� � �������
    {
        if (_rightSquaresCount == _rightPiecesAmount & !_isAnimationPlayed) //���� ����� ����������� ������
            LaunchCompletingAnimation(); //����� ����� �����, �� ��������� �������� ��������
        else
            CheckEquals(); //����� ���������� ������� ���-�� ������ ������ � ���-��� �����
    }

    private void CheckEquals() //� ���� ������ ����������� ���-�� ��������� ������� ������
    {
        _rightSquaresCount = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++) //���� ���� ���������� �� ���� �������� ������
        {
            if (gameObject.transform.GetChild(i).GetComponent<PuzzleCellLogic>()._isRightPiece == true)
                _rightSquaresCount += 1; //� ���������, ��� ���� ����� ������ ��������� � ������� �����, ��
            //����������� ���-�� ��������� ������� ������
        }
    }
    private void LaunchCompletingAnimation() //���� ����� ��������� �������� ��������
    {
        _UIButtons.SetActive(false);
        _darkBG.SetActive(true);

        _tabAnimations.Play("TabAppearing");
        Invoke("PlayIdle", 1f);

        _isAnimationPlayed = true;
    }
    private void PlayIdle() => _tabAnimations.Play("TabIdle");
}
