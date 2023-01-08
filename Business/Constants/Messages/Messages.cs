using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public class Messages
    {
        public static string AboutAdded = "Hakkında Eklendi";
        public static string AboutDeleted = "Hakkında Silindi";
        public static string AboutUpdated = "Hakkında Güncellendi";

        public static string BlogAdded = "Blog Eklendi";
        public static string BlogStatusChanged = "Blog Durumu Güncellendi";
        public static string BlogUpdated = "Blog Güncellendi";

        public static string CommentAdded = "Yorum Eklendi";
        public static string CommentDeleted = "Yorum Silindi";
        public static string CommentUpdated = "Yorum Güncellendi";

        public static string ContactAdded = "İletişim Eklendi";
        public static string ContactDeleted = "İletişim Silindi";
        public static string ContactUpdated = "İletişim Güncellendi";

        public static string CategoryAdded = "Kategori Eklendi";
        public static string CategoryDeleted = "Kategori Silindi";
        public static string CategoryUpdated = "Kategori Güncellendi";

        public static string MessageSended = "Mesaj Gönderildi";
        public static string MessageDeleted = "Mesaj Silindi";
        public static string MessagesLoaded = "Mesajlarınız Yüklendi";

        public static string AuthorizationDenied = "Bu İşlem İçin Yetkiniz Yok";
        public static string UserRegistered = "Kayıt Başarılı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated = "Anahtar Oluşturuldu";
        public static string UserUpdated = "Kullanıcı Bilgileri Güncellendi";

        public static string FirstNameNotEmpty = "İsim Alanı Boş Bırakılamaz";
        public static string FirstNameLenght = "İsim En Az 2 En Fazla 50 Karakter İçerebilir";
        public static string LastNameLenght = "Soyisim En Az 2 En Fazla 50 Karakter İçerebilir";
        public static string LastNameNotEmpty = "Soyisim Alanı Boş Bırakılamaz";
        public static string EmailInvalid = "Geçerli Bir Email Adresi Yazınız";
        public static string PasswordMinimumLength = "Şifre En Az 5 Karakter İçermelidir";

        public static string BlogTitleNotEmpty = "Blog Başlığı Boş Bırakılamaz";
        public static string BlogContentNotEmpty = "Blog İçeriği Boş Bırakılamaz";
        public static string BlogImageNotEmpty = "Blog Resmi Ekleyiniz";
        public static string BlogTitileLength = "Blog Başlığı Minimum 2 Karakter Maksimum 50 Karakter İçermelidir.";
        public static string BlogContentLength = "Blog İçeriği Minimum 150 Karakter İçermelidir.";

        public static string Subscribed = "Abone Olundu";

        public static string MaintenanceTime = "22.00-22.59 arasında sistem bakımda";

    }
}
