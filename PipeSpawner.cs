using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heghtRange = 0.45f;
    [SerializeField] private GameObject _pipe;

    private float _timer;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPose = transform.position + new Vector3(0, Random.Range(_heghtRange, _heghtRange));
        GameObject pipe = Instantiate(_pipe, spawnPose, Quaternion.identity);
        Destroy(_pipe, 10f);
    }
}