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

    int currentAmmo;
    bool reloading;
    float timeToShoot;

    private void Start()
    {
        currentAmmo = maxAmmo;
        ammoCountText.text = currentAmmo + " / " + maxAmmo;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToShoot && currentAmmo > 0 && reloading == false)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && reloading == false)
        {
            reloading = true;
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        for (int i = currentAmmo; i < maxAmmo; i++)
        {
            currentAmmo++;
            ammoCountText.text = currentAmmo + " / " + maxAmmo;
            yield return new WaitForSeconds(reloadSpeed);
        }
        reloading = false;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, pistolFirePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pistolFirePoint.right * pistolBulletForce, ForceMode2D.Impulse);
        timeToShoot = Time.time + pistolFireRate;
        currentAmmo--;
        ammoCountText.text = currentAmmo + " / " + maxAmmo;
    }
}
