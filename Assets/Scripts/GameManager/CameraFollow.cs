using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform takipEdilecekNesne;
    public float takipHizi = 2f;

    void Update()
    {
        // Takip edilecek nesne var mı kontrol ediyoruz
        if (takipEdilecekNesne != null)
        {
            // Kameranın pozisyonunu, takip edilecek nesneye doğru hareket ettiriyoruz
            Vector3 yeniPozisyon = Vector3.Lerp(transform.position, takipEdilecekNesne.position, takipHizi * Time.deltaTime);
            yeniPozisyon.z = transform.position.z; // Kameranın Z pozisyonunu sabit tutuyoruz
            transform.position = yeniPozisyon; // Yeni pozisyonu atıyoruz
        }
    }
}
