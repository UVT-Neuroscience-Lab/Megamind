using Gtec.UnityInterface;
using System;
using UnityEngine;
using static Gtec.UnityInterface.BCIManager;

public class ClassSelectionAvailableExample : MonoBehaviour
{
    private uint _selectedClass = 0;
    private bool _update = false;
    private PlayerControl _playerControl;
    void Start()
    {
        //attach to class selection available event
        BCIManager.Instance.ClassSelectionAvailable += OnClassSelectionAvailable;
        //_playerControl = GameObject.FindObjectOfType<PlayerControl>();
        _playerControl = Camera.main.transform.parent.GetComponent<PlayerControl>();
    }

    void OnApplicationQuit()
    {
        //detach from class selection available event
        BCIManager.Instance.ClassSelectionAvailable -= OnClassSelectionAvailable;
    }

    void Update()
    {

        //TODO ADD YOUR CODE HERE
        if(_update)
        {
            switch (_selectedClass)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2: //left
                    Debug.Log("Looking left!");
                    _playerControl.Rotate(-1f);

                    break;
                case 3: //forward
                    Debug.Log("Looking up!");
                    _playerControl.Forward(1f);
                    break;
                case 4: //right
                    Debug.Log("Looking right!");
                    _playerControl.Rotate(1f);
                    break;
                case 5:
                    break;
                case 6:
                    break;

            }
            _update = false;
        } 
    }

    /// <summary>
    /// This event is called whenever a new class selection is available. Th
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClassSelectionAvailable(object sender, EventArgs e)
    {
        ClassSelectionAvailableEventArgs ea = (ClassSelectionAvailableEventArgs)e;
       _selectedClass = ea.Class;
        _update = true;
        Debug.Log(string.Format("Selected class: {0}", ea.Class));
    }
}
