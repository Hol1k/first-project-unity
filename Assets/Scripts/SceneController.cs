using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;

    public float baseEnemySpeed = 3f;
    private float speed = 2f;

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDisable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Update()
    {
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(-2, 1, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            enemy.GetComponent<WanderingAI>().OnSpeedChanged(speed);
        }
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseEnemySpeed * value;
    }
}
