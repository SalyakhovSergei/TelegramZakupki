using System;
using TelegramTestBot.Models;

namespace TelegramTestBot.Data
{
    public class Products
    {
        public string[] category = new string[] {   "/закупка основных средств",
                                                     "/закупка расходных материалов",
                                                     "/закупка тары",
                                                     "/закупка ИТ девайсов",
                                                     "/закупка прочего" };

        public static readonly Product[] ListOfProducts = new Product[] 
        {
         new Product
         {
             Id = Guid.Parse("E6BBF4C9-67D9-47C2-BCDA-FF2B12E035F7"),
             Category = "/закупка основных средств",
             Name = "Тампон-зонд с транспортной средой (БЕЛАЯ) Stuart, стер. в проб. п/п (шт)/Медика-Плюс"
         },
         new Product
         {
             Id = Guid.Parse("D82AF42B-FA62-4429-BF04-2A3FB0971584"),
             Category = "/закупка основных средств",
             Name = "Тампон-зонд с транспортной средой (ЧЕРНАЯ) Amies, стер. в проб. п/п (шт)/Медика-Плюс"
         },
         new Product
         {
             Id = Guid.Parse("72B2E5D1-9DA2-4F9E-933D-1DB9B484C816"),
             Category = "/закупка основных средств",
             Name = "Тампон- зонд  (ПП + вискоза ) в пробирке без среды  стер.13 x 150 N 1800/уп. Китай G 1022"
         },
         new Product
         {
             Id = Guid.Parse("F6D20902-E02C-44C7-BFB2-7A021342EAF0"),
             Category = "/закупка основных средств",
             Name = "Тампон - зонд { П + вискоза ) стер. в пробирке  НР 5008 Китай"
         },
         new Product
         {
             Id = Guid.Parse("EF616052-0AE0-426C-9EEB-EF258DA72AE5"),
             Category = "/закупка основных средств",
             Name = "Тампон - зонд { П + вискоза ) стер. в пробирке  12 x 150 EXIM  Китай"
         },
         new Product
         {
             Id = Guid.Parse("74F70771-232D-4A73-8C6A-C5AF301E4360"),
             Category = "/закупка основных средств",
             Name = "Тубфер для взятия мазков о средой  Эймса 13x150 мм с голубой крышкой 50 шт /уп. Китай"
         },
         new Product
         {
             Id = Guid.Parse("098D5B8A-8EC9-402B-872B-6DB777524EF6"),
             Category = "/закупка основных средств",
             Name = "Тубфер для взятия мазков о средой  Amies (c углем) 13x150 мм с голубой крышкой 50 шт/уп. Китай"
         },


        }; 
    }
}
