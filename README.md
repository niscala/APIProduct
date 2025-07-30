1. di root folder buka terminal dan jalankan perintah 'dotnet run'
   Asumsikan local sudah terpasang dotnet (.Net 8)
2. Buka Postman untuk cek API dengan link sebagai berikut
   - Auth User
      * POST : http://localhost:5118/api/login (username, password)
      * POST : http://localhost:5118/api/register (username, email, password)
   - Product
     * GET : http://localhost:5118/api/Product/
     * GET : http://localhost:5118/api/Product/{id} (isikan id)
     * POST : http://localhost:5118/api/Product/ (Name, Description, Price)
     * DEL :  http://localhost:5118/api/Product/{id} (isikan id)
     * PUT :  http://localhost:5118/api/Product/{id} (isikan id)
3. Sebelum get product atau tambah product isikan terlebih dahulu token yg didapat saat login di bagian Authorization dengan Bearer Token
4. Terdapat UI dari API ini GIT : https://github.com/niscala/APIProductUI.git
