using Kumomori.Api.Entities;

namespace Kumomori.Api.Data;

public static class DbInitializer
{
    public static void Initialize(StoreContext context)
    {
        if (context.Books.Any()) return;

        var books = new List<Book>
        {
            new Book
            {
                Author = "J.R.R. Tolkien",
                Title = "The Lord of the Rings",
                Description = "The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien. The story began as a sequel to Tolkien's 1937 novel The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-known novels ever written, and it has been adapted into various media formats and is still in use today.",
                PageCount = 352,
                Price = (long)19.99m,
                CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zu%2BQ3pwgL.jpg",
                Type = "Fiction",
                QuantityInStock = 10,
                PublishDate = new DateTime(1954, 9, 29)
            },
            new Book
            {
                Author = "J.R.R. Tolkien",
                Title = "The Hobbit",
                Description = "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien. It was published on 21 September 1937 by the English-speaking press and was serialized in the 1937 issue of The Hobbit. The story follows the quest of hobbit Bilbo Baggins to leave the Shire and go to Mount Doom to destroy the Ring, which was stolen by Smaug the Magnificent. Bilbo Baggins is accompanied by several Hobbit friends, including Gandalf the Grey and the Hobbit's cousin, Peregrin Took. The story's antagonist, Smaug the Magnificent, is a dragon.",
                PageCount = 304,
                Price = (long)9.99m,
                CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zu%2BQ3pwgL.jpg",
                Type = "Fiction",
                QuantityInStock = 10,
                PublishDate = new DateTime(1937, 9, 21)
            },
            new Book
            {
                Author = "J.R.R. Tolkien",
                Title = "The Silmarillion",
                Description = "The Silmarillion is a fantasy novel by English author J. R. R. Tolkien. It was published on 21 September 1937 by the English-speaking press and was serialized in the 1937 issue of The Hobbit. The story follows the quest of hobbit Bilbo Baggins to leave the Shire and go to Mount Doom to destroy the Ring, which was stolen by Smaug the Magnificent. Bilbo Baggins is accompanied by several Hobbit friends, including Gandalf the Grey and the Hobbit's cousin, Peregrin Took. The story's antagonist, Smaug the Magnificent, is a dragon.",
                PageCount = 304,
                Price = (long)9.99m,
                CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zu%2BQ3pwgL.jpg",
                Type = "Fiction",
                QuantityInStock = 10,
                PublishDate = new DateTime(1937, 9, 21)
            },
            new Book
            {
                Author = "長月達平",
                Title = "Re：ゼロから始める異世界生活 2",
                Description = "あら、目覚めましたね、姉様」「そうね、目覚めたわね、レム」王都での『死のループ』を抜け出したスバル。目覚めたのは豪華な屋敷の一室。目の前に現れたのは――双子の美少女毒舌メイド・ラム＆レムだった",
                PageCount = 334,
                Price = (long)9.99m,
                CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zu%2BQ3pwgL.jpg",
                Type = "Fiction",
                QuantityInStock = 10,
                PublishDate = new DateTime(2015, 3, 17)
            },
            new Book
            {
                Author = "長月達平",
                Title = "Re：ゼロから始める異世界生活",
                Description = "突如、異世界へ召喚された高校生ナツキスバル。普通の一般人である彼に特殊な知識も技術も武力もあるわけもなく、さらに手にした能力は『死んだら時間が巻き戻る』という痛みを伴う『死に戻り』のみだった！",
                PageCount = 334,
                Price = (long)9.99m,
                CoverUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zu%2BQ3pwgL.jpg",
                Type = "Fiction",
                QuantityInStock = 10,
                PublishDate = new DateTime(2015, 3, 18)
            }
        };

        context.Books.AddRange(books);
        context.SaveChanges();
    }
}