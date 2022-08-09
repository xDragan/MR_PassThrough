using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{

    [Header("XRRAYCAST for hitting point")]
    [SerializeField] XRRaycast raycast; //just right controller will instantiate

    [Header("TV")]
    [SerializeField] GameObject playButton;
    [SerializeField] VideoPlayer video;

    [Header("Instantiate")]
    [SerializeField] GameObject[] prefab;
    private GameObject activePrefab;
    private int prefabIDInstantiate;

    [Header("Warning Text")]
    [SerializeField] TextMeshProUGUI warningText;
    [SerializeField] Color warningCol;
    bool warningActive ;


    private void Start()
    {
        //warningText.gameObject.SetActive(false);
        warningText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        warningActive = false;
        prefabIDInstantiate = -1;
    }

    public void PlayVideo()
    {
        Debug.LogWarning("PLAY VIDEOO");
        video.Play();
        playButton.SetActive(false);
    }

    public void SelectPrefab(int i)
    {
        prefabIDInstantiate = i;
        Debug.LogWarning("SETTED PREFAB " + i);
    }

    public void InstantiatePrefab()
    {
        Debug.LogWarning("instantiating prefab " + prefabIDInstantiate);
        activePrefab = Instantiate(prefab[prefabIDInstantiate],raycast.CheckRaycast() + Vector3.up ,Quaternion.identity);
    }

    public void CleanActivePrefab()
    {
        Destroy(GameObject.FindGameObjectWithTag("Prefab"));
    }

    public void RotateActivePrefab(Vector2 rot)
    {

        if (activePrefab != null)
            activePrefab.transform.Rotate(0.0f, rot.x, 0.0f);
    }

    public void StopRotation()
    {
        activePrefab.transform.Rotate(Vector3.zero);
    }

    public void ShowWarning() //not use
    {
        if(!warningActive)
        {
            warningText.gameObject.SetActive(true);
            StartCoroutine(FadeWarning());
        }
    }

    IEnumerator FadeWarning() // not use
    {
        warningActive = true;
        warningText.color = warningCol;

        var startCol = warningText.color;
        var finalCol = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        float t = 0;

        while (t < 1)
        {
            warningText.color = Color.Lerp(startCol, finalCol, t);
            t += Time.deltaTime;
            yield return null;
        }

        warningText.color = finalCol;
    }


    public void ChangePrefabColors()
    {
        if(activePrefab != null)
            activePrefab.GetComponent<ColorChange>().ChangeColor();
    }

    public void ChangeColor()
    {
        
        GetComponentInChildren<SpriteRenderer>().color = RandomColor();
        Debug.LogWarning("CHANGECOLOR");
    }

    Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}
