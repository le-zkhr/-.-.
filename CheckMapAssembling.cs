using UnityEngine;

public class CheckMapAssembling : MonoBehaviour
{
    [SerializeField] private GameObject _UIButtons;
    [SerializeField] private GameObject _darkBG;
    [SerializeField] private Animator _tabAnimations;

    public int _rightSquaresCount = 0, _rightPiecesAmount = 28;
    private bool _isAnimationPlayed = false;

    private void Update() //метод Update вызывается каждый кадр, что примерно 60 раз в секунду
    {
        if (_rightSquaresCount == _rightPiecesAmount & !_isAnimationPlayed) //если число совпадающих пазлов
            LaunchCompletingAnimation(); //равно числу ячеек, то запускаем победную анимацию
        else
            CheckEquals(); //иначе продолжаем сверять кол-во нужных пазлов с кол-вом ячеек
    }

    private void CheckEquals() //в этом методе проверяется кол-во правильно стоящих пазлов
    {
        _rightSquaresCount = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++) //этот цикл проходится по всем объектам пазлов
        {
            if (gameObject.transform.GetChild(i).GetComponent<PuzzleCellLogic>()._isRightPiece == true)
                _rightSquaresCount += 1; //и проверяет, что если номер ячейки совпадает с номером пазла, то
            //увеличиваем кол-во правильно стоящих пазлов
        }
    }
    private void LaunchCompletingAnimation() //этот метод запускает победную анимацию
    {
        _UIButtons.SetActive(false);
        _darkBG.SetActive(true);

        _tabAnimations.Play("TabAppearing");
        Invoke("PlayIdle", 1f);

        _isAnimationPlayed = true;
    }
    private void PlayIdle() => _tabAnimations.Play("TabIdle");
}
