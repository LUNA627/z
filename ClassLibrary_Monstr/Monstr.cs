using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.IO;

namespace ClassLibrary_Monstr
{
    public class Monstr
    {
        static Random rand = new Random();

        public string name;  // Имя монстра
        public string image; // Путь к изображению
        private int maxHp; // Максимальное здоровье
        int hp; // Текущее здоровье
        int dmg; // Наносимый урон
        public string CurrentImage; // Текущее изображение

        static string[] haracts = { "Добрый", "Славный", "Хитрый", "Злой", "Умный", "Глупый" };
        static string[] names = { "Гоблин", "Рыцарь", "Эльф", "Маг", "Воин" };
         public static string[] images = { "гоблин.jpg", "рыцарь.jpg", "эльф.jpg", "маг.jpg", "воин.jpg" };


        public Monstr()
        {
            name = names[rand.Next(names.Length)] + " " + haracts[rand.Next(haracts.Length)];
            image = images[rand.Next(images.Length)];
        }



        // Методы доступа 
        public int GetHp()
        {
            return hp;
        }

        public int GetMaxHp()
        {
            return maxHp;
        }

        // Установка здоровья в заданном диапазоне
        public void SetHp(int min, int max)
        {
            hp = rand.Next(min, max + 1);
            maxHp = rand.Next(min, max + 1);
            hp = maxHp; // Устанавливаем текущее здоровье равным максимальному
        }


        public int GetDmg()
        {
            return dmg;
        }


        // Установка урона в заданном диапазоне
        public void SetDmg(int min, int max)
        {
            dmg = rand.Next(min, max + 1);
        }



        // Получение урона (с учетом возможного двойного урона)
        public void TakeDmg (int dmg, bool doubleDmg)
        {

            int actualDamage = doubleDmg ? dmg * 2 : dmg;
            hp = Math.Max(0, hp - actualDamage); // Здоровье никогда не станет отрицательным
            hp = Math.Min(hp, maxHp); // Гарантируем, что здоровье не превысит максимум 

        }


        // Проверка, жив ли монстр
        public bool Cheak => hp > 0;


        public string Status()
        {
            return Cheak
                ? $"{name}\nЗдоровье: {hp}\nУрон: {dmg}"
                : $"{name} (Погиб)";
        }



        public override string ToString()
        {
            return Status();
        }
    }
}
