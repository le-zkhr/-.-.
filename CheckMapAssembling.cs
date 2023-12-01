//проверяет собрана ли карта
using UnityEngine;

public class CheckMapAssembling : MonoBehaviour
{
    [SerializeField] private GameObject _UIButtons;
    [SerializeField] private GameObject _darkBG;
    [SerializeField] private Animator _tabAnimations;

    public int _rightSquaresCount = 0, _rightPiecesAmount = 28;
    private bool _isAnimationPlayed = false;

    private void Update() //ìåòîä Update âûçûâàåòñÿ êàæäûé êàäð, ÷òî ïðèìåðíî 60 ðàç â ñåêóíäó
    {
        if (_rightSquaresCount == _rightPiecesAmount & !_isAnimationPlayed) //åñëè ÷èñëî ñîâïàäàþùèõ ïàçëîâ
            LaunchCompletingAnimation(); //ðàâíî ÷èñëó ÿ÷ååê, òî çàïóñêàåì ïîáåäíóþ àíèìàöèþ
        else
            CheckEquals(); //èíà÷å ïðîäîëæàåì ñâåðÿòü êîë-âî íóæíûõ ïàçëîâ ñ êîë-âîì ÿ÷ååê
    }

    private void CheckEquals() //â ýòîì ìåòîäå ïðîâåðÿåòñÿ êîë-âî ïðàâèëüíî ñòîÿùèõ ïàçëîâ
    {
        _rightSquaresCount = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++) //ýòîò öèêë ïðîõîäèòñÿ ïî âñåì îáúåêòàì ïàçëîâ
        {
            if (gameObject.transform.GetChild(i).GetComponent<PuzzleCellLogic>()._isRightPiece == true)
                _rightSquaresCount += 1; //è ïðîâåðÿåò, ÷òî åñëè íîìåð ÿ÷åéêè ñîâïàäàåò ñ íîìåðîì ïàçëà, òî
            //óâåëè÷èâàåì êîë-âî ïðàâèëüíî ñòîÿùèõ ïàçëîâ
        }
    }
    private void LaunchCompletingAnimation() //ýòîò ìåòîä çàïóñêàåò ïîáåäíóþ àíèìàöèþ
    {
        _UIButtons.SetActive(false);
        _darkBG.SetActive(true);

        _tabAnimations.Play("TabAppearing");
        Invoke("PlayIdle", 1f);

        _isAnimationPlayed = true;
    }
    private void PlayIdle() => _tabAnimations.Play("TabIdle");
}
