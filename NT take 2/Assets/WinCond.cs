using UnityEngine;

public class WinCond : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("Win!!!!");
            Debug.Log(GetComponent<Animator>().GetBool("winning"));
            GetComponent<Animator>().SetBool("winning", true);
            Debug.Log(GetComponent<Animator>().GetBool("winning"));
            //Time.timeScale = 0.0f;
        }
    }
}
