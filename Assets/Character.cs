using System;
using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    private int _speed = 20;
    private int _rotationSpeed = 500;

    public void MoveTo(Vector3 targetPosition, Action onArrived)
    {
        StartCoroutine(MoveToCoroutine(targetPosition, onArrived));
    }

    private IEnumerator MoveToCoroutine(Vector3 targetPosition, Action onArrived)
    {
        while (GetDistance(transform.position, targetPosition) > 0.1f)
        {
            Vector3 newPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * _speed);

            yield return null;
        }

        onArrived();
    }

    private float GetDistance(Vector3 firstPosition, Vector3 secondPosition)
    {
        return (float)Math.Pow(firstPosition.x - secondPosition.x, 2) + (float)Math.Pow(firstPosition.z - secondPosition.z, 2);
    }

    public void RotateTo(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
    }
}
