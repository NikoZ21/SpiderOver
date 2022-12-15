using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [SerializeField] Transform shotGunFirePoint;
    [SerializeField] float shotgunBulletForce = 20f;
    [SerializeField] float shotgunFireRate = 0.5f;
    [SerializeField] GameObject shotgunBullet;
    [SerializeField] Transform bulletOne;
    [SerializeField] Transform bulletThree;
    [SerializeField] int maxAmmo = 7;
    [SerializeField] float reloadSpeed = 0.2f;
    [SerializeField] TextMeshProUGUI ammoCountText;

    private int _currentAmmo;
    private float _timeToShoot;
    private bool _reloading;
    private float _angleOne;
    private float _angleTwo;

    private void Start()
    {
        _currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        ammoCountText.text = _currentAmmo + " / " + maxAmmo;
    }

    void Update()
    {
        if (CheckIfCanShoot())
        {

            Shoot();
        }
        if (CheckIfCanReload())
        {
            _reloading = true;
            StartCoroutine(Reload());
        }
    }

    private bool CheckIfCanShoot()
    {
        return Input.GetButton("Fire1") && Time.time > _timeToShoot && _currentAmmo > 0;
    }

    private void CalculateAngles()
    {
        _angleOne = Mathf.Atan2((bulletOne.position - shotGunFirePoint.position).y, (bulletOne.position - shotGunFirePoint.position).x) * Mathf.Rad2Deg;
        _angleTwo = Mathf.Atan2((bulletThree.position - shotGunFirePoint.position).y, (bulletThree.position - shotGunFirePoint.position).x) * Mathf.Rad2Deg;
    }

    private void Shoot()
    {
        CalculateAngles();
        ShootBullet(_angleOne);
        ShootBullet();
        ShootBullet(_angleTwo);
        ProccessAfterShooting();
    }

    private void ShootBullet(float angle)
    {
        var bullet = Instantiate(shotgunBullet, shotGunFirePoint.position, Quaternion.identity);
        var bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.rotation = angle;
        bulletRB.AddRelativeForce(bullet.transform.right * shotgunBulletForce, ForceMode2D.Impulse);
    }

    private void ShootBullet()
    {
        var secondBullet = Instantiate(shotgunBullet, shotGunFirePoint.position, transform.rotation);
        var secondBulletRB = secondBullet.GetComponent<Rigidbody2D>();
        secondBulletRB.AddForce(secondBullet.transform.right * shotgunBulletForce, ForceMode2D.Impulse);
    }

    private void ProccessAfterShooting()
    {
        _timeToShoot = Time.time + shotgunFireRate;
        _currentAmmo--;
        UpdateAmmoUI();
    }

    private bool CheckIfCanReload()
    {
        return Input.GetKeyDown(KeyCode.R) && _reloading == false;
    }

    private IEnumerator Reload()
    {
        for (int i = _currentAmmo; i < maxAmmo; i++)
        {
            _currentAmmo++;
            UpdateAmmoUI();
            yield return new WaitForSeconds(reloadSpeed);
        }
        _reloading = false;
    }

}
