# Bukti Screenshot Tugas 1 IF133

Bukti asli yang dikirim pengguna dari IDE/PowerShell/Swagger pada tanggal 19–20 Oktober 2026. Berkas hanya disalin dan diberi nama berurutan, **tanpa mengubah isi gambar**. Seluruh status HTTP di bawah berasal dari hasil eksekusi yang terlihat, bukan mock.

| File | Keterangan | Status yang teramati |
|---|---|---|
| [01_struktur_project.png](./01_struktur_project.png) | Struktur solution dan folder project | Bukti visual |
| [02_entity_product.png](./02_entity_product.png) | Entity Product.cs dengan lima field | Bukti visual |
| [03_dbcontext.png](./03_dbcontext.png) | AppDbContext dengan DbSet Products | Bukti visual |
| [04_products_controller.png](./04_products_controller.png) | ProductsController.cs (bagian controller) | Bukti visual |
| [05_appsettings_sqlite.png](./05_appsettings_sqlite.png) | appsettings.json connection string SQLite | Bukti visual |
| [06_build_sukses.png](./06_build_sukses.png) | dotnet build, 0 warning dan 0 error | Build: 0 warning, 0 error |
| [07_migration_sqlite_sukses.png](./07_migration_sqlite_sukses.png) | Migration InitialCreate dan CREATE TABLE Products berhasil | Migration: selesai |
| [08_swagger_semua_endpoint.png](./08_swagger_semua_endpoint.png) | Swagger UI menampilkan endpoint CRUD dan status | Bukti visual |
| [09_get_all_200.png](./09_get_all_200.png) | GET /api/products, HTTP 200, JSON [] | 200 OK |
| [10_post_valid_201.png](./10_post_valid_201.png) | POST /api/products, HTTP 201, produk ID 1 | 201 Created |
| [11_get_by_id_200.png](./11_get_by_id_200.png) | GET /api/products/1, HTTP 200 | 200 OK |
| [12_put_valid_204.png](./12_put_valid_204.png) | PUT /api/products/1, HTTP 204 | 204 No Content |
| [13_get_setelah_put_200.png](./13_get_setelah_put_200.png) | GET ulang ID 1 membuktikan data berubah | 200 OK |
| [14_delete_valid_204.png](./14_delete_valid_204.png) | DELETE /api/products/1, HTTP 204 | 204 No Content |
| [15_get_setelah_delete_404.png](./15_get_setelah_delete_404.png) | GET ID 1 setelah dihapus, HTTP 404 | 404 Not Found |
| [16_post_stok_negatif_400.png](./16_post_stok_negatif_400.png) | POST stock=-5, HTTP 400 dan error validasi | 400 Bad Request |

## Catatan

- Respons GET All pertama adalah `[]` karena database masih kosong.
- Verifikasi PUT dilakukan dengan GET ulang dan terlihat nilai `name`, `price`, dan `stock` berubah.
- Verifikasi DELETE dilakukan dengan GET ulang dan mendapatkan `404 Not Found`.
- `Undocumented` di Swagger berarti respons HTTP tidak didokumentasikan eksplisit di OpenAPI, bukan kegagalan request.
- Screenshot error 500 historis sebelum perbaikan sengaja tidak dimasukkan sebagai bukti PASS; kendala dan solusi bisa dijelaskan pada README utama.
- Bukti tampilan struktur tabel DB Browser for SQLite telah ditambahkan sebagai screenshot 17; log migration CREATE TABLE juga tersedia.
- `Program.cs` bisa ditunjukkan langsung dari repository. Screenshot terpisah belum tersedia dari kiriman pengguna.

## Bukti tambahan Pertemuan 4 (27 Oktober 2026)

| File | Keterangan | Status |
|---|---|---|
| [17_sqlite_database_structure.png](./17_sqlite_database_structure.png) | DB Browser menampilkan tabel Products dan __EFMigrationsHistory beserta kolomnya | Terverifikasi visual |
| [18_ef_core_package_list.png](./18_ef_core_package_list.png) | dotnet list package: EF Core Design dan SQLite 8.0.11, Swashbuckle 6.6.2 | Terverifikasi terminal |
| [19_dotnet_run_server.png](./19_dotnet_run_server.png) | dotnet run mendengarkan pada http://localhost:5080 | Terverifikasi terminal |

Nomor 18 dan 19 adalah crop dari screenshot PowerShell asli yang sama, tanpa perubahan isi terminal. Screenshot Browse Data yang menunjukkan **baris** migration history belum tersedia; screenshot nomor 17 hanya menunjukkan keberadaan tabel dan struktur.
