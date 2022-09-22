using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float angleDeg;
    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;
    [SerializeField] Transform ball;
    [SerializeField] Camera camera;
    void Start() {
        Assert.IsNotNull(ball, "Ball ref required");
    }
    void Update() {
        angleDeg += angularSpeed * Time.deltaTime;
        radius += radialSpeed * Time.deltaTime;

        if (Mathf.Abs(radius) > camera.orthographicSize) {
            radialSpeed *= -1;
            radius = Mathf.Sign(radius) * camera.orthographicSize;
        }

        ball.position = PolarToCartesian(radius, angleDeg);
        Debug.DrawLine(Vector3.zero, ball.position, Color.red);
    }
    private Vector3 PolarToCartesian(float radius, float angle) {
        float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }
}
