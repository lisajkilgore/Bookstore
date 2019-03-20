namespace Bookstore.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<Bookstore.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Bookstore.Data.ApplicationDbContext";
        }

        protected override void Seed(Bookstore.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    ); 
            //
            var admin = context.Users.First();
            context.Book.AddOrUpdate(x => x.BookId,

new Book() { BookId = 1, OwnerId = new Guid(admin.Id), TypeOfBook = BookType.Biographies_Memoirs, Title = "Becoming", Author = "Michelle Obama", IsFiction = false, IsNewRelease = true, IsBestSeller = true, Price = 19.50m, Inventory = 100, Description = "Biography: Michelle Robinson Obama served as First Lady of the United States from 2009 to 2017. A graduate of Princeton University and Harvard Law School, Mrs. Obama started her career as an attorney at the Chicago law firm Sidley & Austin, where she met her future husband, Barack Obama. She later worked in the Chicago mayor�s office, at the University of Chicago, and at the University of Chicago Medical Center. Mrs. Obama also founded the Chicago chapter of Public Allies, an organization that prepares young people for careers in public service." },
new Book() { BookId = 2, OwnerId = new Guid(admin.Id), TypeOfBook = BookType.Mystery_Suspense, Title = "Where the Crawdads Sing", Author = "Delia Owens", IsFiction = true, IsNewRelease = false, IsBestSeller = true, Price = 15.60m, Inventory = 97, Description = "For years, rumors of the 'Marsh Girl' have haunted Barkley Cove, a quiet town on the North Carolina coast. So in late 1969, when handsome Chase Andrews is found dead, the locals immediately suspect Kya Clark, the so-called Marsh Girl. But Kya is not what they say. Sensitive and intelligent, she has survived for years alone in the marsh that she calls home, finding friends in the gulls and lessons in the sand. Then the time comes when she yearns to be touched and loved. When two young men from town become intrigued by her wild beauty, Kya opens herself to a new life--until the unthinkable happens.  Perfect for fans of Barbara Kingsolver and Karen Russell, Where the Crawdads Sing is at once an exquisite ode to the natural world, a heartbreaking coming-of-age story, and a surprising tale of possible murder. Owens reminds us that we are forever shaped by the children we once were, and that we are all subject to the beautiful and violent secrets that nature keeps." },
new Book() { BookId = 3, OwnerId = new Guid(admin.Id), TypeOfBook = BookType.Biographies_Memoirs, Title = "Educated", Author = "Tara Westover", IsFiction = false, IsNewRelease = false, IsBestSeller = true, Price = 16.80m, Inventory = 71, Description = "Born to survivalists in the mountains of Idaho, Tara Westover was seventeen the first time she set foot in a classroom. Her family was so isolated from mainstream society that there was no one to ensure the children received an education, and no one to intervene when one of Tara�s older brothers became violent. When another brother got himself into college, Tara decided to try a new kind of life. Her quest for knowledge transformed her, taking her over oceans and across continents, to Harvard and to Cambridge University. Only then would she wonder if she�d traveled too far, if there was still a way home." },
new Book() { BookId = 4, OwnerId = new Guid(admin.Id), 13, "The Hate U Give", "Angie Thomas", 1, 0, 1, 12.19, 50, "Sixteen-year-old Starr Carter moves between two worlds: the poor neighborhood where she lives and the fancy suburban prep school she attends. The uneasy balance between these worlds is shattered when Starr witnesses the fatal shooting of her childhood best friend Khalil at the hands of a police officer. Khalil was unarmed.  Soon afterward, his death is a national headline. Some are calling him a thug, maybe even a drug dealer and a gangbanger. Protesters are taking to the streets in Khalil�s name. Some cops and the local drug lord try to intimidate Starr and her family. What everyone wants to know is: what really went down that night? And the only person alive who can answer that is Starr.  But what Starr does�or does not�say could upend her community. It could also endanger her life." },
new Book() { 5, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 10, "Eight Dates", "John Gottman", 0, 1, 0, 17.83, 25, "Navigating the challenges of long-term commitment takes effort�and it just got simpler, with this empowering, step-by-step guide to communicating about the things that matter most to you and your partner. Drawing on forty years of research from their world-famous Love Lab, Dr. John Gottman and Dr. Julie Schwartz Gottman invite couples on eight fun, easy, and profoundly rewarding dates, each one focused on a make-or-break issue: trust, conflict, sex, money, family, adventure, spirituality, and dreams.   Interactive activities and prompts provide motivation to stay open, stay curious, and, most of all, stay talking to each other. And the range�from the four skills you need for intimate conversation (including Put Into Words What You Are Feeling) to tips on being honest about your needs, while also validating your partner�s own emotions�will resonate, whether you�re newly together or a longtime couple looking to fortify your bond. You will discover (or rediscover) your partner like never before�and be able to realize your hopes and dreams for the love you desire and deserve." },
new Book() { 6, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 10, "Girl, Wash Your Face", "Rachel Hollis", 0, 0, 1, 14.99, 37, "As the founder of the lifestyle website TheChicSite.com and CEO of her own media company, Rachel Hollis developed an immense online community by sharing tips for better living while fearlessly revealing the messiness of her own life. Now, in this challenging and inspiring new book, Rachel exposes the twenty lies and misconceptions that too often hold us back from living joyfully and productively, lies we�ve told ourselves so often we don�t even hear them anymore.  With painful honesty and fearless humor, Rachel unpacks and examines the falsehoods that once left her feeling overwhelmed and unworthy, and reveals the specific practical strategies that helped her move past them. In the process, she encourages, entertains, and even kicks a little butt, all to convince you to do whatever it takes to get real and become the joyous, confident woman you were meant to be.  With unflinching faith and rock-hard tenacity, Girl, Wash Your Face shows you how to live with passion and hustle--and how to give yourself grace without giving up." },
new Book() { 7, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 9, "The Last Romantics", "Tara Conklin", 1, 1, 0, 16.19, 24, "When the renowned poet Fiona Skinner is asked about the inspiration behind her iconic work, The Love Poem, she tells her audience a story about her family and a betrayal that reverberates through time.  It begins in a big yellow house with a funeral, an iron poker, and a brief variation forever known as the Pause: a free and feral summer in a middle-class Connecticut town. Caught between the predictable life they once led and an uncertain future that stretches before them, the Skinner siblings�fierce Renee, sensitive Caroline, golden boy Joe and watchful Fiona�emerge from the Pause staunchly loyal and deeply connected.  Two decades later, the siblings find themselves once again confronted with a family crisis that tests the strength of these bonds and forces them to question the life choices they�ve made and ask what, exactly, they will do for love.   A sweeping yet intimate epic about one American family, The Last Romantics is an unforgettable exploration of the ties that bind us together, the responsibilities we embrace and the duties we resent, and how we can lose�and sometimes rescue�the ones we love. A novel that pierces the heart and lingers in the mind, it is also a beautiful meditation on the power of stories�how they navigate us through difficult times, help us understand the past, and point the way toward our future." },
new Book() { 8, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 5, "The Island of Sea Women", "Lisa See", 1, 1, 1, 18.90, 45, "Mi-ja and Young-sook, two girls living on the Korean island of Jeju, are best friends that come from very different backgrounds. When they are old enough, they begin working in the sea with their village�s all-female diving collective, led by Young-sook�s mother. As the girls take up their positions as baby divers, they know they are beginning a life of excitement and responsibility but also danger.  Despite their love for each other, Mi-ja and Young-sook�s differences are impossible to ignore. The Island of Sea Women is an epoch set over many decades, beginning during a period of Japanese colonialism in the 1930s and 1940s, followed by World War II, the Korean War and its aftermath, through the era of cell phones and wet suits for the women divers. Throughout this time, the residents of Jeju find themselves caught between warring empires. Mi-ja is the daughter of a Japanese collaborator, and she will forever be marked by this association. Young-sook was born into a long line of haenyeo and will inherit her mother�s position leading the divers in their village. Little do the two friends know that after surviving hundreds of dives and developing the closest of bonds, forces outside their control will push their friendship to the breaking point.  This beautiful, thoughtful novel illuminates a world turned upside down, one where the women are in charge, engaging in dangerous physical work, and the men take care of the children. A classic Lisa See story�one of women�s friendships and the larger forces that shape them�The Island of Sea Women introduces readers to the fierce and unforgettable female divers of Jeju Island and the dramatic history that shaped their lives." },
new Book() { 10, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 13, "Turtles All the Way Down", "John Green", 1, 0, 1, 12.95, 67, "Sixteen-year-old Aza never intended to pursue the mystery of fugitive billionaire Russell Pickett, but there�s a hundred-thousand-dollar reward at stake and her Best and Most Fearless Friend, Daisy, is eager to investigate. So together, they navigate the short distance and broad divides that separate them from Russell Pickett�s son, Davis.     Aza is trying. She is trying to be a good daughter, a good friend, a good student, and maybe even a good detective, while also living within the ever-tightening spiral of her own thoughts.    In his long-awaited return, John Green, the acclaimed, award-winning author of Looking for Alaska and The Fault in Our Stars, shares Aza�s story with shattering, unflinching clarity in this brilliant novel of love, resilience, and the power of lifelong friendship." },
new Book() { 11, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 3, "You Are My Happy", "Hoda Kotb", 1, 1, 1, 12.98, 52, "As mama bear and her cub cuddle together before closing their eyes for a good night�s sleep, they reflect on the everyday wonders of life that make them happy.  Inspired by her own nighttime routine with her daughter, Haley Joy, Kotb creates another beautiful treasure for parents and children to enjoy together. With charming and lush illustrations from bestselling artist Suzie Mason, this soothing yet playful lullaby explores the simple joy of taking a moment to be grateful." },
new Book() { 12, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 13, "The Sun Is Also a Star", "Nicola Yoon", 1, 0, 1, 17.75, 31, "Soon to be a major motion picture starring Yara Shahidi and Charles Melton! The #1 New York Times bestseller and National Book Award Finalist from the bestselling author of Everything, Everything will have you falling in love with Natasha and Daniel as they fall in love with each other.  Natasha: I�m a girl who believes in science and facts. Not fate. Not destiny. Or dreams that will never come true. I�m definitely not the kind of girl who meets a cute boy on a crowded New York City street and falls in love with him. Not when my family is twelve hours away from being deported to Jamaica. Falling in love with him won�t be my story.  Daniel: I�ve always been the good son, the good student, living up to my parents� high expectations. Never the poet. Or the dreamer. But when I see her, I forget about all that. Something about Natasha makes me think that fate has something much more extraordinary in store�for both of us.  The Universe: Every moment in our lives has brought us to this single moment. A million futures lie before us. Which one will come true?" },
new Book() { 13, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 13, "Speak", "Laurie Halse Anderson", 0, 0, 1, 17.99, 72, "The first ten lies they tell you in high school.  'Speak up for yourself--we want to know what you have to say.' From the first moment of her freshman year at Merryweather High, Melinda knows this is a big fat lie, part of the nonsense of high school. She is friendless, outcast, because she busted an end-of-summer party by calling the cops, so now nobody will talk to her, let alone listen to her. As time passes, she becomes increasingly isolated and practically stops talking altogether. Only her art class offers any solace, and it is through her work on an art project that she is finally able to face what really happened at that terrible party: she was raped by an upperclassman, a guy who still attends Merryweather and is still a threat to her. Her healing process has just begun when she has another violent encounter with him. But this time Melinda fights back, refuses to be silent, and thereby achieves a measure of vindication. In Laurie Halse Anderson''s powerful novel, an utterly believable heroine with a bitterly ironic voice delivers a blow to the hypocritical world of high school. She speaks for many a disenfranchised teenager while demonstrating the importance of speaking up for oneself.  Speak was a 1999 National Book Award Finalist for Young People''s Literature." },
new Book() { 14, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 13, "Dear Evan Hansen", "Val Emmich, Steven Levenson, Benj Pasek, Justin Paul", 1, 0, 1, 12.34, 44, "From the show's creators comes the groundbreaking novel inspired by the hit Broadway show Dear Evan Hansen. Today''s going to be an amazing day and here''s why...  When a letter that was never meant to be seen by anyone draws high school senior Evan Hansen into a family''s grief over the loss of their son, he is given the chance of a lifetime: to belong. He just has to stick to a lie he never meant to tell, that the notoriously troubled Connor Murphy was his secret best friend.  Suddenly, Evan isn''t invisible anymore--even to the girl of his dreams. And Connor Murphy''s parents, with their beautiful home on the other side of town, have taken him in like he was their own, desperate to know more about their enigmatic son from his closest friend. As Evan gets pulled deeper into their swirl of anger, regret, and confusion, he knows that what he''s doing can''t be right, but if he''s helping people, how wrong can it be?   No longer tangled in his once-incapacitating anxiety, this new Evan has a purpose. And a website. He''s confident. He''s a viral phenomenon. Every day is amazing. Until everything is in danger of unraveling and he comes face to face with his greatest obstacle: himself.  A simple lie leads to complicated truths in this big-hearted coming-of-age story of grief, authenticity and the struggle to belong in an age of instant connectivity and profound isolation." },
new Book() { 15, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 3, "The Good Egg", "Jory John", 1, 0, 1, 16.63, 28, "From the bestselling creators of The Bad Seed, a timely story about not having to be Grade A perfect!  Meet the good egg. He�s a verrrrrry good egg indeed.  But trying to be so good is hard when everyone else is plain ol� rotten.  As the other eggs in the dozen behave badly, the good egg starts to crack from all the pressure of feeling like he has to be perfect.  So, he decides enough is enough! It�s time for him to make a change�  Dynamic duo Jory John and Pete Oswald hatch a funny and charming story that reminds us of the importance of balance, self-care, and accepting those who we love (even if they are sometimes a bit rotten).  Perfect for reading aloud and shared story time!" }
new Book() { 16, 462c6f0e - 3d84 - 4e60 - 9c1a - 624326c5dc69, 3, "The Wonky Donkey", "Craig Smith, Katz Cowley (Illustrator)", 1, 0, 1, 7.99, 41, "Children will be in fits of laughter with this perfect read-aloud tale of an endearing donkey. By the book''s final page, readers end up with a spunky, hanky-panky, cranky, stinky, dinky, lanky, honky-tonky, winky wonky donkey!" },

        }
    };
}

