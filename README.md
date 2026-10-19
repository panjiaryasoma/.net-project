# IF133 - Tugas 1: Backend Skeleton & Data Persistence

**Nama:** [ISI NAMA]  
**NIM:** [ISI NIM]  
**Kelas:** [ISI KELAS]  
**Mata kuliah:** Pemrograman .NET (IF133)  
**Jenis tugas:** Individu, Minggu 3-4

> Status: kode tersedia, tetapi build, migration, dan pengujian API **belum dijalankan atau diverifikasi** dalam lingkungan penyusunan. Lengkapi hasil aktual sebelum mengumpulkan tugas.

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

## 7. Bukti pengujian yang wajib dilengkapi

Impor `postman/IF133_Tugas1.postman_collection.json` dan jalankan seluruh request **berurutan**. Request POST valid menyimpan `productId` untuk GET, PUT, dan DELETE berikutnya. Screenshot harus berasal dari eksekusi nyata, bukan gambar buatan.

| No | Skenario | Expected | Hasil aktual | Screenshot |
|---|---|---|---|---|
| 1 | GET seluruh data | 200 + array | [ISI] | [ISI] |
| 2 | POST data valid | 201 + object | [ISI] | [ISI] |
| 3 | GET ID hasil POST | 200 + object | [ISI] | [ISI] |
| 4 | PUT data valid | 204 | [ISI] | [ISI] |
| 5 | DELETE data valid | 204 | [ISI] | [ISI] |
| 6 | GET ID tidak ditemukan (999999) | 404 | [ISI] | [ISI] |
| 7 | POST data invalid (stock -1) | 400 | [ISI] | [ISI] |

PDF tugas mewajibkan sedikitnya 5 skenario dengan 1 skenario gagal. Dokumentasikan juga: struktur project, `dotnet run`, migration berhasil, dan struktur tabel database.

## 8. Kendala, solusi, dan kesimpulan

- Kendala aktual: **[ISI SETELAH MENJALANKAN]**
- Penyebab: **[ISI]**
- Solusi: **[ISI]**
- Kesimpulan: Project telah disusun menggunakan controller-based Web API, satu entity Product, dan konfigurasi EF Core SQLite. **Build, database update, dan API testing belum terverifikasi** sehingga klaim keberhasilan harus menunggu eksekusi aktual.

## 9. Pengumpulan

1. Lengkapi identitas dan bukti pengujian yang benar-benar dilakukan.
2. Sertakan seluruh source code, migration, README atau PDF, dan screenshot.
3. Gunakan nama folder pengumpulan `IF133_Tugas1_NIM_Nama` sesuai instruksi dosen; root GitHub tetap boleh memakai nama repository.
4. Jangan sertakan secret, password, API key, token, atau folder `bin/obj` berukuran besar.
5. Pastikan project dapat di-restore, build, migration, dan dijalankan sebelum dinyatakan selesai.
