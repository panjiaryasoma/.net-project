# IF133 - Tugas 1: Backend Skeleton & Data Persistence

**Nama:** Panji Arya Soma  
**NIM:** 1003240008  
**Program studi:** Informatika  
**Mata kuliah:** Pemrograman .NET (IF133)  
**Jenis tugas:** Individu, Minggu 3-4

> Status verifikasi lokal (20 Oktober 2026): `dotnet restore` berhasil, `dotnet build` berhasil (0 warning/0 error), migration `InitialCreate` berhasil membuat tabel `Products`, Swagger berjalan, dan **7/7 skenario CRUD serta validasi lulus** berdasarkan screenshot eksekusi. Sebanyak 19 screenshot hasil eksekusi sudah tersimpan di folder [`screenshots/`](screenshots/INDEX.md).

## 1. Studi kasus

API Inventory dengan satu entity utama: Product (Id, Name, Description, Price, Stock). Data disimpan dalam SQLite melalui Entity Framework Core; API menggunakan ASP.NET Core Web API berbasis controller.

## 2. Teknologi

- C# 12 / .NET SDK 8.0 / ASP.NET Core Web API
- Entity Framework Core 8.0.11 + SQLite
- Swashbuckle.AspNetCore 6.6.2 untuk Swagger/OpenAPI
- Postman untuk skenario pengujian manual

## 3. Struktur project

    IF133.Tugas1.sln
    IF133.Tugas1.Api/
      Controllers/
        ProductsController.cs
        StatusController.cs
      Data/AppDbContext.cs
      DTOs/ProductRequest.cs
      Entities/Product.cs
      Migrations/
        20261019000000_InitialCreate.cs
        20261019000000_InitialCreate.Designer.cs
        AppDbContextModelSnapshot.cs
      Properties/launchSettings.json
      Program.cs
      appsettings.json
      IF133.Tugas1.Api.csproj
    postman/IF133_Tugas1.postman_collection.json
    screenshots/README.md
    README.md

`Program.cs` mengonfigurasi service, DI, SQLite, Swagger, dan routing; `Product` menyimpan data entity; `ProductRequest` memvalidasi request; `AppDbContext` memetakan Products; `Migrations` mendeskripsikan perubahan skema; `ProductsController` menangani operasi CRUD.

## 4. Cara menjalankan

Di terminal pada root repository, dengan .NET SDK 8 terpasang:

    dotnet --info
    dotnet restore
    dotnet build
    dotnet tool install --global dotnet-ef --version 8.0.11
    cd IF133.Tugas1.Api
    dotnet ef database update
    dotnet run --launch-profile http

Jika dotnet-ef sudah terpasang, lewati instalasinya; jika versinya berbeda, gunakan `dotnet tool update --global dotnet-ef --version 8.0.11`. Database `if133_tugas1.db` terbentuk setelah migration berhasil dijalankan dari folder project.

- Swagger: http://localhost:5080/swagger
- Status: http://localhost:5080/api/status
- Products: http://localhost:5080/api/products

Jika port 5080 sedang digunakan, sesuaikan `Properties/launchSettings.json` dan variabel Postman `baseUrl`.

## 5. Entity, validasi, database

| Field | Tipe C# | Validasi |
|---|---|---|
| Id | int | Primary key, auto-generated |
| Name | string | Wajib, non-whitespace, maksimal 120 karakter |
| Description | string? | Opsional, maksimal 500 karakter |
| Price | decimal | Minimal 0, maksimal 999999999.99 |
| Stock | int | Minimal 0 |

`AppDbContext` mendefinisikan `DbSet<Product> Products` dan mengatur kolom. Migration `InitialCreate` berisi instruksi untuk membuat tabel Products. Periksa hasil aktual lewat `dotnet ef migrations list` dan SQLite Browser atau perintah `sqlite3 if133_tugas1.db ".schema Products"`.

## 6. API endpoints

| Method | Endpoint | Status sukses | Status gagal |
|---|---|---|---|
| GET | /api/status | 200 | - |
| GET | /api/products | 200 | 500 jika kesalahan server |
| GET | /api/products/{id} | 200 | 404 jika ID tidak ditemukan |
| POST | /api/products | 201 | 400 jika input invalid |
| PUT | /api/products/{id} | 204 | 400 atau 404 |
| DELETE | /api/products/{id} | 204 | 404 |

Contoh JSON body POST atau PUT:

    {
      "name": "Keyboard Mechanical",
      "description": "Keyboard 75%",
      "price": 350000,
      "stock": 5
    }

POST sukses dirancang untuk menghasilkan `201 Created` beserta ID baru. Permintaan dengan name kosong atau stock negatif dirancang untuk menghasilkan `400 Bad Request`.

## 7. Hasil pengujian aktual melalui Swagger

Bukti berikut berdasarkan eksekusi pada 20 Oktober 2026, bukan hasil simulasi. Screenshot asli telah diberi nama berurutan untuk folder `screenshots/`. Untuk pengujian POST valid, ID yang dibuat adalah `1`. Setelah PUT, GET ulang menunjukkan perubahan harga dan stok; setelah DELETE, GET ulang menghasilkan 404.

| No | Skenario | Respons aktual | Hasil | Screenshot |
|---|---|---|---|---|
| 1 | GET seluruh produk saat kosong | `200 OK`, `[]` | PASS | `09_get_all_200.png` |
| 2 | POST data valid | `201 Created`, `id: 1` | PASS | `10_post_valid_201.png` |
| 3 | GET ID 1 | `200 OK`, data produk | PASS | `11_get_by_id_200.png` |
| 4 | PUT ID 1 | `204 No Content` | PASS | `12_put_valid_204.png` |
| 5 | DELETE ID 1 | `204 No Content` | PASS | `14_delete_valid_204.png` |
| 6 | GET ID 1 setelah DELETE | `404 Not Found` | PASS | `15_get_setelah_delete_404.png` |
| 7 | POST dengan `stock: -5` | `400 Bad Request`, validasi stok | PASS | `16_post_stok_negatif_400.png` |

Verifikasi tambahan: `13_get_setelah_put_200.png` menampilkan `200 OK` dengan `name: Keyboard Mechanical Pro`, `price: 400000`, dan `stock: 3`. Screenshot lainnya meliputi struktur project, entity, DbContext, controller, konfigurasi, build, migration, dan Swagger.

**Catatan bukti:** tabel `Products` terbukti dibuat dari log `CREATE TABLE` saat migration, tetapi screenshot DB Browser untuk struktur tabel sudah tersedia (nomor 17). File PNG yang dirujuk sudah tersedia di folder [`screenshots/`](screenshots/INDEX.md).

## 8. Kendala, solusi, dan kesimpulan

- **Kendala awal:** perintah `dotnet` belum dikenali karena SDK belum terinstal/terminal lama belum memuat PATH yang baru.
- **Solusi:** memasang .NET SDK 8, membuka ulang PowerShell, lalu memastikan `dotnet --info` berhasil.
- **Kendala aplikasi:** POST data valid awalnya menghasilkan `500 Internal Server Error` karena atribut validasi `Range` untuk `decimal` gagal membaca batas `999999999.99` dengan pengaturan regional sistem.
- **Solusi aplikasi:** menambahkan `ParseLimitsInInvariantCulture = true` di `ProductRequest.cs`, memperbarui project lokal dari GitHub, lalu menguji ulang.
- **Hasil:** build 0 warning/0 error, migration SQLite berhasil, Swagger aktif, dan 7 skenario utama menghasilkan status HTTP sesuai harapan. Bukti visual dikurasi untuk pelaporan.

## 9. Finalisasi Pertemuan 4

Materi/Hands-on Pertemuan 4 dan dokumen **Tugas 1 - Final: Entity Framework Core & Data Persistence** ditangani sebagai finalisasi Tugas 1 yang sama, bukan Tugas 2 baru. Dokumentasi khusus ada di [`P04_Tugas1_Final/`](P04_Tugas1_Final/README.md), termasuk worksheet, exit ticket, dan pemetaan evidence. Source code tetap di `IF133.Tugas1.Api/` agar tidak ada salinan project kedua.

## 10. Pengumpulan

1. Lengkapi identitas dan bukti pengujian yang benar-benar dilakukan.
2. Sertakan seluruh source code, migration, README atau PDF, dan screenshot.
3. Gunakan nama folder pengumpulan `IF133_Tugas1_NIM_Nama` sesuai instruksi dosen; root GitHub tetap boleh memakai nama repository.
4. Jangan sertakan secret, password, API key, token, atau folder `bin/obj` berukuran besar.
5. Pastikan project dapat di-restore, build, migration, dan dijalankan sebelum dinyatakan selesai.

