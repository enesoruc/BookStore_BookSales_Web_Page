namespace BookStore.DAL.Migrations
{
    using BookStore.DAL.Concrete.EntityFramework;
    using BookStore.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStoreDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookStoreDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            List<Country> countries = new List<Country>();
            countries.Add(new Country { Name = "Türkiye" });
            context.Countries.AddRange(countries);
            context.SaveChanges();

            List<City> cities = new List<City>();
            cities.Add(new City { Name = "Adana", Country = countries[0] });
            cities.Add(new City { Name = "Ankara", Country = countries[0] });
            cities.Add(new City { Name = "Antalya", Country = countries[0] });
            cities.Add(new City { Name = "Bursa", Country = countries[0] });
            cities.Add(new City { Name = "Bilecik", Country = countries[0] });
            cities.Add(new City { Name = "İstanbul", Country = countries[0] });
            cities.Add(new City { Name = "İzmir", Country = countries[0] });
            context.Cities.AddRange(cities);
            context.SaveChanges();

            List<District> districts = new List<District>();
            districts.Add(new District { Name = "Ceyhan", City = cities[0] });
            districts.Add(new District { Name = "Çukurova", City = cities[0] });
            districts.Add(new District { Name = "Çankaya", City = cities[1] });
            districts.Add(new District { Name = "Ulus", City = cities[1] });
            districts.Add(new District { Name = "Kepez", City = cities[2] });
            districts.Add(new District { Name = "Uludağ", City = cities[3] });
            districts.Add(new District { Name = "Gemlik", City = cities[3] });
            districts.Add(new District { Name = "Osmangazi", City = cities[3] });
            districts.Add(new District { Name = "Ayvalık", City = cities[4] });
            districts.Add(new District { Name = "Bandırma", City = cities[4] });
            districts.Add(new District { Name = "Maltepe", City = cities[5] });
            districts.Add(new District { Name = "Ataşehir", City = cities[5] });
            districts.Add(new District { Name = "Küçükyalı", City = cities[5] });
            districts.Add(new District { Name = "Kadıköy", City = cities[5] });
            districts.Add(new District { Name = "Çiğli", City = cities[6] });
            districts.Add(new District { Name = "Merkez", City = cities[6] });
            context.Districts.AddRange(districts);
            context.SaveChanges();

            List<UserRole> userRoles = new List<UserRole>();
            userRoles.Add(new UserRole { RoleName = "Admin" });
            userRoles.Add(new UserRole { RoleName = "Standart" });
            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();

            List<Language> languages = new List<Language>();
            languages.Add(new Language { Name = "Türkçe" });
            languages.Add(new Language { Name = "İngilizce" });
            languages.Add(new Language { Name = "Fransızca" });
            languages.Add(new Language { Name = "Almanca" });
            languages.Add(new Language { Name = "Arapça" });
            languages.Add(new Language { Name = "Lehçe" });
            languages.Add(new Language { Name = "Japonca" });
            languages.Add(new Language { Name = "Azerice" });
            context.Languages.AddRange(languages);
            context.SaveChanges();



            List<PublishingHouse> publishingHouses = new List<PublishingHouse>();
            publishingHouses.Add(new PublishingHouse { CompanyName = "İletişim Yayınları", ContactName = "Hilmi Çakır", Phone = "02164568941", ImagePath= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBgWe6j9yV5eAJ7mpwHpdu7Ye9nBxVELGwgERXWnfmBqByB2iNmg",AddressDetail="İletişim adresi" });
            publishingHouses.Add(new PublishingHouse { CompanyName = "Yapı Kredi Yayınları", ContactName = "Sami Güven", Phone = "02164568942" ,ImagePath="şimdilik yok", AddressDetail = "YKY adresi" });
            publishingHouses.Add(new PublishingHouse { CompanyName = "Sel Yayıncılık", ContactName = "Beste Sezer", Phone = "02164568943", ImagePath = "şimdilik yok", AddressDetail = "Sel Yayıncılık adresi" });
            publishingHouses.Add(new PublishingHouse { CompanyName = "İthaki Yayınları", ContactName = "Mehmet Öztürk", Phone = "02164568944", ImagePath = "şimdilik yok", AddressDetail = "İthaki adresi" });
            publishingHouses.Add(new PublishingHouse { CompanyName = "Destek Yayınları", ContactName = "Sefa Şahin", Phone = "02164568945", ImagePath = "şimdilik yok", AddressDetail = "Destek adresi" });
            publishingHouses.Add(new PublishingHouse { CompanyName = "Siren Yayınları", ContactName = "Hande Doğan", Phone = "02164568946", ImagePath = "şimdilik yok", AddressDetail = "Siren adresi" });            
            publishingHouses.Add(new PublishingHouse { CompanyName = "Kapı Yayınları", ContactName = "Şefik Seven", Phone = "02164568947", ImagePath = "şimdilik yok", AddressDetail = "Kapı adresi" });            
            context.PublishingHouses.AddRange(publishingHouses);
            context.SaveChanges();

            User admin = new User();
            admin.FirstName = "Enes";
            admin.LastName = "Oruç";
            admin.BirthDate = DateTime.Now;
            admin.ActivationCode = Guid.NewGuid();
            admin.EMail = "orucenes95@gmail.com";
            admin.Password = "1234";
            admin.UserName = "enesoruc";
            admin.UserRole = userRoles[0];
            admin.PhoneNumber = "05343816895";
            admin.IsActive = true;
            context.Users.Add(admin);
            context.SaveChanges();

            List<Category> categories = new List<Category>();
            categories.Add(new Category { Name = "Araştırma - Tarih", Description= "Okuma ve araştırmaya ilgi duyan yeni bilgiler edinmeyi seven kitap severlere yönelik çok sayıda seçeneği bulacağınız eserler, araştırma - tarih kategorisinde yer alan kitaplar ile geniş bir yelpazede kitap severlerin tercihine sunuluyor. Hemen hemen her alanda bilgi sahibi olabileceğiniz politika, tarih, sosyoloji, gibi geniş bir skalada sunulan eserler zengin içeriği ile raflardaki yerini alıyor. Dilediğiniz konuyu seçerek o konu hakkında yapılmış olan araştırmaları ve yayınlanan eserleri bulabileceğiniz kitaplar zengin içeriğiyle göz kamaştırıyor.Hakkında çok sayıda eser bulunan ve dünyanın en güzel şehirleri arasında yer alan İstanbul kitapları, şehri her yönüyle ele alan eserleri sunuyor.Çok sayıda nitelikli yazar ve yayınevinin sunduğu İstanbul hakkında yazılan romanlar, ansiklopediler, incelemeler, şiir kitapları gibi çok sayıda kaynağa ulaşma imkanı tanınıyor." });
            categories.Add(new Category { Name = "Bilim" ,Description= "Her daim güvenli alışveriş deneyimi sunan Idefix, kullanıcılarıyla sıcak ancak profesyonel bir bağ kuruyor. Bünyesinde pek çok farklı kategoriyi bir arada bulunduran Idefix kitap, müzik, film, dizi, oyun ve elektronik gibi konularda hizmet veriyor. Kategoriler arasında bulunan bilim, alanında uzman yazarlar tarafından oluşturulan kaynaklara ulaşmanızı sağlıyor. Bilim adamları tarafından oluşturulan içeriklerden bilim tarihine kadar uzanan geniş bir skalada kitap bulabilir, yeni şeyler öğrenebilirsiniz. Makine, robot, uzay, zaman ve insan vücudu gibi daha pek çok konuda kaynak bulmanızı sağlayan kategori, aynı zamanda gelişmiş filtreleme özelliklerini kullanmanızı mümkün hale getiriyor. Popüler bilim, mühendislik, matematik, bilim tarihi ve felsefesi, arkeoloji, biyoloji, antropoloji ve fizik, filtreleme yapabileceğiniz konular arasında bulunuyor." });
            categories.Add(new Category { Name = "Çizgi Roman", Description = "Küçükten büyüğe her yaştan kişinin keyifli zaman geçirmesine yardımcı olan çizgi romanlar her zaman ilgi çekici olmayı başarıyor. Özellikle günümüzde popüler kültürün etkisiyle farklı sanat disiplinlerinde de etkisi hayli hissedilir olan çizgi roman karakterleri, hayal gücünün sınırlarını genişletmek ve güzel zaman geçirmek için birebir. Sinemanın etkisiyle tekrar alevlenen süper kahraman dünyası, çizgi romanların da tekrar gün yüzüne çıkmasını sağlıyor. Her kültürün kendi altyapısı ve dinamikleriyle ortaya çıkan çizgi roman kitapları tıpkı masallar gibi dünya üzerinde çeşitli farklılıklar gösteriyor. Geçmişin masalla tasvir edilen dünyasının yerini günümüzde çok renkli çizgileri ve eğlenceli hikayeleriyle çizgi romanlar alıyor. Sadece meraklısı için değil hayallerin sınırsız dünyasında yolculuk yapmak isteyenler için de tercih edilen çizgi romanlar, günlük hayatın rutininden sıyrılmak için harika bir seçenek." });
            categories.Add(new Category { Name = "Din - Mitoloji", Description = "Aşk, nefret, kahramanlık, korkaklık, cesaret, bilgelik, dürüstlük gibi insana özgü yüzlerce konuda nesilden nesile aktarılan mitolojik hikayeler modern dünyada da kendine yer bulmaktadır. Merak duygusunu canlı tutan okuyuculara yönelik mitolojik eserler akıl, kalp ve ruh üçgenini besleyerek soyut bir iç yolculuğa kapı aralar. Eski toplumlar ve onların kültürlerine ilgi duyan okurlar, mitoloji okumaları sayesinde toplumların bugünkü sosyal ve ekonomik kalkınmalarının arka planındaki felsefi argümanları daha iyi anlayarak analiz etme imkanına sahip olurlar. Mitoloji sayesinde toplumların olayları ve olguları nasıl yorumladıklarına şahitlik eden kitap severler, geçmiş ve bugün arasında kurulan köprülerin önem ve değerini idrak eder ve farkındalık oluştururlar." });
            categories.Add(new Category { Name = "Edebiyat", Description = "Farklı yayınevleri tarafından basılmış yüzlerce önemli esere kolayca ulaşılabilen bu kategoride aynı kitabın birden fazla baskısına erişilebilmesi sayesinde farklı çevirilerin lezzetini tatmak mümkün oluyor. Roman kitapları, öykü kitapları, şiir kitapları, anılar, günlükler, mektuplar gibi türlü edebiyat eserleri bir arada bulunuyor. Fiyat listelemesi özelliği ile ürünleri fiyatlarına göre sıralamak kolaylaşıyor. Sadece bir yazarın kitaplarını incelemek isteyenler için geliştirilmiş olan \"yazar ara\" özelliği ile sadece belli bir yazarın eserleri görüntülenebiliyor. Okurlara farklı bakış açıları kazandıran dünya romanları ile bambaşka diyarlarda zihni yolculuklar yapılabiliyor. Farklı kültürlerin ve farklı anlayışların dünyaya bakışını, hayata verdiği anlamı binbir ayrı pencereden okumak edebiyatseverlerin ufkunu genişletiyor." });
            categories.Add(new Category { Name = "Eğitim - Başvuru", Description = "Genel anlamda hayatınıza yön vermek ve işinizde, ilişkilerinizde ve sağlığınız konusunda daha başarılı olmanız için sizlere yardımcı olan kitaplar son derece popülerdir. Söz konusu kitaplardaki tavsiyeleri uygulayarak hayattaki zorlukların üstesinden gelmek sizin için daha kolay olabilir. Böyle kitapların bazıları sıklıkla en çok satanlar listesine girmeyi başarmaktadır. Ünlü ve başarılı kişiliklerin hayat hikayelerinden ilham alınarak yazılan kitaplar ise onların yaşamlarını kendinize örnek almanızı sağlamaktadır. " });
            categories.Add(new Category { Name = "Felsefe", Description = "Felsefe hayatımızın her alanında etkili olan bir bilim dalıdır. Bir İşin felsefesini bilmek her zaman önemlidir. \"Felsefe nedir\" sorusuna verilecek ilk yanıt, Antik Grek düşüncesindeki Philo-Sophia yani ‘bilgi sevgisi’ yanıtıdır. Tabii burada bilgi sevgisini yalın bir sevgi olmanın ötesinde erdemli yaşamanın yoluna dair bilgi olarak anlamak önemlidir. Çünkü felsefe insanın erdemli olmasını, ne için ve neden var olduğunu öğrenmesine yarar. Günümüzün stresli ve karmaşık yapısı da felsefenin konusudur. Özellikle öğrenciler ve iş hayatında aktif olanlar modern yaşamın paradokslarla dolu konularına dair çözümleri bu kategoride bulabilirler. " });
            categories.Add(new Category { Name = "Hobi", Description = "Hayatlarımızı renklendirmek ve eğlence katmak amacıyla çeşitli hobilere sahip olmamız gerekmektedir. Yaşamın monoton ve tekdüze temposundan sıyrılmak böylelikle mümkün olmaktadır. Herkesin mutlaka ilgi duyduğu konulara yönelik bir veya birden fazla hobisi vardır. BookStore’in geniş ve özgün kitap koleksiyonu dahilinde yer alan hobi kitapları, sevdiğiniz aktiviteler ve zaman ayırdığınız konularla alakalı olarak size büyük katkı sağlayabilir." });
            categories.Add(new Category { Name = "Prestij Kitapları", Description = "Prestij kitapları şirketlerin, kurumların, özel veya kamu finans kuruluşlarının satış amaçlı olmadan ürettikleri çalışan, müşteri ve iş ortaklarına dağıttıkları itibar kitapları olma özelliği taşıyor. Kuruluşlarının maddi destekleriyle her yıl sonunda yayınlanması gelenek haline gelmiş lüks baskı kitaplar olarak da özel bir anlam taşıyor. Firma tarihçeleri, başarı öyküleri, ürün ve hizmetlere yönelik yaratıcı içeriklerle oluşturulabiliyor. Çok farklı konular üzerine hazırlanabiliyor." });
            categories.Add(new Category { Name = "Çocuk ve Gençlik", Description = "Özellikle küçük yaşta okuma alışkanlığı kazanmak önemli olarak görülüyor. Okuma alışkanlığı kazanmış olan bir çocuk, gençlik ve yetişkinlik dönemlerinde farklı başarılara imza atabiliyor. Bu doğrultuda çocuğunuza önemli olan bilgileri vermenin yanı sıra doğru kitapları okutmalı ve onun okumayı sevmesine yardımcı olmalısınız. Çocuk ve gençlik kategorisi ise bu konuda imdadınıza yetişiyor. Birbirinden faydalı ve eğitici kitapları bulabileceğiniz kategori içerisinde ayrıca çocuğunuzun dikkatini çekebilecek türde kitaplar da bulabilirsiniz. " });
            context.Categories.AddRange(categories);
            context.SaveChanges();

            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories.Add(new SubCategory { Name = "Çocuk ve Gençlik", Description = "Çocuk ve Gençlik" , Category=categories[0]});
            subCategories.Add(new SubCategory { Name="Tarih",Description="Tarih",Category=categories[0]});
            subCategories.Add(new SubCategory { Name="Sosyoloji",Description="Sosyoloji", Category = categories[0] });
            subCategories.Add(new SubCategory { Name="Popüler Bilim",Description="Popüler Bilim", Category = categories[1] });
            subCategories.Add(new SubCategory { Name="Mühendislik",Description="Mühendislik", Category = categories[1] });
            subCategories.Add(new SubCategory { Name="Matematik",Description="Matematik", Category = categories[1] });
            subCategories.Add(new SubCategory { Name="İslamiyet",Description="İslamiyet", Category = categories[3] });
            subCategories.Add(new SubCategory { Name="Tasavvuf",Description="Tasavvuf", Category = categories[3] });
            subCategories.Add(new SubCategory { Name = "Din", Description = "Din", Category = categories[3] });
            subCategories.Add(new SubCategory { Name = "Roman", Description = "Roman ", Category = categories[4] });
            subCategories.Add(new SubCategory { Name = "Şiir", Description = "Şiir", Category = categories[4] });
            subCategories.Add(new SubCategory { Name = "Biyografi/Oto Biyografi", Description = "Biyografi/Oto Biyografi", Category = categories[4] });
            subCategories.Add(new SubCategory { Name = "Kişisel Gelişim", Description = "Kişisel Gelişim", Category = categories[5] });
            subCategories.Add(new SubCategory { Name = "Aile Çocuk", Description = "Aile Çocuk", Category = categories[5] });
            subCategories.Add(new SubCategory { Name = "Gezi", Description = "Gezi", Category = categories[5] });
            context.SubCategories.AddRange(subCategories);
            context.SaveChanges();

            List<Author> authors = new List<Author>();
            authors.Add(new Author{ FirstName = "İskender", LastName = "Pala", BirthDate = DateTime.Now, Detail = "İskender Pala, 8 Haziran 1958, Uşak, Türk profesör, yazar ve divan edebiyatı araştırmacısı.İlkokul’u Uşak Cumhuriyet İlköğretim Okulu’nda bitirdi.Liseyi Kütahya Lisesi’nde bitirdikten sonra İstanbul Üniversitesi Edebiyat Fakültesi Türk Dili ve Edebiyatı Bölümü’nde okumaya hak kazandı.Aynı okulda yaptığı lisans tez çalışması Câmiu'n-Nezâir’dir. Doktora çalışmasını ise \"Aşkî, Hayatı, Edebî Şahsiyeti ve Divânı\" başlığı altında yine İstanbul Üniversitesi’nde yaptı. Divan edebiyatı dalında 1983 yılında doktor, 1993 yılında İstanbul Üniversitesi’nde doçent, 1998 yılında da Kültür Üniversitesi’nde profesör oldu.Divan edebiyatı alanındaki çalışmalarıyla dikkat çeken yazarın çeşitli ansiklopedi ve dergilerde edebiyat araştırmacısı sıfatıyla yayımladığı bilimsel ve edebi makalelerinin yanında ortaokul ve liseler için yazdığı ders kitapları da bulunmaktadır. Ayrıca, Osmanlı deniz tarihiyle ilgili araştırmalarda bulunmuş ve bir kısmını kitaplaştırmıştır.", ImagePath= "https://www.haberler.com/trend/70/iskender-pala_4717_b.jpg" });
            authors.Add(new Author{ FirstName = "Ahmet", LastName = "Ümit", BirthDate = DateTime.Now, Detail = "Ahmet Ümit, 1960 yılında Gaziantep’te dünyaya geldi. 1983 yılında Marmara Üniversitesi’nin Kamu Yönetimi bölümünden mezun oldu. 1985-86 yılları arasında Moskova’da Sosyal Bilimler Enstitüsü’ne gitti. Türkiye’de önde gelen polisiye ve suç yazarlarından birisi olarak tanınmaktadır.Ahmet Ümit, ilk öyküsünü 1982 yılında kaleme aldı.Bu öykü 40 dilde yayımlanan bir dergide basıldı. Ahmet Ümit’in polisiye eserleri etkileyici sosyolojik ve psikolojik çözümlemelerin yanında Hititlere ve Osmanlı İmparatorluğu hakkındaki bilgilere ve motiflere yer vermesiyle dikkat çekmektedir.Sürükleyici dili ve etkileyici polisiye romanlarıyla Ahmet Ümit, ülkemizde en sevilen yazarlardan biri olma özelliğini taşımaktadır.İlk kitabı Sokağın Zulası(Şiir) 1989 yılında yayımlanan Ahmet Ümit, şiir ve deneme türünde de eserler vermiştir.", ImagePath= "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist__218019.jpg" });
            authors.Add(new Author{ FirstName = " John", LastName = "Steinbeck", BirthDate = DateTime.Now, Detail = "John", ImagePath= "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist__171913.jpg" });
            authors.Add(new Author{ FirstName = "Madeline", LastName = " Miller", BirthDate = DateTime.Now, Detail = "Madeline", ImagePath= "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist__7400.jpg" });
            authors.Add(new Author{ FirstName = "Kahraman", LastName = "Tazeoğlu", BirthDate = DateTime.Now, Detail = "Kahraman Tazeoğlu", ImagePath= "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist__306570.jpg" });
            authors.Add(new Author{ FirstName = " Georges", LastName = "Bataille", BirthDate = DateTime.Now, Detail = "Georges", ImagePath= "http://images.ykykultur.com.tr/upload/image/georgebataille-5290.jpg" });
            authors.Add(new Author{ FirstName = " Şermin", LastName = "Yaşar", BirthDate = DateTime.Now, Detail = "Şermin", ImagePath= "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist__260262.jpg" });
            authors.Add(new Author{ FirstName = "Muazzez İlmiye ", LastName = "Çığ", BirthDate = DateTime.Now, Detail = "Muazzez İlmiye Çığ", ImagePath= "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist__173228.jpg" });
            authors.Add(new Author{ FirstName = "Stephen ", LastName = "Hawking", BirthDate = DateTime.Now, Detail = "Hawking", ImagePath= "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist__94127.jpg" });
            context.Authors.AddRange(authors);
            context.SaveChanges();

            List<Book> books = new List<Book>();
            books.Add(new Book{ Name = "Katre-i Matem", Author = authors[0], SubCategory=subCategories[9], Count=50, ImagePath= "https://s.eticaretbox.com/551/pictures/2012113112727_katreimatemonkapak.jpg", Language=languages[0], NumberOfPages =450, Price=12, PublishingHouse=publishingHouses[6], YearOfPrinting=DateTime.Now ,Description="Deneme1"});
            books.Add(new Book { Name= "Aşkımız Eski Bir Roman", Author=authors[1],SubCategory=subCategories[9],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0001837961001-1.jpg", Language=languages[0],NumberOfPages=225,Price=15.39M,PublishingHouse=publishingHouses[1], YearOfPrinting = DateTime.Now, Description = "Deneme2" });
            books.Add(new Book { Name= "Bilinmeyen Bir Tanrıya", Author=authors[2],SubCategory=subCategories[9],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0001837880001-1.jpg", Language=languages[0],NumberOfPages=240,Price=19.60M,PublishingHouse=publishingHouses[2], YearOfPrinting = DateTime.Now, Description = "Deneme3" });
            books.Add(new Book { Name= "Ben Kirke", Author=authors[3],SubCategory=subCategories[9],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0001836978001-1.jpg", Language=languages[0],NumberOfPages=408,Price=22.75M,PublishingHouse=publishingHouses[3], YearOfPrinting = DateTime.Now, Description = "Deneme4" });
            books.Add(new Book { Name= "İntikam", Author=authors[4],SubCategory=subCategories[9],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0001837922001-1.jpg", Language=languages[0],NumberOfPages=248,Price=13.80M,PublishingHouse=publishingHouses[4], YearOfPrinting = DateTime.Now, Description = "Deneme5" });
            books.Add(new Book { Name= "Göğün Mavisi", Author=authors[5],SubCategory=subCategories[9],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0001837882001-1.jpg", Language=languages[0],NumberOfPages=135,Price=13.14M,PublishingHouse=publishingHouses[5], YearOfPrinting = DateTime.Now, Description = "Deneme6" });
            books.Add(new Book { Name= "Abartma Tozu", Author=authors[6],SubCategory=subCategories[0],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0001824299001-1.jpg", Language=languages[0],NumberOfPages=160,Price=22.10M,PublishingHouse=publishingHouses[5], YearOfPrinting = DateTime.Now, Description = "Deneme7" });
            books.Add(new Book { Name= "Kur'an İncil ve Tevrat'ın Sümerdeki Kökeni", Author=authors[7],SubCategory=subCategories[8],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0000000057279-1.jpg", Language=languages[0],NumberOfPages=110,Price=13.30M,PublishingHouse=publishingHouses[2], YearOfPrinting = DateTime.Now, Description = "Deneme8" });
            books.Add(new Book { Name= "Zamanın Kısa Tarihi", Author=authors[8],SubCategory=subCategories[3],Count=50,ImagePath= "https://i.idefix.com/cache/500x400-0/originals/0000000562120-1.jpg", Language=languages[0],NumberOfPages=255,Price=14.40M,PublishingHouse=publishingHouses[2], YearOfPrinting = DateTime.Now, Description = "Deneme9" });
            context.Books.AddRange(books);
            context.SaveChanges();

            List<Campaign> campaigns = new List<Campaign>();
            campaigns.Add(new Campaign { Name="Yaza Merhaba", DiscountAmount=20, IsActive=true, ImagePath= "https://i.idefix.com/pimages/Content/Uploads/BannerFiles/idefix/ahmetumit5new.png", Category=categories[4]});
            campaigns.Add(new Campaign { Name="Okullar Açılsın Macera Başlasın", DiscountAmount=40, IsActive=true, ImagePath= "https://i.idefix.com/pimages/Content/Uploads/BannerFiles/idefix/idefix_AvantajKitap_1156x535px.png", Category=categories[1]});
            campaigns.Add(new Campaign { Name="Karneyi Getir Dilediğin Kitabı İndirimli Al", DiscountAmount=50, IsActive=true, ImagePath= "https://i.idefix.com/pimages/Content/Uploads/BannerFiles/idefix/yabanci-kitaplar1.png", Category=categories[2]});
            campaigns.Add(new Campaign { Name="Hadi Sende Bize Katıl ve Keyifli Alışverişin Tadını Çıkar", DiscountAmount=30, IsActive=true, ImagePath= "https://i.idefix.com/pimages/Content/Uploads/BannerFiles/idefix/0919_i_u_x_2560x535_idefix_KoboEylul_onsiparis_banner.png", Category=categories[3]});
            context.Campaigns.AddRange(campaigns);
            context.SaveChanges();

            
        }
    }
}
