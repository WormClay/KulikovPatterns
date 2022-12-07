using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Memento
{
    public class TimeBodyController : MonoBehaviour
    {
        [SerializeField] TimeBody _timeBodyPrefab;
        private bool _isExistTimeBody = false;
        private TimeBody _timeBody;
        void Start()
        {   
            if (_timeBodyPrefab != null) _timeBody = Instantiate(_timeBodyPrefab, transform.position, Quaternion.identity, transform);
            if (_timeBody != null) _isExistTimeBody = true;
        }
        private void Update()
        {
            if (_isExistTimeBody)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _timeBody.StartRewind();
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    _timeBody.StopRewind();
                }
            }
        }
    } 
}
