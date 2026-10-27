# IF133 Pertemuan 4 — Tugas 1 Final

**Judul tugas resmi:** Tugas 1 - Final: Entity Framework Core & Data Persistence  
**Nama:** Panji Arya Soma  
**NIM:** 1003240008  
**Program studi:** Informatika  
**Penamaan pengumpulan:** `IF133_P4_1003240008_PanjiAryaSoma`

## Tujuan

Melanjutkan skeleton ASP.NET Core dari Pertemuan 3 agar memiliki model data dan penyimpanan persisten: entity, DbContext, provider EF Core SQLite, connection string, migration Code First, dan operasi aplikasi yang mengakses database. Dokumen ini mengikuti `P04_Tugas_1_Final_EFCore.pdf` (halaman 1–3) dan `Hands_on_Pertemuan_4_Pemrograman_DotNet_IF133.pdf` (halaman 1–13).

**Ini bukan Tugas 2 baru.** Repository telah mengimplementasikan persyaratan Pertemuan 4 dalam tugas sebelumnya, sehingga folder ini berisi kelengkapan pengumpulan dan penjelasan, tanpa menduplikasi source code atau screenshot.

## Artefak dan lokasi

| Luaran dokumen tugas | Lokasi dalam repository |
|---|---|
| Source code final Web API | [`IF133.Tugas1.Api/`](../IF133.Tugas1.Api/) dan [`IF133.Tugas1.sln`](../IF133.Tugas1.sln) |
| Entity dan DbContext | [`Entities/Product.cs`](../IF133.Tugas1.Api/Entities/Product.cs), [`Data/AppDbContext.cs`](../IF133.Tugas1.Api/Data/AppDbContext.cs) |
| Provider EF Core SQLite | [`IF133.Tugas1.Api.csproj`](../IF133.Tugas1.Api/IF133.Tugas1.Api.csproj) |
| Connection string dan DI | [`appsettings.json`](../IF133.Tugas1.Api/appsettings.json), [`Program.cs`](../IF133.Tugas1.Api/Program.cs) |
| Migration `InitialCreate` | [`Migrations/`](../IF133.Tugas1.Api/Migrations/) |
| README cara menjalankan dan hasil CRUD | [README utama](../README.md) |
| Hasil pengujian asli | [`screenshots/INDEX.md`](../screenshots/INDEX.md) |
| Worksheet dan exit ticket | [WORKSHEET_DAN_EXIT_TICKET.md](./WORKSHEET_DAN_EXIT_TICKET.md) |
| Pemetaan bukti dan kekurangan | [EVIDENCE.md](./EVIDENCE.md) |

## Cara mereproduksi

Dari root repository di PowerShell, pada mesin dengan SDK .NET 8:

```powershell
dotnet restore
dotnet build
dotnet list IF133.Tugas1.Api/IF133.Tugas1.Api.csproj package
cd IF133.Tugas1.Api
dotnet ef migrations list
dotnet ef database update
dotnet run --launch-profile http
```

Jika `dotnet ef` belum tersedia, pasang tool versi sesuai EF Core: `dotnet tool install --global dotnet-ef --version 8.0.11`. Swagger pada development: `http://localhost:5080/swagger`.

Perintah migration **add** tidak perlu dijalankan ulang karena migration awal sudah ada di repo. `dotnet ef database update` menerapkan migration pada database yang belum dibuat atau belum dimigrasikan.

## Hasil terverifikasi dari bukti lokal

- SDK .NET 8.0.426 berjalan; `dotnet build` menghasilkan **0 warning, 0 error**.
- `dotnet ef database update` berhasil menerapkan `20261019000000_InitialCreate` dan mengeksekusi `CREATE TABLE "Products"`.
- Swagger dapat dibuka dan memuat endpoint `Products`.
- Pengujian GET all, POST valid, GET by ID, PUT, DELETE, GET setelah DELETE (404), dan POST stok negatif (400) menghasilkan status sesuai harapan (**7/7 PASS**).
- Nilai setelah PUT diverifikasi lewat GET ulang (`name` berubah menjadi `Keyboard Mechanical Pro`, harga 400000, stok 3).

Pernyataan di atas berasal dari screenshot eksekusi pengguna tanggal 19–20 Oktober 2026, bukan pengujian baru pada saat dokumen ini dibuat.

## Batas verifikasi / catatan pengumpulan

1. Bukti SQLite berupa log migration `CREATE TABLE` sudah ada. **Screenshot struktur tabel lewat DB Browser tersedia (bukti nomor 17); bukti isi baris __EFMigrationsHistory belum ada.**
2. Screenshot `dotnet list package` sudah tersedia (bukti nomor 18); referensi `.csproj` juga ada.
3. Hands-on meminta screenshot Swagger *sebelum* pemasangan EF Core. Yang tersedia adalah Swagger aplikasi akhir, sehingga bukti historis tahap pra-EF Core tidak bisa direkonstruksi secara jujur.
4. Database SQLite lokal `if133_tugas1.db` tidak di-commit karena `.gitignore` mengecualikan `*.db`. Database bisa dibuat ulang lewat migration. Jika kanal pengumpulan mensyaratkan berkas `.db`, lampirkan salinan database lokal dalam paket pengumpulan, jangan menciptakan file kosong sebagai pengganti.

## Status

Fungsi utama dan bukti pengujian berhasil diverifikasi; kelengkapan dokumentasi Pertemuan 4 tersusun di folder ini. Tiga kekurangan bukti visual di atas perlu diperhatikan sebelum menyebut pengumpulan memenuhi seluruh checklist hands-on.

Tidak ada frontend, deployment, atau aplikasi baru yang diperlukan untuk output dokumen ini.

