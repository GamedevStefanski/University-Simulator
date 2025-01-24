using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneTransitionTrigger : MonoBehaviour
{
    public Animator fadeAnimator; // Animator odpowiedzialny za animacj� przyciemniania
    public string sceneToLoad; // Nazwa sceny, na kt�r� chcesz przej��
    private bool isTransitioning = false; // Zapobiega wielokrotnemu uruchomieniu

    private void OnTriggerEnter(Collider other)
    {
        if (isTransitioning) return;

        // Sprawd�, czy gracz wszed� w trigger
        if (other.CompareTag("Player"))
        {
            isTransitioning = true;
            StartCoroutine(LoadSceneWithFade());
        }
    }

    private IEnumerator LoadSceneWithFade()
    {
        // Uruchom animacj� przyciemniania
        fadeAnimator.SetTrigger("FadeOut");

        // Poczekaj na zako�czenie animacji
        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Za�aduj now� scen�
        SceneManager.LoadScene(sceneToLoad);
    }
}
