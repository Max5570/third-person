using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;

    private bool _open;
    private void Operate()
    {
        if (_open)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(transform.position.x, 1f, transform.position.z), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine));
        }
        else
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(transform.position.x, -.9f, transform.position.z), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine));
        }
        _open = !_open;
    }

    public void Activate() 
    {
        if (!_open)
        {
            _open = !_open;
            iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(transform.position.x, transform.position.y, -20.84f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine));
        }
    }

    public void Deactivate()
    {
        if (_open)
        {
            _open = !_open;
            iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(transform.position.x, transform.position.y, -23.22f), "time", 1.5f, "easetype", iTween.EaseType.easeInOutSine));
        }
    }
}