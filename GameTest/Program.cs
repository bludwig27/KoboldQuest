using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoboldQuest
{
    // **************************************************
    //
    // Title: Kobold Quest
    // Description: Text Adventure Game
    // Application Type: Console
    // Author: Ludwig, Ben
    // Dated Created: 7/12/21
    // Last Modified: 7/25/21
    //
    // **************************************************

    class Game
    
    {
        
        static bool goal = false;

        public static void Room1(List<string> items)
        {
            //The starting room, in which the player chooses an item to take with them (or nothing).

            bool goal = false;
            string playerSelection;

            Header("Outside the Dragon's Chamber");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("\"GO, AND DO NOT RETURN UNTIL YOU HAVE FULFILLED YOUR MISSION.\"");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Slowly, the heavy stone doors scrape closed behind you.");
            Console.WriteLine("A few other kobolds gather around, chirping sympathetically.\nThey are sorry to see you go, but glad that they were not chosen.");
            Console.WriteLine("Gathering a few trinkets together, they offer one to aid you in your task. Which will you accept?");
            Console.Write("A dark c)loak, a box of m)atches, a d)agger, or n)othing? [c, m, d, n, i, q]");
            playerSelection = Console.ReadLine().ToLower();
            switch(playerSelection)
            {
                case "c":
                    Console.WriteLine("Though your coppery scales give you protection and modesty enough, they do tend to stand out. \nYou take the cloak, hoping it will be of some use.");
                    items.Add("cloak");
                    ContinuePrompt();
                    Room2(items);
                    break;

                case "m":
                    Console.WriteLine("Perhaps the ability to create fire will prove useful. You take the box of large wooden matches.");
                    items.Add("matches");
                    ContinuePrompt();
                    Room2(items);
                    break;

                case "d":
                    Console.WriteLine("The dagger is badly tarnished, but it still has a sharp edge. You take it, warbling a quiet thank-you.");
                    items.Add("dagger");
                    ContinuePrompt();
                    Room2(items);
                    break;

                case "n":
                    Console.WriteLine("You silently press forward, taking none of the offered items. Your kin stare at you in awe as you set off unaided.");
                    ContinuePrompt();
                    Room2(items);
                    break;

                case "i":
                    Inventory(items);
                    Room1(items);
                    break;

                case "q":
                    break;

                default:
                    Console.WriteLine("Please enter a valid letter.");
                    ContinuePrompt();
                    Room1(items);
                    break;

            }
            
        }
        public static void Room2(List<string> items)
        {
            //The crossroads room, where the player chooses to go left or right. These lead to different sets of rooms.

            string playerSelection;

            if (items.Contains("matches"))
            {
                Header("Crossroads");
                Console.WriteLine("You have come to an underground crossroads. \nIt is very dark, but you can follow scent trails to the right or the left.\n"+ 
                    "The passage to the right smells like resin and ink.\nThe passage to the left smells like iron and cat.");
                Console.Write("Go r)ight, go l)eft, or strike a ");
                RedFont("m)atch");
                Console.Write("? [r, l, m, i, q] ");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "r":
                        Console.WriteLine("You follow the path upward and to the right.");
                        ContinuePrompt();
                        Room4(items);
                        break;

                    case "l":
                        Console.WriteLine("You follow the downward path to the left.");
                        ContinuePrompt();
                        Room3(items);
                        break;

                    case "m":
                        Console.Write("Striking a match, you can now see a mural painted on the wall.\nIn vibrant hues, it portrays the rise of Klingsor as ruler of these caverns.\n" +
                            "A map of the caverns is depicted here. Down the left path, it seems, you will encounter a sphinx.\nThe letter R is painted beside it.\n" +
                            "The path to the right leads to Klingsor's personal library, forbidden to your kind,\nbut a small mark indicates that there is a secret passage.");
                        ContinuePrompt();
                        Room2(items);
                        break;

                    case "i":
                        Inventory(items);
                        Room2(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Please enter a valid letter.");
                        ContinuePrompt();
                        Room2(items);
                        break;
                }
            }
            else
            {
                Header("Crossroads");
                Console.WriteLine("You have come to an underground crossroads. \nIt is very dark, but you can follow scent trails to the right or the left.\n" +
                    "The passage to the right smells like resin and ink.\nThe passage to the left smells like iron and cat.");
                Console.Write("Go r)ight, or go l)eft? [r, l, i, q]");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "r":
                        Console.WriteLine("You follow the path upward and to the right.");
                        ContinuePrompt();
                        Room4(items);
                        break;

                    case "l":
                        Console.WriteLine("You follow the downward path to the left.");
                        ContinuePrompt();
                        Room3(items);
                        break;

                    case "i":
                        Inventory(items);
                        Room2(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Please enter a valid letter.");
                        ContinuePrompt();
                        Room2(items);
                        break;
                }
            }
        }
        public static void Room3(List<string> items)
        {
            //The sphinx room, where the player must answer a riddle to proceed.

            string riddleAnswer;

            Header("Sphinx Gate");
            Console.WriteLine("A closed iron gate bars your path to the outside world.\nKalena, the guardian sphinx, is loosely chained nearby.\nShe eyes you hungrily, but you know she cannot eat you unless you fail to solve her riddle.");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("What can run but never walks and has a bed but never sleeps?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("What is your response? (Enter a word.) ");
            riddleAnswer = Console.ReadLine().ToLower();
            if(riddleAnswer == "river" || riddleAnswer == "a river" || riddleAnswer == "r")
            {
                Console.WriteLine("Grudgingly, the sphinx opens the gate for you. You leave Klingsor's lair and enter the great outdoors.");
                ContinuePrompt();
                Room5(items);
            }
            else
            {
                Console.WriteLine("Kalena licks her lips as you give an incorrect answer. She will eat well today.");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("You have died.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                ContinuePrompt();
                End();
            }
        }
        public static void Room4(List<string> items)
        {
            //The Library room, in which the player must use a cloak or enter the secret letter "b" to continue.

            string playerSelection;

            if (items.Contains("cloak"))
            {
                Header("Ligneous Library");
                Console.Write("Tomes of all sizes, shapes and colors fill polished mahogany ");
                RedFont("b");
                Console.WriteLine("ookcases here in Klingsor's library.\n" +
                    "The wooden floor creaks venerably as gnomes in black hooded robes traverse the room, on an endless quest for knowledge.\n" +
                    "This chamber is forbidden to all but the Master and his sages.\n It is whispered among the kobolds, however, that there is a secret way through.");
                Console.WriteLine();
                Console.Write("What will you do? You can try to r)un through, or perhaps put on your c)loak...");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "r":
                        Console.WriteLine("You drop to all fours and sprint through the room.\nThe gnomes are surprisingly quick, however, and know a surprising number of ways to destroy you magically.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You have died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        ContinuePrompt();
                        break;

                    case "b":
                        Console.WriteLine("Something smells odd about one of the bookcases near the entrance. You crawl over to it and investigate.\n" +
                            "Sure enough, there is a row of false books close to the ground. \n" +
                            "The painted panel swings open and you crawl through, grateful now for your small size.");
                        ContinuePrompt();
                        Room6(items);
                        break;


                    case "c":
                        Console.Write("You may be a little smaller than a gnome, but not much. With the cloak on, you resemble a sage.\n" +
                            "Slowly, you make your way across the library, trying to seem casual but avoiding any contact with the gnomes.\n" +
                            "You successfully reach the other side, climbing a spiral wooden stairway upwards.");
                        ContinuePrompt();
                        Room6(items);
                        break;

                    case "i":
                        Inventory(items);
                        Room4(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Please enter a valid letter.");
                        ContinuePrompt();
                        Room4(items);
                        break;
                }
            }
            else
            {
                Header("Ligneous Library");
                Console.Write("Tomes of all sizes, shapes and colors fill polished mahogany ");
                RedFont("b");
                Console.WriteLine("ookcases here in Klingsor's library.\n" +
                    "The wooden floor creaks venerably as gnomes in black hooded robes traverse the room, on an endless quest for knowledge.\n" +
                    "This chamber is forbidden to all but the Master and his sages.\n It is whispered among the kobolds, however, that there is a secret way through.");
                Console.WriteLine();
                Console.Write("What will you do? You can try to r)un through...");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "r":
                        Console.WriteLine("You drop to all fours and sprint through the room.\nThe gnomes are surprisingly quick, however, and know a surprising number of ways to destroy you magically.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You have died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        ContinuePrompt();
                        break;

                    case "b":
                        Console.WriteLine("Something smells odd about one of the bookcases near the entrance. You crawl over to it and investigate.\n" +
                            "Sure enough, there is a row of false books close to the ground. \n" +
                            "The painted panel swings open and you crawl through, grateful now for your small size.");
                        ContinuePrompt();
                        Room6(items);
                        break;

                    case "i":
                        Inventory(items);
                        Room4(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Please enter a valid letter.");
                        ContinuePrompt();
                        Room4(items);
                        break;
                }
            }
        }

        public static void Room5(List<string> items)
        {
            //This is the forest, in which the player must enter a direction (e, w, s, n) in accordance with the acrostic found in the clues (or use a dagger).

            string playerSelection;

            if (items.Contains("dagger"))
            {
                Header("Acrostic Forest");
                Console.WriteLine("You are in a vast, dark wood. The sun is setting; you must make it through quickly, before the night beasts emerge.");
                Console.WriteLine("A sign reads, ");
                RedFont("Caution! GROWING ON EVERY ALDER; SMELLS TERRIBLE!");
                Console.WriteLine();
                Console.WriteLine("Paths diverge in all directions. Which way will you go?");
                Console.Write("You could go n)orth, for example, or s)outh, or use your d)agger to help you...");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "d":
                        Console.WriteLine("Using your dagger, you mark the trees at each junction so that you don't become lost, passing through the forest and arriving at a tower.");
                        ContinuePrompt();
                        //Room7(items);
                        break;

                    case "e":
                        Console.WriteLine("You head east, against the rising gibbous moon, and find yourself at another junction.");
                        Console.WriteLine();
                        Console.WriteLine("Another sign stands here: ");
                        RedFont("LONG AGO, FEW ELSE PASS IT.");
                        Console.WriteLine();
                        Console.Write("Enter a new direction:");
                        playerSelection = Console.ReadLine().ToLower();
                        if(playerSelection == "west" || playerSelection == "w")
                        {
                            Console.WriteLine();
                            Console.Write("Soon, you arrive at one final sign, but it has been damaged beyond legibility.\nA slightly ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("colder wind,");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("however, brings the scent of your destination to you.");
                            Console.Write("Enter a new direction:");
                            playerSelection = Console.ReadLine().ToLower();
                            if (playerSelection == "north" || playerSelection == "n")
                            {
                                Console.WriteLine("At last, you emerge from the forest and find yourself in front of a tower.");
                            }
                            else
                            {
                                Console.WriteLine("You become hopelessly lost in the deep forest and are soon eaten by a horrible beast.");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("You have died.");
                                Console.ForegroundColor = ConsoleColor.White;
                                ContinuePrompt();
                                End();
                            }
                        }
                        else
                        {
                            Console.WriteLine("You become hopelessly lost in the deep forest and are soon eaten by a horrible beast.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("You have died.");
                            Console.ForegroundColor = ConsoleColor.White;
                            ContinuePrompt();
                            End();
                        }
                        ContinuePrompt();
                        Room7(items);
                        break;

                    case "i":
                        Inventory(items);
                        Room5(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("You become hopelessly lost in the deep forest and are soon eaten by a horrible beast.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You have died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        ContinuePrompt();
                        break;
                }
            }
            else
            {
                Header("Acrostic Forest");
                Console.WriteLine("You are in a vast, dark wood. The sun is setting; you must make it through quickly, before the night beasts emerge.");
                Console.WriteLine("A sign reads, ");
                RedFont("Caution! GROWING ON EVERY ALDER; SMELLS TERRIBLE!");
                Console.WriteLine();
                Console.WriteLine("Paths diverge in all directions. Which way will you go?");
                Console.Write("You could go n)orth, for example, or s)outh... (enter a letter) ");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "e":
                        Console.WriteLine("You head east, against the rising gibbous moon, and find yourself at another junction.");
                        Console.WriteLine();
                        Console.WriteLine("Another sign stands here: ");
                        RedFont("LONG AGO, FEW ELSE PASS IT.");
                        Console.WriteLine();
                        Console.Write("Enter a new direction:");
                        playerSelection = Console.ReadLine().ToLower();
                        if (playerSelection == "west" || playerSelection == "w")
                        {
                            Console.WriteLine();
                            Console.Write("Soon, you arrive at one final sign, but it has been damaged beyond legibility.\nA slightly ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("colder wind,");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("however, brings the scent of your destination to you.");
                            Console.WriteLine("Enter a new direction:");
                            playerSelection = Console.ReadLine().ToLower();
                            if (playerSelection == "north" || playerSelection == "n")
                            {
                                Console.WriteLine("At last, you emerge from the forest and find yourself in front of a tower.");
                            }
                            else
                            {
                                Console.WriteLine("You become hopelessly lost in the deep forest and are soon eaten by a horrible beast.");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("You have died.");
                                Console.ForegroundColor = ConsoleColor.White;
                                ContinuePrompt();
                                End();
                            }
                        }
                        else
                        {
                            Console.WriteLine("You become hopelessly lost in the deep forest and are soon eaten by a horrible beast.");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("You have died.");
                            Console.ForegroundColor = ConsoleColor.White;
                            ContinuePrompt();
                            End();
                        }
                        ContinuePrompt();
                        Room7(items);
                        break;

                    case "i":
                        Inventory(items);
                        Room5(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("You become hopelessly lost in the deep forest and are soon eaten by a horrible beast.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You have died.");
                        Console.ForegroundColor = ConsoleColor.White;
                        ContinuePrompt();
                        break;
                }
            }

        }

        public static void Room6(List<string> items)
        {
            //The kitchen, in which the player must unscramble the letters to find the correct word or use a dagger to proceed.

            string playerSelection;
            string riddleAnswer;

            if (items.Contains("dagger"))
            {
                Header("Scrambled Kitchen");
                Console.Write("This large cooking area is packed with all manner of ingredients littering tables and counters. \n" +
                    "A rotund dwarf is throwing food into a pot, and singing...\n" +
                    "Oh, my ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("lemons ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("are ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("solemn,");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" but ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("limes ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("make me ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("smile!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("\"You!\" he cries, pointing at you. \"The final herb... ");
                RedFont("players!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("I mean, ");
                RedFont("replays! SPARELY!\"\n");
                Console.WriteLine("He holds his hand out to you urgently.");
                Console.WriteLine();
                Console.Write("Hand him something for the p)ot, or brandish your d)agger?");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "p":
                        Console.Write("What will you hand the chef?");
                        riddleAnswer = Console.ReadLine().ToLower();
                        if (riddleAnswer == "parsley" || riddleAnswer == "p")
                        {
                            Console.WriteLine("The dwarf snatches the parsley from your hand and pops it into the cauldron.\n" +
                                "Pleased, he pulls a hidden lever and a gate opens, allowing you to pass through.");
                            ContinuePrompt();
                            Room7(items);
                        }
                        else
                        {
                            Console.WriteLine("\"No, no!\" cries the dwarf. Frustrated, he refuses to allow you passage through the kitchens, and you are forced to return empty-handed.");
                            Console.WriteLine("Klingsor is not pleased to see you again, but a snack of kobold meat improves his mood.");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("You have died.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            ContinuePrompt();
                            End();
                        }
                        break;

                    case "d":
                        Console.WriteLine("The sharpness of your dagger impresses the dwarf, who decides to leave you alone and find another helper.\n" +
                            "Soon, you find your way out of the dragon's lair and into a wide valley with a tall stone tower.");
                        ContinuePrompt();
                        Room7(items);
                        break;

                    case "i":
                        Inventory(items);
                        Room6(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Please enter a valid letter.");
                        ContinuePrompt();
                        Room6(items);
                        break;
                }
            }
            else
            {
                Header("Scrambled Kitchen");
                Console.Write("This large cooking area is packed with all manner of ingredients littering tables and counters. \n" +
                    "A rotund dwarf is throwing food into a pot, and singing...\n" +
                    "Oh, my ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("lemons ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("are ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("solemn,");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" but ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("limes ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("make me ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("smile!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("\"You!\" he cries, pointing at you. \"The final herb... ");
                RedFont("players!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("I mean, ");
                RedFont("replays! SPARELY!");
                Console.WriteLine("He holds his hand out to you urgently.");
                Console.WriteLine();
                Console.Write("Hand him something for the p)ot?");
                playerSelection = Console.ReadLine().ToLower();
                switch (playerSelection)
                {
                    case "p":
                        Console.Write("What will you hand the chef? (enter a word) ");
                        riddleAnswer = Console.ReadLine().ToLower();
                        if (riddleAnswer == "parsley" || riddleAnswer == "p")
                        {
                            Console.WriteLine("The dwarf snatches the parsley from your hand and pops it into the cauldron.\n" +
                                "Pleased, he pulls a hidden lever and a gate opens, allowing you to pass through.");
                            ContinuePrompt();
                            Room7(items);
                        }
                        else
                        {
                            Console.WriteLine("\"No, no!\" cries the dwarf. Frustrated, he refuses to allow you passage through the kitchens, and you are forced to return empty-handed.");
                            Console.WriteLine("Klingsor is not pleased to see you again empty-handed, but a snack of kobold meat improves his mood.");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("You have died.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            ContinuePrompt();
                            End();
                        }
                        break;

                    case "i":
                        Inventory(items);
                        Room6(items);
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Please enter a valid letter.");
                        ContinuePrompt();
                        Room6(items);
                        break;
                }
            }
        }

        public static void Room7(List<string> items)
        {
            //The tower, in which an item must be used, unless the player has none. Different versions of the room exist for different items.

            string playerResponse;

            Header("The Tower");

            Console.WriteLine("Night has fallen. You find yourself standing before a tower made entirely of obsidian.");
            if (items.Contains("cloak"))
            {
                Console.WriteLine("The treasure is definitely inside, and the massive gate stands open, but is guarded by a hungry giant.");
                Console.WriteLine();
                Console.Write("What will you do? You could try to r)eason with the giant, or put on your c)loak...");
                playerResponse = Console.ReadLine().ToLower();
                if (playerResponse == "r")
                {
                    Console.WriteLine("You strike up a conversation with the giant.\nIt has not spoken to anyone in quite some time, and is quite satisfied with both the conversation and the following meal of kobold.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("You have died.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    ContinuePrompt();
                    End();
                }
                else if (playerResponse == "c")
                {
                    Console.WriteLine("Putting on your dark cloak, you blend in with the night.\nThe darkness combined with your tiny size are enough to sneak past the giant and enter the tower.");
                    ContinuePrompt();
                    Room8(items);
                }
                else if (playerResponse == "i")
                {
                    Inventory(items);
                    Room7(items);
                }
                else if (playerResponse == "q")
                {
                    End();
                }
                else
                {
                    Console.WriteLine("Please enter a valid letter.");
                    ContinuePrompt();
                    Room7(items);
                }
            }
            else if (items.Contains("matches"))
            {
                Console.WriteLine("The treasure is definitely inside, and the massive gate stands open, but is guarded by a ferocious troll.");
                Console.WriteLine();
                Console.Write("What will you do? You could try to r)eason with the troll, or use your m)atches to set a fire...");
                playerResponse = Console.ReadLine().ToLower();
                if (playerResponse == "r")
                {
                    Console.WriteLine("You strike up a conversation with the troll.\nIt has not spoken to anyone in quite some time, and is quite satisfied with both the conversation and the following meal of kobold.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("You have died.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    ContinuePrompt();
                    End();
                }
                else if (playerResponse == "m")
                {
                    Console.WriteLine("Knowing that trolls are deathly afraid of fire, you set fire to a branch and threaten the troll with it.\nIt does not dare come near you, and you enter the tower.");
                    ContinuePrompt();
                    Room8(items);
                }
                else if (playerResponse == "i")
                {
                    Inventory(items);
                    Room7(items);
                }
                else if (playerResponse == "q")
                {
                    End();
                }
                else
                {
                    Console.WriteLine("Please enter a valid letter.");
                    ContinuePrompt();
                    Room7(items);
                }
            }
            else if (items.Contains("dagger"))
            {
                Console.WriteLine("The treasure is definitely inside, and the massive gate stands open, but is guarded by a fierce griffin,\ntied to a nearby tree.");
                Console.WriteLine();
                Console.Write("What will you do? You could try to r)eason with the griffin, or use your d)agger to cut it free...");
                playerResponse = Console.ReadLine().ToLower();
                if (playerResponse == "r")
                {
                    Console.WriteLine("You try to strike up a conversation with the griffin, but it is only a little more intelligent that a lion or an eagle, and cannot speak.\nIt can, however, eat you, which it proceeds to do.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("You have died.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    ContinuePrompt();
                    End();
                }
                else if (playerResponse == "d")
                {
                    Console.WriteLine("You sneak up to the tree and cut through the rope with your weapon.\nThe griffin takes to the skies, enjoying its newfound freedom. You enter the tower.");
                    ContinuePrompt();
                    Room8(items);
                }
                else if (playerResponse == "i")
                {
                    Inventory(items);
                    Room7(items);
                }
                else if (playerResponse == "q")
                {
                    End();
                }
                else
                {
                    Console.WriteLine("Please enter a valid letter.");
                    ContinuePrompt();
                    Room7(items);
                }
            }
            else
            {
                Console.WriteLine("The treasure is definitely inside, and the massive gate stands open, but is guarded by a knight wearing onyx armor.");
                Console.WriteLine();
                Console.WriteLine("Having no items at all to help you deal with the situation, you are forced to approach openly.\n" +
                    "Meekly, you point at the gate and chirp, requesting entry.");
                Console.WriteLine("The knight can hardly believe that a kobold could come this far empty-handed.\n" +
                    "Impressed by your bravery and the purity of your conviction, he stands aside, and you enter the tower.");
                ContinuePrompt();
                Room8(items);
            }
        }
        public static void Room8(List<string> items)
        {
            //Having found the treasure, the player makes a final decision on whether to give it to Klingsor or keep it for themselves.

            string playerResponse; 

            Header("The Treasure");

            Console.WriteLine("Cautiously, you climb the 108 stairs leading to the top of the tower.");
            Console.Write("In the topmost chamber, set on a pedestal, lies the ");
            RedFont("treasure");
            Console.WriteLine(": a tiny ring.");
            Console.WriteLine("Set with a beautiful opal in the center, this is a magic ring, though you have no idea what it does.");
            Console.WriteLine("You could r)eturn the ring to your master Klingsor...");
            Console.WriteLine("Or you could w)ear the ring yourself.");
            Console.Write("What will you do?");
            playerResponse = Console.ReadLine().ToLower();
            if (playerResponse == "r")
            {
                Console.WriteLine("It would be an easy thing to take the ring for yourself.\nAll your short life, however, you have been loyal to Klingsor, and you will not fail your master now.\n" +
                    "You make the long trek back to Klingsor's lair and lay the magic item at the dragon's feet.");
                Console.WriteLine();
                RedFont("WELL DONE, MY FAITHFUL SERVANT, ");
                Console.WriteLine("he intones.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I NAME YOU \"TRUEHEART\", FIRST AMONG MY SERVANTS.");
                Console.WriteLine("TAKE YOUR PLACE OF HONOR AT MY SIDE.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("The other kobolds celebrate your return, hailing you as a hero.\nFrom that day forth, you wear an iron torc around your neck, marking you as a leader among your people.\n" +
                    "You spend the rest of your short life in luxury, having earned the respect of all.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your quest is at an end.");
                Console.ForegroundColor = ConsoleColor.White;
                goal = true;
                ContinuePrompt();
                End();
    
            }
            else if(playerResponse == "w")
            {
                Console.WriteLine("You slide it onto a clawed finger, and the ring looks into your soul...");
                Console.WriteLine();
                ContinuePrompt();
                if (items.Contains("cloak"))
                {
                    Console.Write("In taking the ");
                    RedFont("cloak");
                    Console.Write(", you have shown that you have the heart of a cunning ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("thief");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("!");
                    Console.WriteLine("The ring fills your mind with all of the knowledge and skills you will need to become a master of the shadows.\n" +
                        "Though Klingsor is wrathful, your newfound knowledge is enough to evade his agents,\nand you begin a new life in the capital city.\n" +
                        "In time, you build a mighty criminal empire and, though your life is not long, it is filled with riches and excitement.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You have completed your adventure!");
                    Console.ForegroundColor = ConsoleColor.White;
                    goal = true;
                    ContinuePrompt();
                    End();

                }
                else if (items.Contains("matches"))
                {
                    Console.Write("In taking the ");
                    RedFont("matches");
                    Console.Write(", you have shown that you have the heart of a wise ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("wizard");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("!");
                    Console.WriteLine("The ring fills your mind with all of the knowledge and skills you will need to become a sorceror.\n" +
                        "Though Klingsor is wrathful, your newfound magic is enough to evade or defeat his agents,\nand you begin a new life as master of the tower.\n" +
                        "In time, you become a mighty enchanter, and the world speaks of you as the most powerful mage on the continent.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You have completed your adventure!");
                    Console.ForegroundColor = ConsoleColor.White;
                    goal = true;
                    ContinuePrompt();
                    End();
                }
                else if (items.Contains("dagger"))
                {
                    Console.Write("In taking the ");
                    RedFont("dagger");
                    Console.Write(", you have shown that you have the heart of a great ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("warrior");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("!");
                    Console.WriteLine("The ring fills your mind with all of the knowledge and skills you will need to become a master of combat.\n" +
                        "Though wrathful Klingsor sends monsters out to reclaim the ring from you, you defeat them all with your newfound skills.\n" +
                        "In time, you become the greatest gladiator in the arena, capable of defeating enemies much larger and stronger than you.\n" +
                        "Your life as a champion fighter is brief, but glorious.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You have completed your adventure!");
                    Console.ForegroundColor = ConsoleColor.White;
                    goal = true;
                    ContinuePrompt();
                    End();
                }
                else
                {
                    Console.WriteLine("And suddenly, you feel great power coursing through you!");
                    Console.Write("By setting forth with ");
                    RedFont("nothing,");
                    Console.WriteLine(" you have shown great bravery, and the ring is pleased.");
                    Console.Write("It grants you every kobold's dream:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" to be a mighty dragon!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("With your new wings, you fly far away to establish your own lair, amassing treasure and defeating enemies over time\n" +
                        "until you become known as the mighty ruler of an empire of beasts and monsters.");
                    Console.WriteLine("You never forget your origin, however, and ensure that your kobolds are treated well.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You have completed your adventure!");
                    Console.ForegroundColor = ConsoleColor.White;
                    goal = true;
                    ContinuePrompt();
                    End();
                }
            }
            else
            {
                Console.WriteLine("You must make your final decision. Choose.");
                ContinuePrompt();
                Room8(items);
            }
        }

        public static void Start()
        {
            //The intro screen, shown when the game begins. It offers the chance to see instructions before continuing to room 1.

            string userResponse;
            bool startDone = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("The quest begins...");
            Console.WriteLine();
            while (!startDone)
            { 
                Console.Write("Would you like instructions? [y/n]");
            userResponse = Console.ReadLine().ToLower();
            
                if (userResponse == "y")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Welcome to Kobold Quest!");
                    Console.WriteLine("You are a kobold, a small reptilian humanoid creature created to serve the dragons.");
                    Console.WriteLine("Your lord and master, Klingsor, has had something stolen from his trove, and has tasked you with finding it.");
                    Console.WriteLine("The goal of this game is to find the dragon's lost treasure.");
                    Console.WriteLine("(Surviving would also be nice.)");
                    Console.WriteLine("To play, simply type the letter for the action you wish to take.");
                    Console.WriteLine("Sometimes, you will be required to enter a full word, and some options may be hidden.");
                    Console.WriteLine("You can also type \"i\" to see your inventory or \"q\" to quit at any time.");
                    Console.WriteLine("Beware! Your journey will be very dangerous for a small kobold. Caution would be wise!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press enter to begin your quest!");
                    Console.ReadLine();
                    startDone = true;
                }
                else if (userResponse == "n")
                {   
                    startDone = true;
                }
                else
                {
                    Console.WriteLine("Please type \"y\" for yes or \"n\" for no.");
                }
            }
            Game.Play();

        }
        public static void End()
        {
            //This is the ending screen, seen when the player dies, quits or finishes the game.
            //It tells the player whether or not they have succeeded on the quest and offers the chance to play again.
            //KNOWN BUG: Sometimes, the player must enter "n" repeatedly to quit the game instead of just once.

            string playAgain;
            bool done = false;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Clear();
            Console.WriteLine("Thank you for playing Kobold Quest.");
            if (goal == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You found the treasure! Congratulations!");
                Console.WriteLine("There are other paths to explore. Your adventure may still continue...");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.WriteLine("You did not find the dragon's lost treasure. Better luck next time!");
            }
            Console.WriteLine();
            while (!done)
            {
                Console.WriteLine("Would you like to play again? [y/n]");
                playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    done = true;
                    Play();
                }
                if (playAgain == "n")
                {
                    done = true;
                    Console.WriteLine("Goodbye!");
                    ContinuePrompt();
                }
                else
                {
                    Console.WriteLine("I didn't catch that.");
                }
            }
        }
        public static void Play()
        {
            //Resets and begins the game.

            List<string> items = new List<string>();
            Console.ForegroundColor = ConsoleColor.White;

                Room1(items);

            End();
        }
        public static void Inventory(List<string> items)
        {
            //Displays the player's inventory, if they have one. If not, it displays "You are not currently carrying anything."

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (items.Count == 0)
            {
                Console.WriteLine("You are not currently carrying anything.");
                ContinuePrompt();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("You are currently carrying:");
                foreach (string item in items)
                {
                    Console.WriteLine(item);
                    ContinuePrompt();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        static void ContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }
        static void Header(string headerText)
        {
            //Displays headers in cyan.

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void RedFont(string redText)
        {
            //A quick method to get red text in the middle of a line.

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(redText);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    class Program
    {
        // **************************************************
        //
        // Title: Kobold Quest
        // Description: Text Adventure Game
        // Application Type: Console
        // Author: Ludwig, Ben
        // Dated Created: 7/12/21
        // Last Modified: 7/25/21
        //
        // **************************************************

        static void Main(string[] args)
        {
            string textToEnter = @"
 *      _  __     _           _     _    ____                  _   
 *     | |/ /    | |         | |   | |  / __ \                | |  
 *     | ' / ___ | |__   ___ | | __| | | |  | |_   _  ___  ___| |_ 
 *     |  < / _ \| '_ \ / _ \| |/ _` | | |  | | | | |/ _ \/ __| __|
 *     | . \ (_) | |_) | (_) | | (_| | | |__| | |_| |  __/\__ \ |_ 
 *     |_|\_\___/|_.__/ \___/|_|\__,_|  \___\_\\__,_|\___||___/\__|
 *                                                                 
 *";                                                                                                                                           ;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(textToEnter);

            Game.Start();


        }
    }
}
