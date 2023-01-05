using System;

namespace TaskPicture      
{
    class Task
    {
        static void Main(string[] args)
        {
            int picturesCount = 52;  
            int rowPictures = 3;   
            int fullRow;    
            int remainsRow;
            Console.WriteLine($"Нам данно {picturesCount} картинки, которые выводятся в {rowPictures} ряда, сколько получится рядов?");
            fullRow = picturesCount / rowPictures;
            remainsRow = picturesCount % rowPictures;
            Console.WriteLine($"На экране выведется полных {fullRow} рядов и {remainsRow} сверх меры");

        }
    }
}
