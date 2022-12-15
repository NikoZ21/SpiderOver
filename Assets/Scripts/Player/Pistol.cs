using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] Transform pistolFirePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float pistolBulletForce = 20f;
    [SerializeField] float pistolFireRate = 0.3f;
    [SerializeField] int maxAmmo = 25;
    [SerializeField] float reloadSpeed = 0.2f;
    [SerializeField] TextMeshProUGUI ammoCountText;

    private int _currentAmmo;
    private bool _reloading;
    private float _timeToShoot;


    private void Start()
    {
        _currentAmmo = maxAmmo;
        UpdateAmooUI();
    }

    private void UpdateAmooUI()
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
        return Input.GetButton("Fire1") && Time.time > _timeToShoot && _currentAmmo > 0 && _reloading == false;
    }

    private void Shoot()
    {
        InstantiateBullet();
        ProccessAfterShooting();
    }
    
    private void InstantiateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, pistolFirePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pistolFirePoint.right * pistolBulletForce, ForceMode2D.Impulse);
    }

    private void ProccessAfterShooting()
    {
        _timeToShoot = Time.time + pistolFireRate;
        _currentAmmo--;
        UpdateAmooUI();
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
            UpdateAmooUI();
            yield return new WaitForSeconds(reloadSpeed);
        }
        _reloading = false;
    }

}
