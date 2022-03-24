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

    int currentAmmo;
    float timeToShoot;
    bool reloading;

    private void Start()
    {
        currentAmmo = maxAmmo;
        ammoCountText.text = currentAmmo + " / " + maxAmmo;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToShoot && currentAmmo > 0 )
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
        //bullet one...
        float angleOne = Mathf.Atan2((bulletOne.position - shotGunFirePoint.position).y, (bulletOne.position - shotGunFirePoint.position).x) * Mathf.Rad2Deg;
        var firstBullet = Instantiate(shotgunBullet, shotGunFirePoint.position, Quaternion.identity);
        var firstBulletRB = firstBullet.GetComponent<Rigidbody2D>();
        firstBulletRB.rotation = angleOne;
        firstBulletRB.AddRelativeForce(firstBullet.transform.right * shotgunBulletForce, ForceMode2D.Impulse);

        //bullet two...
        var secondBullet = Instantiate(shotgunBullet, shotGunFirePoint.position, transform.rotation);
        var secondBulletRB = secondBullet.GetComponent<Rigidbody2D>();
        secondBulletRB.AddForce(secondBullet.transform.right * shotgunBulletForce, ForceMode2D.Impulse);

        //third bullet...
        float angleThree = Mathf.Atan2((bulletThree.position - shotGunFirePoint.position).y, (bulletThree.position - shotGunFirePoint.position).x) * Mathf.Rad2Deg;
        var thirdBullet = Instantiate(shotgunBullet, shotGunFirePoint.position, Quaternion.identity);
        var thirdBulletRB = thirdBullet.GetComponent<Rigidbody2D>();
        thirdBulletRB.rotation = angleThree;
        thirdBulletRB.AddRelativeForce(thirdBullet.transform.right * shotgunBulletForce, ForceMode2D.Impulse);

        //fire-rate
        timeToShoot = Time.time + shotgunFireRate;

        //decreasing ammo
        currentAmmo--;
        ammoCountText.text = currentAmmo + " / " + maxAmmo;
    }
}
