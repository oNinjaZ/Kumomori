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
                Author = "竹町",
                Title = "スパイ教室01",
                Description = "各国がスパイによる戦争を繰り広げる世界。任務成功率100％、性格に難ありの凄腕スパイ・クラウスは、死亡率九割を超える不可能任務専門機関を創設するのだが……選ばれたのは何故か未熟な7人の少女たちで!?",
                PageCount = 321,
                Price = (long)715m,
                CoverUrl = "https://rimg.bookwalker.jp/6598463/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2020, 1, 20)
            },
            new Book
            {
                Author = "竹町",
                Title = "スパイ教室02",
                Description = "不可能任務を見事達成した新生スパイチーム『灯』。次のミッションは冷酷無惨の暗殺者《屍》の殺害。より過酷な任務に、クラウスは現時点における『灯』最強メンバーを選抜することになり——。",
                PageCount = 304,
                Price = (long)715m,
                CoverUrl = "https://rimg.bookwalker.jp/2290673/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2020, 4, 20)
            },
            new Book
            {
                Author = "竹町",
                Title = "スパイ教室03",
                Description = "暗殺者《屍》の任務後、選抜組の少女たちが出会ったのは、記憶喪失で出自不明の少女――アネットの母。感動の再会に盛り上がる一同だが、それはチームを分断する残酷な運命のはじまりだった。",
                PageCount = 320,
                Price = (long)737m,
                CoverUrl = "https://rimg.bookwalker.jp/4105193/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2020, 8, 20)
            },
            new Book
            {
                Author = "阿智太郎",
                Title = "星空☆アゲイン",
                Description = "　夜空から星が失われた村で、高校二年生の今村星馬は日々を惰性で過ごしていた。なにかを始めようにも、きっかけが見つからない。\nしかし、そんなモノクロの日常が、不思議な少女との出会いによって色付いてゆく。\n 「わたしは今年、この学校で、星夜祭を復活させます!!!」\n クラスに留学してきた銀色の髪の少女、プレア・モモベルの宣言。\n そして、偶然彼女の“秘密”を知ってしまった星馬は、同級生の英人や千湯里も巻き込んで星空を取り戻す手伝いをすることに……!?\n 忘れられないひと夏の出会いと別れを描いた、青春ノスタルジック・ファンタジー！",
                PageCount = 273,
                Price = (long)693m,
                CoverUrl = "https://rimg.bookwalker.jp/1548605/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2022, 4, 10)
            },
            new Book
            {
                Author = "綾里けいし",
                Title = "魔法科高校の劣等生",
                Description = "　2095年9月。第一高校にある荷物が誤配される。その中身は未確認文明の魔法技術製品『聖遺物（レリック）』。人知れず自動的に起動していて――。\n　司波達也は、気がつくと森の中にいた。夢の中のような世界に困惑している達也の前に、深雪が現れる。\n　妹と無事に再会できたことに安堵する達也だが、深雪は純白のドレスを身にまとい、国王の娘になりきっていて!?\n　これは、いつもの『魔法科』ではない『魔法科高校』の物語。『魔法科』10周年を記念して、TVアニメ第1期パッケージに収録された『ドリームゲーム』を電撃文庫化！\n",
                PageCount = 432,
                Price = (long)803m,
                CoverUrl = "https://rimg.bookwalker.jp/1931225/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2022, 6, 10)
            },
            new Book
            {
                Author = "遠野　海人",
                Title = "眠れない夜は羊を探して",
                Description = "　幸運をくれると人気の占いアプリ〈孤独な羊〉にはある噂が。画面上を行きかうカラフルな羊たちの中に、もしも黒い羊が現れたら、どんな願いも叶うらしい。それが誰かへの殺意だとしても――。 \n同級生に復讐したい少年。祖母の介護に疲れ果てた女子中学生。浮気した彼氏を殺したい女子大生。周囲に迷惑ばかりかける自分を消したい新入社員。理想の死を追い求める少女。余命宣告を受けたサラリーマン……。真夜中のアプリに集う人々の、いくつもの眠れない夜と殺意を描いた15編の短編集。",
                PageCount = 242,
                Price = (long)704m,
                CoverUrl = "https://rimg.bookwalker.jp/5623205/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2022, 3, 25)
            },
            new Book
            {
                Author = "あまさきみりと",
                Title = "星降る夜になったら",
                Description = "この身が滅びようとも、佳乃を救いたい――。だけど、\n\n《それだけを願っても救われないことは分かっていた》\n\n花菱准汰の日常は、起きる⇒学校へ行く⇒遊ぶ⇒寝る。ただそれだけ、省エネで適当であることは彼らしさだった。渡良瀬佳乃は真逆。作業BGMでも、この作業に聴く音楽コレ、食べ物のベスト温度はコレと超が付くほどのこだわり派。\nそんな2人はとある補修を通じて出会い、恋にも似た感情を抱くようになる。が、佳乃は謎の奇病に伏すことに。……しかし、奇跡は起きた。彼と彼女は他人となり、性格も変更され、生きることが許された。\n\n――両思いが故にすれ違うことを選んだ、最高に美しくも儚い命の物語。\n【電子限定！書き下ろし特典つき】",
                PageCount = 389,
                Price = (long)726m,
                CoverUrl = "https://rimg.bookwalker.jp/9275483/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2022, 6, 25)
            },
            new Book
            {
                Author = " たままる",
                Title = "鍛冶屋ではじめる異世界スローライフ",
                Description = "深夜残業を終えて帰宅中、猫を助けてトラックにはねられたエイゾウ。その猫は神様っぽい何かだったらしく、見返りとして、希望のスキルを貰って異世界に転生することに。\n「趣味のモノづくりで暮らしたい」と願い、鍛冶に始まる生産スキルで早速ナイフを作ると——藁束が切れた。台ごと。 \nどうやら貰ってしまったのは国政を揺るがしかねない業物を生み出すチートのようで……？　そんなの危なっかしいし、そこそこの力で鍛冶屋としてのんびり生計を立てよう……。",
                PageCount = 321,
                Price = (long)1320m,
                CoverUrl = "https://rimg.bookwalker.jp/6295063/BM2j7K0aiKyzud2kfkni6g__.jpg",
                Type = "ライトノベル",
                QuantityInStock = 10,
                PublishDate = new DateTime(2022, 12, 10)
            }
        };

        context.Books.AddRange(books);
        context.SaveChanges();
    }
}