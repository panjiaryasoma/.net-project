# Pemetaan Bukti Pertemuan 4

Semua screenshot berikut adalah gambar asli yang diunggah pengguna dan telah tersedia di [folder screenshots](../screenshots/INDEX.md). Link bersifat relatif terhadap repository, tanpa menduplikasi gambar ke folder ini.

| Kriteria hands-on / Tugas 1 Final | Bukti | Status |
|---|---|---|
| Struktur project | [01_struktur_project.png](../screenshots/01_struktur_project.png) | Ada |
| Entity Product | [02_entity_product.png](../screenshots/02_entity_product.png) | Ada |
| AppDbContext + DbSet | [03_dbcontext.png](../screenshots/03_dbcontext.png) | Ada |
| Konfigurasi koneksi SQLite | [05_appsettings_sqlite.png](../screenshots/05_appsettings_sqlite.png) dan [Program.cs](../IF133.Tugas1.Api/Program.cs) | Ada |
| Dependency EF Core | [File project .csproj](../IF133.Tugas1.Api/IF133.Tugas1.Api.csproj) | Ada dalam source dan screenshot 18 (27 Oktober 2026) |
| Build berhasil | [06_build_sukses.png](../screenshots/06_build_sukses.png) | Ada (0 warning, 0 error) |
| Migration dan database update | [07_migration_sqlite_sukses.png](../screenshots/07_migration_sqlite_sukses.png) | Ada (`CREATE TABLE Products`, `Done`) |
| Verifikasi tabel SQLite secara visual | [Log migration](../screenshots/07_migration_sqlite_sukses.png) | Log ada dan screenshot DB Browser nomor 17 tersedia |
| Swagger dan endpoint | [08_swagger_semua_endpoint.png](../screenshots/08_swagger_semua_endpoint.png) | Ada, versi setelah EF Core |
| GET all | [09_get_all_200.png](../screenshots/09_get_all_200.png) | PASS: 200, `[]` |
| POST create | [10_post_valid_201.png](../screenshots/10_post_valid_201.png) | PASS: 201, ID 1 |
| GET by ID | [11_get_by_id_200.png](../screenshots/11_get_by_id_200.png) | PASS: 200 |
| PUT update | [12_put_valid_204.png](../screenshots/12_put_valid_204.png) | PASS: 204 |
| Verifikasi sesudah PUT | [13_get_setelah_put_200.png](../screenshots/13_get_setelah_put_200.png) | PASS: 200, nilai diperbarui |
| DELETE | [14_delete_valid_204.png](../screenshots/14_delete_valid_204.png) | PASS: 204 |
| GET sesudah DELETE | [15_get_setelah_delete_404.png](../screenshots/15_get_setelah_delete_404.png) | PASS: 404 |
| POST invalid | [16_post_stok_negatif_400.png](../screenshots/16_post_stok_negatif_400.png) | PASS: 400 |

## Bukti tersisa jika diminta lengkap sesuai Hands-on

1. **Package EF Core (SUDAH ADA screenshot 18):** jalankan `dotnet list IF133.Tugas1.Api/IF133.Tugas1.Api.csproj package` dari root repository, lalu screenshot output. Versi dari source saat ini: EF Core SQLite 8.0.11 dan Design 8.0.11.
2. **Tampilan tabel SQLite (SUDAH ADA screenshot 17):** dari folder `IF133.Tugas1.Api`, jalankan `dotnet ef database update` bila database belum ada, lalu buka `if133_tugas1.db` dengan DB Browser for SQLite/SQLite extension. Screenshot tabel `Products` dan `__EFMigrationsHistory`. File `.db` lokal diabaikan oleh Git.
3. **Swagger sebelum EF Core:** tidak ada screenshot historis dari tahap ini. Jangan menggantinya dengan screenshot pasca-EF Core lalu melabelinya sebagai bukti sebelumnya.
4. **Performa persistence lintas restart:** belum ada pengujian eksplisit yang didokumentasikan. Jika dosen meminta, buat satu data contoh, hentikan dan jalankan server kembali, lalu GET ulang sebelum DELETE.

## Pemeriksaan sebelum unggah ke LMS

Dokumen final resmi meminta source code, migration/database relevan, README ringkas, bukti migration/database update, dan bukti endpoint mengakses database. Semua bisa diakses dari root repo dan tautan di tabel, kecuali screenshot visual DB serta package yang masih perlu dilengkapi bila instruksi hands-on diterapkan sepenuhnya. Untuk format berkas pengumpulan, gunakan `IF133_P4_1003240008_PanjiAryaSoma`; nama repo tidak harus berubah.

## Bukti tambahan 27 Oktober 2026

- [17_sqlite_database_structure.png](../screenshots/17_sqlite_database_structure.png): screenshot DB Browser; tabel dan kolom SQLite terlihat.
- [18_ef_core_package_list.png](../screenshots/18_ef_core_package_list.png): package EF Core SQLite/Design terinstal.
- [19_dotnet_run_server.png](../screenshots/19_dotnet_run_server.png): server berjalan pada localhost:5080.
- Tabel __EFMigrationsHistory terlihat dalam struktur DB, tetapi screenshot baris migration pada tab Browse Data belum ada.
