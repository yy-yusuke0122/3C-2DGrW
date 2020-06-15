using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject Base;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(enemy.transform.position.x>Base.transform.position.x)
            SceneManager.LoadScene("Result");
    }
}
