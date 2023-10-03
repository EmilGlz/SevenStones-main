using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] float videoTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds( videoTime );
        SceneManager.LoadScene(1);
    }
}
