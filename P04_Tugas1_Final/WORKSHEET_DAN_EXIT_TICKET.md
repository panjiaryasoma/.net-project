# Worksheet Praktik Kelas dan Exit Ticket — Pertemuan 4

**Nama:** Panji Arya Soma  
**NIM:** 1003240008  
**Project:** `IF133.Tugas1.Api`

## A. Worksheet (Hands-on Pertemuan 4, halaman 12)

| Item dari worksheet | Jawaban berdasarkan source dan bukti |
|---|---|
| Nama project dan URL lokal | `IF133.Tugas1.Api`; Swagger `http://localhost:5080/swagger`, API `http://localhost:5080/api/products` |
| Nama entity yang dibuat | `Product` di `Entities/Product.cs` |
| Nama DbContext | `AppDbContext` di `Data/AppDbContext.cs` |
| Connection string | `DefaultConnection: Data Source=if133_tugas1.db` pada `appsettings.json` |
| Nama migration | `20261019000000_InitialCreate` (`InitialCreate`) |
| Lokasi database SQLite | `IF133.Tugas1.Api/if133_tugas1.db` jika perintah dijalankan dari direktori project API; tidak masuk Git |
| Error utama dan solusi | POST valid sempat mendapat 500 karena batas `Range` untuk `decimal` gagal diparse mengikuti locale. Atur `ParseLimitsInInvariantCulture = true` dalam `DTOs/ProductRequest.cs`, build ulang dan tes POST: menjadi 201 Created |

Catatan masalah lingkungan: saat pertama menguji, perintah `dotnet` belum ditemukan sampai SDK .NET 8 diinstal dan PowerShell dibuka ulang.

## B. Exit ticket (Hands-on Pertemuan 4, halaman 13)

**1. Apa fungsi DbContext?**

`DbContext` menjadi jembatan antara kode C# dan database melalui EF Core. Ia menyediakan `DbSet<Product>` untuk query dan perubahan data, menangani tracking dan penyimpanan dengan `SaveChangesAsync()`, serta memakai konfigurasi provider SQLite dari dependency injection. Dengan demikian controller tidak perlu membuat koneksi SQL secara manual.

**2. Apa hubungan entity dan migration?**

Entity `Product` merepresentasikan data yang ingin disimpan. Konfigurasi di `AppDbContext` menentukan bagaimana entity dipetakan ke tabel dan kolom. Migration Code First mencatat perubahan skema yang berasal dari model tersebut; `dotnet ef database update` menerapkannya ke SQLite. Ketika model berubah, migration berikutnya dapat dibuat untuk mengubah skema secara terkontrol, bukan mengedit tabel tanpa riwayat.

**3. Error apa yang paling sulit dan bagaimana solusinya?**

Pada uji `POST /api/products` dengan harga `350000`, API justru mengembalikan `500 Internal Server Error`. Stack trace menunjukkan atribut `Range(typeof(decimal), "0", "999999999.99")` gagal mengonversi batas string desimal, karena penggunaan pemisah desimal bergantung pada culture. Perbaikan dilakukan dengan menambahkan `ParseLimitsInInvariantCulture = true` pada atribut `Range`. Setelah kode diambil ulang dari GitHub, project berhasil build, migration diterapkan, dan request POST yang sama menghasilkan `201 Created`.

## C. Verifikasi sederhana

- Build lokal: 0 warning, 0 error.
- Migration: `InitialCreate` diterapkan, tabel `Products` dibuat.
- Bukti akses data: `GET /api/products` (200), `POST /api/products` (201), `GET /api/products/1` (200).
- Bukti update/delete dan validation: `PUT` 204, `DELETE` 204, GET setelah DELETE 404, POST stok negatif 400.

Lihat file [EVIDENCE.md](./EVIDENCE.md) untuk tautan ke screenshot asli.

## D. Catatan akademik

Hands-on memberikan contoh entity `Product` dengan `CreatedAt`, tetapi entity pada repo ini memang hanya berisi `Id`, `Name`, `Description`, `Price`, `Stock`. Field tambahan `CreatedAt` tidak diklaim sudah ada dan tidak ditambahkan tanpa kebutuhan tugas. Source dan bukti sesuai dengan implementasi yang benar-benar diuji.
