using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SmokeController : MonoBehaviour
{
    public float engineRevs;
    public float exhaustRate;
    public float damage;
    public GameObject car;
    public CarController carController;
    public CarCollide carCollide;

    ParticleSystem exhaust;

    void Start() {
		car = this.transform.parent.parent.gameObject;
		carController = car.GetComponent<CarController>();
		carCollide = car.GetComponent<CarCollide>();
        exhaust = GetComponent<ParticleSystem>();
        exhaustRate = 3000;
    }

    void Update() {
        engineRevs = carController.Revs;
        damage = carCollide.damage;
		exhaust.emissionRate = engineRevs * exhaustRate;
        var col = exhaust.colorOverLifetime;
        Gradient grad = new Gradient();
        grad.SetKeys(
			//颜色
			new GradientColorKey[] { 
				new GradientColorKey(Color.white, 0.0f), 
				new GradientColorKey(new Color(139,69,19), 0.08f),
				new GradientColorKey(Color.white, 1.0f)
			},
			//透明度
            new GradientAlphaKey[] { 
				new GradientAlphaKey(0.0f, 0.0f), 
				new GradientAlphaKey(damage / 200f, 0.05f), 
				new GradientAlphaKey(0.0f, 1.0f) 
			});
        col.color = grad;
    }
}
